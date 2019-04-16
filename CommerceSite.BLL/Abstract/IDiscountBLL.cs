using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IDiscountBLL
    {
        void Add(Discounts entity);
        void Update(Discounts entity);
        void Delete(Discounts entity);
        Discounts Get(Expression<Func<Discounts, bool>> filter);
        List<Discounts> GetAll(Expression<Func<Discounts, bool>> filter = null);
    }
}
