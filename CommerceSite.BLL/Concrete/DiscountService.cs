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
    public class DiscountService : IDiscountBLL
    {
        private IDiscountDAL _discountDAL;

        public DiscountService(IDiscountDAL discountDAL)
        {
            _discountDAL = discountDAL;
        }
        public void Add(Discounts entity)
        {
            _discountDAL.Add(entity);
        }

        public void Delete(Discounts entity)
        {
            _discountDAL.Delete(entity);
        }

        public Discounts Get(Expression<Func<Discounts, bool>> filter)
        {
            return _discountDAL.Get(filter);
        }

        public List<Discounts> GetAll(Expression<Func<Discounts, bool>> filter)
        {
            return filter == null
                ? _discountDAL.GetAll(x=>x.IsActive == true)
                : _discountDAL.GetAll(filter);
        }

        public void Update(Discounts entity)
        {
            _discountDAL.Update(entity);
        }
    }
}
