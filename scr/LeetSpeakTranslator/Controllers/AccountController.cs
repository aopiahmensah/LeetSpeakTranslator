using LeetSpeakTranslator.Helpers;
using LeetSpeakTranslator.Models;
using LST.Infrastructure.Messaging;
using LST.Model.Model.IRepository;
using LST.Service.Interfaces;
using LST.Service.Messaging.Authentication.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using IAuthenticationService = LST.Service.Interfaces.IAuthenticationService;

namespace LeetSpeakTranslator.Controllers
{
    public class AccountController(IAuthenticationService authenticationService,IConfiguration configuration) : Controller
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        private readonly IConfiguration _configuration = configuration;
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            double cookieExpirationTime = _configuration.GetValue<double>("DefaultTimeOut");

            if (ModelState.IsValid)
            {
                LST.Service.Messaging.Authentication.Request.LoginRequest request = new()
                { 
                    Password = model.Password,
                    Username = model.Username,
                };

                LoginResponse response = await _authenticationService.LoginUserAsync(request);
                if (response.IsAuthenticated)
                {
                    var principal = ClaimsPrincipalHelper.SetClaimsPrincipalDetails(response);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, new AuthenticationProperties { IsPersistent = true,ExpiresUtc = DateTime.UtcNow.AddMinutes(cookieExpirationTime) });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid username or password!";
                    //return View();
                }

            }

            
            return View(model);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
