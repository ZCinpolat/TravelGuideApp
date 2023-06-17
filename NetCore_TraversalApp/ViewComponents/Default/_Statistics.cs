using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            using var _context = new Context();
            ViewBag.Destinations_Count = _context.Destinations.Count();
            ViewBag.Guides_Count = _context.Guides.Count();
            ViewBag.Customers_Count = 100;

            return View();
        }
    }
   
}
