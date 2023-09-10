using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ContactUs")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsMessageService _contactUsService;
        public ContactUsController(IContactUsMessageService contactUsService)
        {
          _contactUsService = contactUsService;   
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var datas = _contactUsService.TGetAllByWaitingResponse();


            return View(datas);
        }
    }
}
