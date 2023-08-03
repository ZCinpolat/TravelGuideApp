using BusinessLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace NetCore_TraversalApp.Areas.Member.Controllers
{

	[Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ReservationController : Controller
    {

        DestinationManager _destinationManager = new DestinationManager(new DataAccessLayer.EntityFramework.EFDestinationDAL());
        ReservationManager _reservationManager = new ReservationManager(new DataAccessLayer.EntityFramework.EFReservationDAL());
        private readonly UserManager<AppUser> _userManager;
       
        public ReservationController(UserManager<AppUser> userManager)
        {
                _userManager= userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetApprovedReservationList()
        {
            var _appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var list = _reservationManager.GetApprovedReservationList(_appUser.Id);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetWaitingApprovlReservationList()
        {
            var  _appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var list =  _reservationManager.GetWaitingApproveReservationList(_appUser.Id);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetPreviusReservationList()
        {
            var _appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var list = _reservationManager.GetPreviusReservationList(_appUser.Id);
            return View(list);
        }


        [HttpGet]
        public IActionResult AddNewReservation()
        {
            List<SelectListItem> destinationList = (from p in _destinationManager.TGetAll()
                                                    select new SelectListItem
                                                    {
                                                        Value = p.DestinationID.ToString(),
														Text = $"{p.City} - {p.DayNight} - {p.Capacity}"
													}).ToList();
            ViewBag.DestinationList = destinationList;
            Reservation model =  new Reservation();
            model.ReservationDate = DateTime.Now;

            if (destinationList.Any())
            {
                //model.Destination = destinationList.ToList().First();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewReservation(Reservation model)
        {
            var _appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            model.AppUserId = _appUser.Id;
            model.Status = "Waiting Aprove";
            _reservationManager.TAdd(model);    
            return RedirectToAction(nameof(GetWaitingApprovlReservationList));
        }



    }
}
