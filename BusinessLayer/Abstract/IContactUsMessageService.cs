using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactUsMessageService : IGenericService<ContactUsMessage>
    {
        List<ContactUsMessage> TGetAllByWaitingResponse();
        List<ContactUsMessage> TGetAllBySentResponse();
        bool TChangeStatusToFalse(int Id);
    }
}
