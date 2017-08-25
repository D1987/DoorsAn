using System;
using System.Threading.Tasks;
using DoorsAn1.Data.Models;
using Microsoft.AspNetCore.Mvc;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DoorsAn1.Data.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //[AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
             if (ModelState.IsValid)
             {
                 //var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                 var result =
                     await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, true, false);
                if (/*user != null*/result.Succeeded)
                 {
                    // проверяем, принадлежит ли URL приложению
                     if (!String.IsNullOrEmpty(loginViewModel.ReturnUrl) && Url.IsLocalUrl(loginViewModel.ReturnUrl))
                     {
                         return Redirect(loginViewModel.ReturnUrl);
                     }
                     else
                     {
                         return RedirectToAction("ListOfProductsForAdmin", "Product");
                     }
                 }
                 else
                 {
                     ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                 }
             }
             return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}