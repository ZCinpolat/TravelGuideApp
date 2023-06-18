using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_TraversalApp.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EFCommentDAL());
        public IViewComponentResult Invoke(int id)
        {
            var list = commentManager.TGetCommentListByDestinationID(id);
            return View(list);  
        }
    }
}
