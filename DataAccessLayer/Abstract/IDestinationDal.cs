using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal:IGenericDal<Destination>
    {
        public Destination GetDestinationWithGuide(int id);
        void ChangeToTrueByGuide(int id);
        void ChangeToFalseByGuide(int id);
        public List<Destination> GetLast4Destinations();
    }
}
