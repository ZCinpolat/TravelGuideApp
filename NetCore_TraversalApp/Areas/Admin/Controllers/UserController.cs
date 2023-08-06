using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class UserController : Controller
    {
        //AppUserManager _appUserManager = new AppUserManager(new EFAppUserDAL());
        private readonly IAppUserService _appUserService;   
        private readonly IReservationService _reservationService;   
        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var data = _appUserService.TGetAll();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var model = _appUserService.TGetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(AppUser model)
        {
            _appUserService.TUpdate(model);
            return View(model);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var model = _appUserService.TGetById(id);
            _appUserService.TRemove(model);
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }

        public IActionResult UserComment(int id)
        {
            var data = _appUserService.TGetAll();
            return View(data);
        }

        public IActionResult UserReservation(int id)
        {
            var userReservations = _reservationService.GetApprovedReservationList(id);
            return View(userReservations);
        }

    }
}
