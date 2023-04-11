using BusinessLogic.DTOs.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Intefaces
{
    public interface IAccountsService
    {
        Task<IdentityUser> Get(string id);
        Task<LoginResponseDto> Login(LoginDto dto);
        Task Register(RegisterDto dto);
        Task Logout();
    }
}
