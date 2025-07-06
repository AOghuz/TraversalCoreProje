using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        public Destination TGetDestinationWithGuide(int id);
        void TChangeToTrueByGuide(int id);
        void TChangeToFalseByGuide(int id);
        public List<Destination> TGetLast4Destinations();
    }
}
