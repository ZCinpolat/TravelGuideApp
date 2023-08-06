using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{

    [AllowAnonymous]
    [Area("Admin")]
    public class CommentController : Controller
    {
        //CommentManager _commentManager = new CommentManager(new DataAccessLayer.EntityFramework.EFCommentDAL());
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var datas = _commentService.TGetCommentListWithDestinations();
            return View(datas);
        }

        [ActionName("DeleteComment")]
        public IActionResult Delete(int id)
        {
            var oComment = _commentService.TGetById(id);
            _commentService.TRemove(oComment);
            return RedirectToAction("Index");
        }



    }
}
