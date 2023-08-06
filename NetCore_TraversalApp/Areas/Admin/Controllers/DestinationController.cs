using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{

    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Destination")]
    public class DestinationController : Controller
    {
        //DestinationManager _destinationManager = new DestinationManager(new EFDestinationDAL());
        private readonly IDestinationService _destinationService;
        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            var destinations = _destinationService.TGetAll();

            return View(destinations);
        }

        [Route("AddNewDestination")]
        [HttpGet]
        public async Task<IActionResult> AddNewDestination() 
        {
            return View();
        }


        [Route("AddNewDestination")]
        [HttpPost]
        public async Task<IActionResult> AddNewDestination(Destination model)
        {
            _destinationService.TAdd(model);
            return RedirectToAction("Index","Destination", new { Area ="Admin"});
        }


        [Route("DeleteDestination/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var model = _destinationService.TGetById(id);
            _destinationService.TRemove(model);
            return RedirectToAction("Index", "Destination", new { Area = "Admin" });
        }

        [Route("UpdateDestination/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateDestination(int id)
        {
            var model = _destinationService.TGetById(id);
            return View(model);
        }


        [Route("UpdateDestination/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateDestination(Destination model)
        {
            _destinationService.TUpdate(model);
            return RedirectToAction("Index");
        }


    }
}
