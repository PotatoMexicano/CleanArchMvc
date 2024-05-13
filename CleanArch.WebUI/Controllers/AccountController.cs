﻿using CleanArch.Domain.Account;
using CleanArch.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;
        private readonly ISeedUserRoleInitial _seedUserRoleInitial;

        public AccountController(IAuthenticate authenticate, ISeedUserRoleInitial seedUserRoleInitial)
        {
            _authenticate = authenticate;
            _seedUserRoleInitial = seedUserRoleInitial;
        }

        [HttpGet]
        public IActionResult Populate()
        {
            _seedUserRoleInitial.SeedRoles();
            _seedUserRoleInitial.SeedUsers();

            return Ok();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            bool result = await _authenticate.RegisterUser(model.Email, model.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong)");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            bool result = await _authenticate.Authenticate(model.Email, model.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }

                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. (password must be strong).");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout() 
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }


    }
}
