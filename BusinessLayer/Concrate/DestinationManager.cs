using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class DestinationManager : IDestinationService
    {

        private EFDestinationDAL eFDestinationDAL;

        public DestinationManager(EFDestinationDAL _eFDestinationDAL)
        {
            this.eFDestinationDAL = _eFDestinationDAL;
        }

        public List<Destination> TGetAll()
        {
            return eFDestinationDAL.GetList();
        }

        public Destination TGetById(int id)
        {
            return eFDestinationDAL.GetList().Where(x => x.DestinationID == id).FirstOrDefault();
        }

        public void TAdd(Destination t)
        {
           eFDestinationDAL.Insert(t);  
        }

        public void TRemove(Destination t)
        {
            eFDestinationDAL.Delete(t);
        }

        public void TUpdate(Destination t)
        {
            eFDestinationDAL.Update(t);
        }
    }
}
