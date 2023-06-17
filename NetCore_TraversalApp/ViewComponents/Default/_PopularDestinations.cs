using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
     

        DestinationManager destinationManager = new DestinationManager(new EFDestinationDAL());
        public IViewComponentResult Invoke()
        {
            var res = destinationManager.TGetAll();
            return View(res);  
        }

    }
}
