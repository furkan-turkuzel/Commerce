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
    public class OrderDetailsService : IOrderDetailsBLL
    {
        private IOrderDetailsDAL _orderDetailsDAL;

        public OrderDetailsService(IOrderDetailsDAL orderDetailsDAL)
        {
            _orderDetailsDAL = orderDetailsDAL;
        }
        public void Add(OrderDetails entity)
        {
            _orderDetailsDAL.Add(entity);
        }

        public void Delete(OrderDetails entity)
        {
            _orderDetailsDAL.Delete(entity);
        }

        public OrderDetails Get(Expression<Func<OrderDetails, bool>> filter)
        {
            return _orderDetailsDAL.Get(filter);
        }

        public List<OrderDetails> GetAll(Expression<Func<OrderDetails, bool>> filter)
        {
            return filter == null
                ? _orderDetailsDAL.GetAll(x=>x.IsActive == true)
                : _orderDetailsDAL.GetAll(filter);
        }

        public void Update(OrderDetails entity)
        {
            _orderDetailsDAL.Update(entity);
        }
    }
}
