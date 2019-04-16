using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IProductsBLL
    {
        void Add(Products entity);
        void Update(Products entity);
        void Delete(Products entity);
        Products Get(Expression<Func<Products, bool>> filter);
        List<Products> GetAll(Expression<Func<Products, bool>> filter = null);
    }
}
