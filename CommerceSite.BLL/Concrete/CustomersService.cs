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
    public class CustomersService : ICustomersBLL
    {
        private ICustomersDAL _customersDAL;

        public CustomersService(ICustomersDAL customersDAL)
        {
            _customersDAL = customersDAL;
        }
        public void Add(Customer entity)
        {
            _customersDAL.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _customersDAL.Delete(entity);
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            try
            {
                Customer customer = _customersDAL.Get(filter);

                return customer;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter)
        {
            return filter == null
                ? _customersDAL.GetAll(x=>x.IsActive == true)
                : _customersDAL.GetAll(filter);
        }

        public void Update(Customer entity)
        {
            _customersDAL.Update(entity);
        }
    }
}
