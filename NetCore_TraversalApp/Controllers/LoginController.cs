using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

    }
}
