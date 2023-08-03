using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.AdminDashboard
{
    public class _DashboardGuideList :ViewComponent
    {
        public IViewComponentResult  Invoke()
        {
            return View();  
        }
    }
}
