using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IBLogBLL
    {
        void Add(Blog entity);
        void Update(Blog entity);
        void Delete(Blog entity);
        Blog Get(Expression<Func<Blog, bool>> filter);
        List<Blog> GetAll(Expression<Func<Blog, bool>> filter = null);
    }
}
