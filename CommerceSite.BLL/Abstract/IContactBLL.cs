using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IContactBLL
    {
        void Add(Contact entity);
        void Update(Contact entity);
        void Delete(Contact entity);
        Contact Get(Expression<Func<Contact, bool>> filter);
        List<Contact> GetAll(Expression<Func<Contact, bool>> filter = null);
    }
}
