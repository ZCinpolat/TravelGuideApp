using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class CommentManager : ICommentService
    {
        EFCommentDAL _commentDAL;
        public CommentManager(EFCommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        public void TAdd(Comment t)
        {
            _commentDAL.Insert(t);
        }

        public List<Comment> TGetAll()
        {
            return _commentDAL.GetList();
        }

        public Comment TGetById(int id)
        {
            return _commentDAL.GetByID(id);
        }

        public void TRemove(Comment t)
        {
            _commentDAL.Delete(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDAL.Update(t);
        }

        public List<Comment> TGetCommentListByDestinationID(int destinationId)
        {
            return _commentDAL.GetListByFilter(x => x.DestinationID == destinationId).ToList();
        }

        public List<Comment> TGetCommentListWithDestinations()
        {
            return _commentDAL.GetCommentsWithDestinations();
        }
    }
}
