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
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x => x.DestinationId == id).Include(x => x.Guide).FirstOrDefault();
            }
        }
        Context context = new Context();
        public void ChangeToFalseByGuide(int id)
        {

            var value = context.Guides.Find(id);
            value.Status = false;
            context.Update(value);
            context.SaveChanges();

        }

        public void ChangeToTrueByGuide(int id)
        {
            var value = context.Guides.Find(id);
            value.Status = true;
            context.Update(value);
            context.SaveChanges();
        }

        public List<Destination> GetLast4Destinations()
        {
            using (var context = new Context())
            {
                var values = context.Destinations.Take(4).OrderBy(x => x.DestinationId).ToList();
                return values;
            }
        }
    }
}
