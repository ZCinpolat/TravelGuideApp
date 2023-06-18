using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.Comment
{
    public class _AddComment :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }

}
