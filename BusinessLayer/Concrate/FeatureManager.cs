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
        private IFeatureDAL _featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            this._featureDAL = featureDAL;   
        }

        public Feature TGetById(int id)
        {
            return _featureDAL.GetByID(id);
        }

        public void TAdd(Feature t)
        {
            _featureDAL.Insert(t);
        }

        public List<Feature> TGetAll()
        {
            return _featureDAL.GetList();
        }

        public void TRemove(Feature t)
        {
            _featureDAL.Delete(t);
        }

        public void TUpdate(Feature t)
        {
            _featureDAL.Update(t);
        }
    }
}
