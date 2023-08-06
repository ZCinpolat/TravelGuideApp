using BusinessLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NetCore_TraversalApp.Controllers
{


    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new DataAccessLayer.EntityFramework.EFCommentDAL());
        
        //[HttpGet]
        //public PartialViewResult AddComment()
        //{
        //    return PartialView();
        //}

        [HttpGet]
        public PartialViewResult AddComment(Comment p)
        {
            return PartialView(p);
        }
       
        [HttpPost]
        public IActionResult AddNewComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = true;
            commentManager.TAdd(p);
            return RedirectToAction("Index","Destination");
        }

    }
}
