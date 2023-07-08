using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
