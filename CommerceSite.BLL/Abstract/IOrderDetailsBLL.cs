using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IOrderDetailsBLL
    {
        void Add(OrderDetails entity);
        void Update(OrderDetails entity);
        void Delete(OrderDetails entity);
        OrderDetails Get(Expression<Func<OrderDetails, bool>> filter);
        List<OrderDetails> GetAll(Expression<Func<OrderDetails, bool>> filter = null);
    }
}
