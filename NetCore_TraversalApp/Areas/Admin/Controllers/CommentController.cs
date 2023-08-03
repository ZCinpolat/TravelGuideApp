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
        //CommentManager _CommentManager = new CommentManager(new DataAccessLayer.EntityFramework.EFCommentDAL());
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
    }
}
