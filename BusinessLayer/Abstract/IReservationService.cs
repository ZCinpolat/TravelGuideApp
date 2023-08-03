using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {

        public List<Reservation> GetApprovedReservationList(int userId);
        public List<Reservation> GetPreviusReservationList(int userId);
        public List<Reservation> GetWaitingApproveReservationList(int userId);

    }
}
