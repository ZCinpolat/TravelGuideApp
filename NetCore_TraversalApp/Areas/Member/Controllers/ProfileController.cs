using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_TraversalApp.Areas.Member.Models;

namespace NetCore_TraversalApp.Areas.Member.Controllers
{

    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManeger;
        public ProfileController(UserManager<AppUser> userManeger)
        {
            _userManeger = userManeger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _user = await _userManeger.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            if (_user is not null)
            {
                model.Email = _user.Email;
                model.Name = _user.Name;
                model.Surname = _user.Surname;
                model.ImageURL = _user.ImageURL;
                model.Phone = _user.PhoneNumber;
                model.Username = _user.UserName;
            }
            else
            {
              
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var _user = await _userManeger.FindByNameAsync(User.Identity.Name);
                if (_user is not null)
                {
                    _user.Name = model.Name;
                    _user.Email = model.Email;
                    _user.Surname = model.Surname;
                    _user.UserName = model.Username;
                    _user.PhoneNumber = model.Phone;
                    _user.PasswordHash = _userManeger.PasswordHasher.HashPassword(_user, model.Password);

                    //Insert User Image to Local Path
                    if(model.UserImage is not null)
                    {
                        var resource = Directory.GetCurrentDirectory();
                        var extension = Path.GetExtension(model.UserImage.FileName).ToLower();
                        var imageName = Guid.NewGuid().ToString() + extension;
                        var saveLocation = resource + "/wwwroot/user-images/" + imageName;
                        var streamData = new FileStream(saveLocation, FileMode.Create);
                        await model.UserImage.CopyToAsync(streamData);
                        streamData.Close();
                        _user.ImageURL = "/user-images/" + imageName;
                    }
       
                    var result = await _userManeger.UpdateAsync(_user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn", "Login");
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            return View(model);
        }

   

    }
}
