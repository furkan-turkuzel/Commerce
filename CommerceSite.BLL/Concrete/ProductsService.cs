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
    public class ProductsService : IProductsBLL
    {
        private IProductsDAL _productsDAL;

        public ProductsService(IProductsDAL productsDAL)
        {
            _productsDAL = productsDAL;
        }
        public void Add(Products entity)
        {
            _productsDAL.Add(entity);
        }

        public void Delete(Products entity)
        {
            _productsDAL.Delete(entity);
        }

        public Products Get(Expression<Func<Products, bool>> filter)
        {
            return _productsDAL.Get(filter);
        }

        public List<Products> GetAll(Expression<Func<Products, bool>> filter)
        {
            return filter == null
                ? _productsDAL.GetAll(x=>x.IsActive == true)
                : _productsDAL.GetAll(filter);
        }

        public void Update(Products entity)
        {
            _productsDAL.Update(entity);
        }
    }
}
