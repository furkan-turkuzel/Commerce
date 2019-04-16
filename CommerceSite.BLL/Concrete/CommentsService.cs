using CommerceSite.BLL.Abstract;
using CommerceSite.DAL.Abstract;
using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Concrete
{
    public class CommentsService : ICommentsBLL
    {
        private ICommentsDAL _commentsDAL;

        public CommentsService(ICommentsDAL commentsDAL)
        {
            _commentsDAL = commentsDAL;
        }
        public void Add(Comments entity)
        {
            _commentsDAL.Add(entity);
        }

        public void Delete(Comments entity)
        {
            _commentsDAL.Delete(entity);
        }

        public Comments Get(Expression<Func<Comments, bool>> filter)
        {
            return _commentsDAL.Get(filter);
        }

        public List<Comments> GetAll(Expression<Func<Comments, bool>> filter)
        {
            return filter == null
                ? _commentsDAL.GetAll(x=>x.IsActive == true)
                : _commentsDAL.GetAll(filter);
        }

        public void Update(Comments entity)
        {
            _commentsDAL.Update(entity);
        }
    }
}
