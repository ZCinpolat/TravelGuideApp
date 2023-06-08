using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
