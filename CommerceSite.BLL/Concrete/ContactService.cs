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
    public class ContactService : IContactBLL
    {
        private IContactDAL _contactDAL;

        public ContactService(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }
        public void Add(Contact entity)
        {
            _contactDAL.Add(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDAL.Delete(entity);
        }

        public Contact Get(Expression<Func<Contact, bool>> filter)
        {
            return _contactDAL.Get(filter);
        }

        public List<Contact> GetAll(Expression<Func<Contact, bool>> filter)
        {
            return filter == null
                ? _contactDAL.GetAll(null)
                : _contactDAL.GetAll(filter);
        }

        public void Update(Contact entity)
        {
            _contactDAL.Update(entity);
        }
    }
}
