using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{

    [AllowAnonymous]
    [Area("Admin")]
    //[Route("Admin/[controller]/[action]")]
    public class DestinationController : Controller
    {

        DestinationManager _destinationManager = new DestinationManager(new EFDestinationDAL());
        [HttpGet]
        public IActionResult Index()
        {
            var destinations = _destinationManager.TGetAll();

            return View(destinations);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewDestination() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDestination(Destination model)
        {
            _destinationManager.TAdd(model);
            return RedirectToAction("Index","Destination", new { Area ="Admin"});
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var model = _destinationManager.TGetById(id);
            _destinationManager.TRemove(model);
            return RedirectToAction("Index", "Destination", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDestination(int id)
        {
            var model = _destinationManager.TGetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDestination(Destination model)
        {
            _destinationManager.TUpdate(model);
            return RedirectToAction("Index");
        }


    }
}
