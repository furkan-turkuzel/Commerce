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
    public class BlogService : IBLogBLL
    {
        private IBlogDAL _blogDAL;

        public BlogService(IBlogDAL blogDAL)
        {
            _blogDAL = blogDAL;
        }
        public void Add(Blog entity)
        {
            _blogDAL.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDAL.Delete(entity);
        }

        public Blog Get(Expression<Func<Blog, bool>> filter)
        {
            return _blogDAL.Get(filter);
        }

        public List<Blog> GetAll(Expression<Func<Blog, bool>> filter)
        {
            return filter == null
                ? _blogDAL.GetAll(null)
                : _blogDAL.GetAll(filter);
        }

        public void Update(Blog entity)
        {
            _blogDAL.Update(entity);
        }
    }
}
