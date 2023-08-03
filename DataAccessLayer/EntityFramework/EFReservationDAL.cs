using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repository;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservationDAL : GenericRepository<Reservation>, IReservationDAL
    {
        public List<Reservation> GetApprovedReservationList(int userId)
        {
            using(var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Aproved" && x.AppUserId == userId).ToList();
            }
        }

        public List<Reservation> GetPreviusReservationList(int userId)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Completed" && x.AppUserId == userId).ToList();
            }
        }

        public List<Reservation> GetWaitingApproveReservationList(int userId)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Waiting Aprove" && x.AppUserId == userId).ToList();
            }
        }
    }
}
