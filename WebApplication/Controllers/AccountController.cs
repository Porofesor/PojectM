using EFDataAccessLib.Models.People;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly UserManager<UserAccount> _userManager;

        public AccountController(SignInManager<UserAccount> signInManager, UserManager<UserAccount> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Login(LoginViewModel model, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.(model.Login,);
                    HttpContext.Session.SetString("User_id", user.Id);
                    HttpContext.Session.SetString("UserLogin", user.Login);

                    return RedirectToLocal(returnUrl);
                }
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
