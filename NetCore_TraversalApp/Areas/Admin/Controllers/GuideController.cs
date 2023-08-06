using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Guide")]
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;   
        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var datas =  _guideService.TGetAll();   
            return View(datas);
        }

        [Route("AddNewGuide")]
        [HttpGet]
        public async Task<IActionResult> AddNewGuide()
        {
            return View();
        }

        [Route("AddNewGuide")]
        [HttpPost]
        public async Task<IActionResult> AddNewGuide(Guide model)
        {
            GuideValidator validator = new GuideValidator();
            var validationRes = validator.Validate(model);
            if (validationRes.IsValid)
            {
                _guideService.TAdd(model);
                return RedirectToAction("Index", "Guide", new { Area = "Admin" });
            }
            else
            {
                foreach (var item in validationRes.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [Route("DeleteGuide")]
        [HttpGet]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var model = _guideService.TGetById(id);
            _guideService.TRemove(model);
            return RedirectToAction("Index", "Guide", new { Area = "Admin" });
        }


        [Route("UpdateGuide/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateGuide(int id)
        {
            var model = _guideService.TGetById(id);
            return View(model);
        }


        [Route("UpdateGuide/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateGuide(Guide model)
        {
            GuideValidator validator = new GuideValidator();
            var validationRes = validator.Validate(model);
            if (validationRes.IsValid)
            {
                _guideService.TUpdate(model);
                return RedirectToAction("Index", "Guide", new { Area = "Admin" });
            }
            else
            {
                foreach(var item in validationRes.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }

    }
}
