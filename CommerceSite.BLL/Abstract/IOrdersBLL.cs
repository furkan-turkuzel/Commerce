using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IOrdersBLL
    {
        void Add(Orders entity);
        void Update(Orders entity);
        void Delete(Orders entity);
        Orders Get(Expression<Func<Orders, bool>> filter);
        List<Orders> GetAll(Expression<Func<Orders, bool>> filter = null);
    }
}
