using BusinessLogic.DTOs.User;
using BusinessLogic.Intefaces;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IJWTService jwtService;

        public AccountsService(UserManager<IdentityUser> userManager,
                               SignInManager<IdentityUser> signInManager,
                               IJWTService jwtService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
        }

        public async Task<IdentityUser> Get(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            return user;
        }

        public async Task<LoginResponseDto> Login(LoginDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.Username);

            if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password))
                throw new Exception("Invalide Login or Password");

            await signInManager.SignInAsync(user, true);

            return new LoginResponseDto()
            {
                Token = jwtService.CreateToken(jwtService.GetClaims(user))
            };
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task Register(RegisterDto dto)
        {
            IdentityUser user = new()
            {
                UserName = dto.Username,
                Email = dto.Email,
            };

            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded) 
            {
                string message = string.Join(", ", result.Errors.Select(x => x.Description));

                throw new Exception(message);
            }
        }
    }
}
