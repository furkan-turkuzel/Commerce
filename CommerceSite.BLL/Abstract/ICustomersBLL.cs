using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface ICustomersBLL
    {
        void Add(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
        Customer Get(Expression<Func<Customer, bool>> filter);
        List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null);
    }
}
