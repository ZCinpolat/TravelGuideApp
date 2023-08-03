using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Member.Controllers
{

    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;       
        }
        public async  Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = user.Name +"  "+user.Surname;

            ///user-images/01b94c62-d2d4-48ff-a4da-b1b3be3828a9.jpg
            ViewBag.userImage = user.ImageURL;
            return View();
        }
    }
}
