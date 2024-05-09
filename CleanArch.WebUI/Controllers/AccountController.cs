using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
	public class AccountController : Controller
	{
        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Register() { }
        

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) { }

        [HttpGet]
        public IActionResult Login() { }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) { }

        public async Task<IActionResult> Logout() { }


    }
}
