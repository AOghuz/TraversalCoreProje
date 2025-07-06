using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Abstract.AbstractUow
{
    public interface IAccountService:IGenericUowService<Account>
    {

    }
}
