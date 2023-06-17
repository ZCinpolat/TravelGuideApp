using BusinessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NetCore_TraversalApp.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        TestimonialManager manager = new TestimonialManager(new DataAccessLayer.EntityFramework.EFTestimonialDAL());
        public IViewComponentResult Invoke()
        {
            var list = manager.TGetAll();
            return View(list);
        } 
    }
}
