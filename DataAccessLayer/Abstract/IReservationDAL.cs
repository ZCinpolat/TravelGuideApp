using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDAL : IGenericDAL<Reservation>
    {

        List<Reservation> GetWaitingApproveReservationList(int reservationId);
        List<Reservation> GetApprovedReservationList(int reservationId);
        List<Reservation> GetPreviusReservationList(int reservationId);


    }
}
