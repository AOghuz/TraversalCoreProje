using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationnDal : GenericRepository<Reservationn>, IReservationnDal
    {
        public List<Reservationn> GetListWithRezervasyonByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Reservationns.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservationn> GetListWithRezervasyonByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Reservationns.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservationn> GetListWithRezervasyonByWaitAprroval(int id)
        {
            using (var context = new Context())
            {
                return context.Reservationns.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId == id).ToList();
            }
        }
    }
}
