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
    public class CategoriesService : ICategoriesBLL
    {
        private ICategoriesDAL _categoriesDAL;

        public CategoriesService(ICategoriesDAL categoriesDAL)
        {
            _categoriesDAL = categoriesDAL;
        }
        public void Add(Categories entity)
        {
            _categoriesDAL.Add(entity);
        }

        public void Delete(Categories entity)
        {
            _categoriesDAL.Delete(entity);
        }

        public Categories Get(Expression<Func<Categories, bool>> filter)
        {
            return _categoriesDAL.Get(filter);
        }

        public List<Categories> GetAll(Expression<Func<Categories, bool>> filter)
        {
            return filter == null
                ? _categoriesDAL.GetAll(x=>x.IsActive == true)
                : _categoriesDAL.GetAll(filter);
        }

        public void Update(Categories entity)
        {
            _categoriesDAL.Update(entity);
        }
    }
}
