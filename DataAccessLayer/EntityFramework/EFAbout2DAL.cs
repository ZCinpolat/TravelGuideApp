using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAbout2DAL : GenericRepository<About2>,IAbout2DAL
    {
    }
}
