using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactUsMessagesDAL : IGenericDAL<ContactUsMessage>
    {
        List<ContactUsMessage> GetAllByWaitingResponse();
        List<ContactUsMessage> GetAllBySentResponse();
        bool ChangeStatusToFalse(int Id);
    }
}
