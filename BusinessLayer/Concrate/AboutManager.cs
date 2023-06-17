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
    public class AboutManager : IAboutService
    {
       private IAboutDAL _dbContext;
        public AboutManager(IAboutDAL context)
        {
            _dbContext = context;   
        }
        public List<About> TGetAll()
        {
            return _dbContext.GetList();
        }

        public About GetByIt(int id)
        {
            return _dbContext.GetList().Where(x => x.AboutID == id).FirstOrDefault();
        }

        public void TAdd(About t)
        {
            _dbContext.Insert(t);
        }

        public void TRemove(About t)
        {
            _dbContext.Delete(t);
        }

        public void TUpdate(About t)
        {
            _dbContext.Update(t);
        }
    }
}
