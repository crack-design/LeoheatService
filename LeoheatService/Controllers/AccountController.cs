using LeoheatService.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<Leoheat.DAL.ApplicationUser> _userManager;
        private readonly SignInManager<Leoheat.DAL.ApplicationUser> _signInManager;

        public AccountController(UserManager<Leoheat.DAL.ApplicationUser> userManager,
            SignInManager<Leoheat.DAL.ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string email, string password, string passwordConfirm)
        {
            var user = new Leoheat.DAL.ApplicationUser { UserName = email, Email = email };
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
            var result = await _signInManager.PasswordSignInAsync(users.FirstOrDefault().UserName, password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return StatusCode(200);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
