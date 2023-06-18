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
            throw new NotImplementedException();
        }

        public List<Comment> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Comment TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TRemove(Comment t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetCommentListByDestinationID(int destinationId)
        {
            return _commentDAL.GetListByFilter(x => x.DestinationID == destinationId).ToList();
        }
    }
}
