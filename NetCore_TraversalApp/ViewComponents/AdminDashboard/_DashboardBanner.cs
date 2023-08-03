using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.AdminDashboard
{
    public class _DashboardBanner :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
