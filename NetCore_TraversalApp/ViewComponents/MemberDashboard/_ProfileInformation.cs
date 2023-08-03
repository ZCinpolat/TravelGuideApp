using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.MemberDashboard
{
    public class _ProfileInformation :ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await  _userManager.FindByNameAsync(User.Identity.Name);
            if(user is not null)
            {
                ViewBag.userName = user.Name + "  " + user.Surname;
                ViewBag.mail = user.Email;
                ViewBag.phone = user.PhoneNumber;
                ViewBag.gender= user.Gender;
            }

            return View();
        }

    }
}
