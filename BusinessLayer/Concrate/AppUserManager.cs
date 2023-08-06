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
    public class AppUserManager : IAppUserService
    {
        private IAppUserDAL _dbContext;
        public AppUserManager(IAppUserDAL context)
        {
            _dbContext = context;
        }
        public List<AppUser> TGetAll()
        {
            return _dbContext.GetList();
        }

        public AppUser TGetById(int id)
        {
            return _dbContext.GetByID(id);
        }

        public void TAdd(AppUser t)
        {
            _dbContext.Insert(t);
        }

        public void TRemove(AppUser t)
        {
            _dbContext.Delete(t);
        }

        public void TUpdate(AppUser t)
        {
            _dbContext.Update(t);
        }
    }
}
