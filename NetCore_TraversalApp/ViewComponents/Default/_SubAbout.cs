using BusinessLayer.Concrate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.Default
{
    public class _SubAbout :ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EFSubAboutDAL());
        public IViewComponentResult Invoke()
        {
            var obj = subAboutManager.TGetAll().FirstOrDefault();
            ViewBag.Title = obj.Title;
            ViewBag.Description = obj.Description;
            return View();
        }
    }
}
