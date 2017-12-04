using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Identity;

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

        #region Login Get
        //[AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        #endregion

        #region Login Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
             if (ModelState.IsValid)
             {
                var result = await _signInManager.PasswordSignInAsync(
                         loginViewModel.UserName,
                         loginViewModel.Password,
                         true, false);
                if (result.Succeeded)
                 {
                    // проверяем, принадлежит ли URL приложению
                     if (!String.IsNullOrEmpty(loginViewModel.ReturnUrl) && Url.IsLocalUrl(loginViewModel.ReturnUrl))
                     {
                         return Redirect(loginViewModel.ReturnUrl);
                     }
                     else
                     {
                         return RedirectToAction("ListForAdmin", "Product");
                     }
                 }
                 else
                 {
                     ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                 }
             }
             return View(loginViewModel);
        }

        #endregion

        #region Logout

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}