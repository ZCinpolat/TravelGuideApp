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
    public class SubAboutManager : ISubAboutService
    {

        EFSubAboutDAL _subDAL;

        public SubAboutManager(EFSubAboutDAL subDAL)
        {
            _subDAL = subDAL;
        }

        public SubAbout GetByIt(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> TGetAll()
        {
            return _subDAL.GetList();
        }

        public void TRemove(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SubAbout t)
        {
            throw new NotImplementedException();
        }
    }
}
