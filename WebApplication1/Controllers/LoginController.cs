using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using RegisterViewModelFinalsMP;
using LoginViewModelFinalMP;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private LoginDLL bll = new LoginDLL();
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IActionResult> Index()
        {

            if(User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
        
            return View();

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _signInManager.SignOutAsync();

                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

    

       

      

       
        public async Task <IActionResult> Login()
        {
       
            return View();

        }

        [HttpPost]
   
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            await _signInManager.SignOutAsync();
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Student");
                   
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }


            return View(user);
           
        }

     

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

    }
}
