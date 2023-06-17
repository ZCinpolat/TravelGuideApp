using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
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

        public Destination GetByIt(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Destination t)
        {
            throw new NotImplementedException();
        }

        public void TRemove(Destination t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Destination t)
        {
            throw new NotImplementedException();
        }
    }
}
