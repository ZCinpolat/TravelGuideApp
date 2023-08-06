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

        private IDestinationDAL _destinationDAL;
        public DestinationManager(IDestinationDAL destinationDAL)
        {
            _destinationDAL = destinationDAL;
        }
      
        public List<Destination> TGetAll()
        {
            return _destinationDAL.GetList();
        }

        public Destination TGetById(int id)
        {
            return _destinationDAL.GetList().Where(x => x.DestinationID == id).FirstOrDefault();
        }

        public void TAdd(Destination t)
        {
            _destinationDAL.Insert(t);  
        }

        public void TRemove(Destination t)
        {
            _destinationDAL.Delete(t);
        }

        public void TUpdate(Destination t)
        {
            _destinationDAL.Update(t);
        }
    }
}
