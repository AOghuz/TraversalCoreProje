using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Abstract
{
    public interface IReservationnService : IGenericService<Reservationn>
    {
        List<Reservationn> GetListWithRezervasyonByWaitAprroval(int id);

        List<Reservationn> GetListWithRezervasyonByPrevious(int id);
        List<Reservationn> GetListWithRezervasyonByAccepted(int id);
    }
}
