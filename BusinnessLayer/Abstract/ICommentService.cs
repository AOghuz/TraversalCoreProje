using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Abstract
{
    public interface ICommentService: IGenericService<Comment>
    {
        List<Comment> GetByDestinationId( int id);
        List<Comment> TGetListCommentWithDestination();
        List<Comment> TGetListCommentWithDestinationAndUser(int id);
        List<Comment> TGetListCommentByUserWithDestination(int userId);
        List<Comment> TGetListWithUserAndDestination();


    }
}
