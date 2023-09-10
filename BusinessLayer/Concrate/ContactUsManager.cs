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
    public class ContactUsManager : IContactUsMessageService
    {
        private readonly IContactUsMessagesDAL _contactUsMessagesDAL;
        public ContactUsManager(IContactUsMessagesDAL contactUsMessagesDAL)
        {
            _contactUsMessagesDAL = contactUsMessagesDAL;
        }

        public void TAdd(ContactUsMessage t)
        {
            _contactUsMessagesDAL.Insert(t);
        }

        public bool TChangeStatusToFalse(int Id)
        {
            return _contactUsMessagesDAL.ChangeStatusToFalse(Id);
        }

        public List<ContactUsMessage> TGetAll()
        {
            return _contactUsMessagesDAL.GetList();
        }

        public List<ContactUsMessage> TGetAllBySentResponse()
        {
           return _contactUsMessagesDAL.GetAllBySentResponse();
        }

        public List<ContactUsMessage> TGetAllByWaitingResponse()
        {
            return _contactUsMessagesDAL.GetAllByWaitingResponse();
        }

        public ContactUsMessage TGetById(int id)
        {
            return _contactUsMessagesDAL.GetList().Where(x => x.ContactUsID == id).FirstOrDefault();
        }

        public void TRemove(ContactUsMessage t)
        {
            _contactUsMessagesDAL.Delete(t);
        }

        public void TUpdate(ContactUsMessage t)
        {
            _contactUsMessagesDAL.Update(t);
        }
    }
}
