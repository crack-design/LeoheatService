using LeoheatService.Authentication;
using LeoheatService.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string email, string password, string passwordConfirm)
        {
            var user = new ApplicationUser { UserName = email.Split('@')[0], Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var users = this._userManager.Users;
                await _signInManager.SignInAsync(user, isPersistent: false);
                return StatusCode(200);
            }

            else
            {
                return StatusCode(401);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password)
        {
            var users = this._userManager.Users;
            var userToLogin = this._userManager.FindByEmailAsync(email).Result;
            var result = await _signInManager.PasswordSignInAsync(userToLogin.UserName, password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var identity = new ClaimsIdentity("cookies");
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userToLogin.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, userToLogin.UserName));

                await AuthenticationHttpContextExtensions.SignInAsync(this.HttpContext, "cookies", new ClaimsPrincipal(identity));
                return RedirectToAction("/Home/Index");
            }
            else
            {
                return Content("Not authenticated");
            }
        }
    }
}
