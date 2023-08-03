using BusinessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.MemberDashboard
{
    public class _PlatformSettings :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
