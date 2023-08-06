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
        private IGuideDAL _dbContext;
        public GuideManager(IGuideDAL context)
        {
            this._dbContext = context;   
        }

        public void TAdd(Guide t)
        {
            _dbContext.Insert(t);
        }

        public List<Guide> TGetAll()
        {
            return _dbContext.GetList();
        }

        public Guide TGetById(int id)
        {
            return _dbContext.GetByID(id);
        }

        public void TRemove(Guide t)
        {
            _dbContext.Delete(t);
        }

        public void TUpdate(Guide t)
        {
           _dbContext.Update(t);
        }
    }
}
