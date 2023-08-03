using BusinessLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.AdminDashboard
{
    public class _DashboardStatisticCardsRow1 : ViewComponent
    {
        DestinationManager _destinationManager = new DestinationManager(new DataAccessLayer.EntityFramework.EFDestinationDAL());
        GuideManager _guidemanager = new GuideManager(new DataAccessLayer.EntityFramework.EFGuideDAL());

        public IViewComponentResult Invoke()
        {
            ViewBag.DestinationCount = _destinationManager.TGetAll().Count();
            ViewBag.GuideCount = _guidemanager.TGetAll().Count();  
            return View();
        }

    }
}
