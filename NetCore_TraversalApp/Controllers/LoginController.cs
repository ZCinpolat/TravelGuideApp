using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_TraversalApp.Models;

namespace NetCore_TraversalApp.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        //Create CoreIdentity manager object;
        private readonly UserManager<AppUser> _userManager;

        public LoginController( UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser user = new()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.Username,
                Email = model.Email,
                Gender="Male",
                ImageURL = "Nan"
            };
            if(model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", $"Code : {item.Code}, Desc : {item.Description}");
                    }
                }
            }

            return View(model);
        }

        public IActionResult SignIn()
        {
            return View();
        }

    }
}
