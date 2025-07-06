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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public Comment GetById(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetList();
        }

        public void TAdd(Comment t)
        {
             _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
        public List<Comment> GetByDestinationId(int id)
        {
            return _commentDal.GetListByFilter(x => x.DestinationId == id);
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> TGetListCommentWithDestinationAndUser(int id)
        {
            return _commentDal.GetListCommentWithDestinationAndUser(id);
        }
        public List<Comment> TGetListCommentByUserWithDestination(int userId)
        {
            return _commentDal.GetListCommentByUserWithDestination(userId);
        }
        public List<Comment> TGetListWithUserAndDestination()
        {
            return _commentDal.GetListWithUserAndDestination();
        }


    }
}
