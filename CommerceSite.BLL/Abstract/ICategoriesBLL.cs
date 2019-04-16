using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface ICategoriesBLL
    {
        void Add(Categories entity);
        void Update(Categories entity);
        void Delete(Categories entity);
        Categories Get(Expression<Func<Categories, bool>> filter);
        List<Categories> GetAll(Expression<Func<Categories, bool>> filter = null);
    }
}
