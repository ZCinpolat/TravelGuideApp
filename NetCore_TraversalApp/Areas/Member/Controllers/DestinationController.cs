using BusinessLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    public class DestinationController : Controller
    {
        DestinationManager _dManager = new DestinationManager(new DataAccessLayer.EntityFramework.EFDestinationDAL());
        public IActionResult Index()
        {
            var oDestinationList = _dManager.TGetAll();
            return View(oDestinationList);
        }
    }
}
