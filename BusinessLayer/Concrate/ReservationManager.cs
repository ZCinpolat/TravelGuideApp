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
    public class ReservationManager : IReservationService
    {
       
        private IReservationDAL eFReservationDAL;

        public ReservationManager(IReservationDAL _eFReservationDAL)
        {
            this.eFReservationDAL = _eFReservationDAL;
        }

        public List<Reservation> GetApprovedReservationList(int userId)
        {
            return eFReservationDAL.GetApprovedReservationList(userId);
        }

        public List<Reservation> GetPreviusReservationList(int userId)
        {
            return eFReservationDAL.GetPreviusReservationList(userId);
        }

        public List<Reservation> GetWaitingApproveReservationList(int userId)
        {
            return eFReservationDAL.GetWaitingApproveReservationList(userId);
        }

        public void TAdd(Reservation t)
        {
             eFReservationDAL.Insert(t);
        }

        public List<Reservation> TGetAll()
        {
            return eFReservationDAL.GetList();
        }

        public Reservation TGetById(int id)
        {
            return eFReservationDAL.GetByID(id);
        }

        public void TRemove(Reservation t)
        {
            eFReservationDAL.Delete(t);
        }

        public void TUpdate(Reservation t)
        {
            eFReservationDAL.Update(t);
        }
    }
}
