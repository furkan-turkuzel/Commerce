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
    public class FavoriteService : IFavoriteBLL
    {
        private IFavoriteDAL _favoriteDAL;

        public FavoriteService(IFavoriteDAL favoriteDAL)
        {
            _favoriteDAL = favoriteDAL;
        }
        public void Add(Favorite entity)
        {
            _favoriteDAL.Add(entity);
        }

        public void Delete(Favorite entity)
        {
            _favoriteDAL.Delete(entity);
        }

        public Favorite Get(Expression<Func<Favorite, bool>> filter)
        {
            return _favoriteDAL.Get(filter);
        }

        public List<Favorite> GetAll(Expression<Func<Favorite, bool>> filter)
        {
            return filter == null
                ? _favoriteDAL.GetAll(x=>x.IsActive == true)
                : _favoriteDAL.GetAll(filter);
        }

        public void Update(Favorite entity)
        {
            _favoriteDAL.Update(entity);
        }
    }
}
