using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface ICommentsBLL
    {
        void Add(Comments entity);
        void Update(Comments entity);
        void Delete(Comments entity);
        Comments Get(Expression<Func<Comments, bool>> filter);
        List<Comments> GetAll(Expression<Func<Comments, bool>> filter = null);
    }
}
