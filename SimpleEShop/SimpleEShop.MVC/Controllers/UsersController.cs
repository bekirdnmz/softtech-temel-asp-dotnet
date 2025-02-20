using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SimpleEshop.Application.Services;
using SimpleEShop.MVC.Models;
using System.Security.Claims;

namespace SimpleEShop.MVC.Controllers
{
    public class UsersController(IUserService userService) : Controller
    {
        public IActionResult Login(string? nereyeGideyim=null)
        {
            var model = new UserLoginViewModel { ReturnUrl = nereyeGideyim };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string nereyeGideyim)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user != null) 
                {
                    var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim("Takim","BJK")
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(nereyeGideyim) && Url.IsLocalUrl(nereyeGideyim))
                    {
                        return Redirect(nereyeGideyim);
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("UserName", "Invalid username or password");

            }
            return View(userLogin);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
