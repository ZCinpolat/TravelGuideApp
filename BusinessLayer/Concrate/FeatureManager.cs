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
    public class FeatureManager : IFeatureService
    {
        private EFFeatureDAL _featureDAL;

        public FeatureManager(EFFeatureDAL featureDAL)
        {
            this._featureDAL = featureDAL;   
        }

        public Feature TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Feature t)
        {
            throw new NotImplementedException();
        }

        public List<Feature> TGetAll()
        {
            return _featureDAL.GetList();
        }

        public void TRemove(Feature t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Feature t)
        {
            throw new NotImplementedException();
        }
    }
}
