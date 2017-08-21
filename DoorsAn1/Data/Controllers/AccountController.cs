using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DoorsAn1.Data.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        //private AppDbContext _context;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
             if (ModelState.IsValid)
             {
                 var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                 if (user != null)
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

        /*private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));
        }*/

        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}