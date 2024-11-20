using BlogMvc.Entity.Dtos.Users;
using BlogMvc.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogMvc.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager=userManager;
            this.signInManager=signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user =await userManager.FindByEmailAsync(userLoginDto.Email);
                {
                    if (user != null)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                        if (result )
                        {

                        }
                    }
                }
            }
            return View();
        }
    }
}
