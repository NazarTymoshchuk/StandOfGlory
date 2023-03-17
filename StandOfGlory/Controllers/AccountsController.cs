using BusinessLogic.DTOs.User;
using BusinessLogic.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StandOfGlory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await accountsService.Get(id));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await accountsService.Register(dto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            await accountsService.Login(dto);
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await accountsService.Logout();
            return Ok();
        }
    }
}
