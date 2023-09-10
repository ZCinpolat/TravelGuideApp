using AutoMapper;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.Excel;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{

    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Announcement")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcmentManager;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcmentManager, IMapper mapper)
        {
                _announcmentManager = announcmentManager;   
                _mapper = mapper;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var data = _announcmentManager.TGetAll();
            var datas = _mapper.Map<List<AnnouncementListDTOs>>(data);
            //var datas = _announcmentManager.TGetAll().Select(x => new AnnouncementListViewModel
            //{
            //    ID = x.AnnouncementID,
            //    Title = x.Title,
            //    Content = x.Content
            //}) ;
            return View(datas) ;
        }

        [HttpGet]
        [Route("AddAnnouncement")]
        public IActionResult AddAnnouncement()
        {

            return View();
        }
   

        [HttpPost]
        [Route("AddAnnouncement")]
        public IActionResult AddAnnouncement(AnnouncementAddDTOs model)
        {
            if (ModelState.IsValid)
            {
                var announcement = _mapper.Map<Announcement>(model);
                announcement.CreatedData = DateTime.Now;
                _announcmentManager.TAdd(announcement);

                return RedirectToAction("Index");
            }
            return View();  
        }


        [HttpGet]
        [Route("DeleteAnnouncement/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var data = _announcmentManager.TGetById(id);
            _announcmentManager.TRemove(data);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("UpdateAnnouncement/{id}")]
        public IActionResult UpdateAnnouncement(int id)
        {
            var data = _announcmentManager.TGetById(id);
            var model = _mapper.Map<AnnouncementUpdateDTOs>(data);

            return View(model);
        }

        [HttpPost]
        [Route("UpdateAnnouncement/{id}")]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTOs model)
        {

            if (ModelState.IsValid)
            {
                var data = _mapper.Map<Announcement>(model);
                _announcmentManager.TUpdate(data);

                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
