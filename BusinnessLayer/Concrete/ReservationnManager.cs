using BusinnessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Concrete
{
    public class ReservationnManager : IReservationnService
    {
        IReservationnDal _reservationnDal;
        public ReservationnManager(IReservationnDal reservationnDal)
        {
            _reservationnDal = reservationnDal;
        }
        public Reservationn GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservationn> GetList()
        {
            return _reservationnDal.GetList();
        }

        public List<Reservationn> GetListWithRezervasyonByAccepted(int id)
        {
            return _reservationnDal.GetListWithRezervasyonByAccepted(id);
        }

        public List<Reservationn> GetListWithRezervasyonByPrevious(int id)
        {
            return _reservationnDal.GetListWithRezervasyonByPrevious(id);
        }

        public List<Reservationn> GetListWithRezervasyonByWaitAprroval(int id)
        {
            return _reservationnDal.GetListWithRezervasyonByWaitAprroval(id);
        }

        public void TAdd(Reservationn t)
        {
            _reservationnDal.Insert(t);
        }

        public void TDelete(Reservationn t)
        {
            _reservationnDal.Delete(t);
        }

        public void TUpdate(Reservationn t)
        {
            _reservationnDal.Update(t);
        }
    }
}
