using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class TestimonialManager : ITestimonialService
    {

        EFTestimonialDAL eFTestimonialDAL;

        public TestimonialManager(EFTestimonialDAL eFTestimonialDAL)
        {
            this.eFTestimonialDAL = eFTestimonialDAL;
        }

        public Testimonial TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> TGetAll()
        {
            return eFTestimonialDAL.GetList();
        }

        public void TRemove(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
        {
            throw new NotImplementedException();
        }
    }
}
