using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repository;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFContactUsMessagesDAL : GenericRepository<ContactUsMessage>, IContactUsMessagesDAL
    {
        public bool ChangeStatusToFalse(int Id)
        {
            throw new NotImplementedException();
        }


        public List<ContactUsMessage> GetAllBySentResponse()
        {
            using(var context =  new Context())
            {
                return context.ContactUsMessages.Where(x => x.MessageStatus == true).ToList();
            }
        }

        public List<ContactUsMessage> GetAllByWaitingResponse()
        {
            using (var context = new Context())
            {
                return context.ContactUsMessages.Where(x => x.MessageStatus == false).ToList();
            }
        }
    }
}
