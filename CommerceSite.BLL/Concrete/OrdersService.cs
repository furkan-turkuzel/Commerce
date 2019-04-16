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
    public class OrdersService : IOrdersBLL
    {
        private IOrdersDAL _ordersDAL;

        public OrdersService(IOrdersDAL ordersDAL)
        {
            _ordersDAL = ordersDAL;
        }
        public void Add(Orders entity)
        {
            _ordersDAL.Add(entity);
        }

        public void Delete(Orders entity)
        {
            _ordersDAL.Delete(entity);
        }

        public Orders Get(Expression<Func<Orders, bool>> filter)
        {
            return _ordersDAL.Get(filter);
        }

        public List<Orders> GetAll(Expression<Func<Orders, bool>> filter)
        {
            return filter == null
                ? _ordersDAL.GetAll(x=>x.IsActive == true)
                : _ordersDAL.GetAll(filter);
        }

        public void Update(Orders entity)
        {
            _ordersDAL.Update(entity);
        }
    }
}
