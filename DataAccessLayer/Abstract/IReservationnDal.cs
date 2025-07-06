using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationnDal : IGenericDal<Reservationn>
    {
        List<Reservationn> GetListWithRezervasyonByWaitAprroval(int id);

        List<Reservationn> GetListWithRezervasyonByPrevious(int id);
        List<Reservationn> GetListWithRezervasyonByAccepted(int id);
    }
}
