using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IFavoriteBLL
    {
        void Add(Favorite entity);
        void Update(Favorite entity);
        void Delete(Favorite entity);
        Favorite Get(Expression<Func<Favorite, bool>> filter);
        List<Favorite> GetAll(Expression<Func<Favorite, bool>> filter = null);
    }
}
