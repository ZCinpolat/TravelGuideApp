
using BusinessLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Controllers
{
    public class DestinationController : Controller
    {

        DestinationManager dManager = new DestinationManager(new DataAccessLayer.EntityFramework.EFDestinationDAL());
        public IActionResult Index()
        {
            var destinationList = dManager.TGetAll();
            return View(destinationList);
        }


        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var model = dManager.TGetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult DestinationDetail(Destination d)
        {
            return View();
        }


    }
}
