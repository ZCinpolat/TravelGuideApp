using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class AnnouncmentManager : IAnnouncementService
    {
        private IAnnouncementDAL _announcmentDAL;
        public AnnouncmentManager(IAnnouncementDAL announcmentDAL)
        {
            _announcmentDAL = announcmentDAL;
        }
        public void TAdd(Announcement t)
        {
            _announcmentDAL.Insert(t);
        }

        public List<Announcement> TGetAll()
        {
           return _announcmentDAL.GetList();    
        }

        public Announcement TGetById(int id)
        {
           return _announcmentDAL.GetByID(id);  
        }

        public void TRemove(Announcement t)
        {
            _announcmentDAL.Delete(t);
        }

        public void TUpdate(Announcement t)
        {
            _announcmentDAL.Update(t);
        }
    }
}
