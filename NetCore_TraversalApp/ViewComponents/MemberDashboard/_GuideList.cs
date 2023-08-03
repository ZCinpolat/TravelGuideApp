using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        GuideManager _guideManager = new GuideManager(new EFGuideDAL());

    
        public  IViewComponentResult Invoke()
        {
            var guideList = _guideManager.TGetAll();
            return View(guideList);
        }

    }
}
