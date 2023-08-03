using BusinessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace NetCore_TraversalApp.ViewComponents.AdminDashboard
{
    public class _DashboardTotalRevenue :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
        
            return View();
        }

    }
}
