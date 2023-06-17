using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDAL());

        public IViewComponentResult Invoke()
        {
            var list = featureManager.TGetAll();

            return View(list);
        }


    }
}
