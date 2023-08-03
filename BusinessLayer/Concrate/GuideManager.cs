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
    public class GuideManager : IGuideService
    {
        private readonly EFGuideDAL _dbContext;
        public GuideManager(EFGuideDAL context)
        {
            this._dbContext = context;   
        }

        public void TAdd(Guide t)
        {
            throw new NotImplementedException();
        }

        public List<Guide> TGetAll()
        {
            return _dbContext.GetList();
        }

        public Guide TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TRemove(Guide t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Guide t)
        {
            throw new NotImplementedException();
        }
    }
}
