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
    public class AboutService : IAboutBLL
    {
        private IAboutDAL _aboutDAL;

        public AboutService(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }
        public void Add(About entity)
        {
            _aboutDAL.Add(entity);
        }

        public void Delete(About entity)
        {
            _aboutDAL.Delete(entity);
        }

        public About Get(Expression<Func<About, bool>> filter)
        {
            return _aboutDAL.Get(filter);
        }

        public List<About> GetAll(Expression<Func<About, bool>> filter)
        {
            return filter == null
                ? _aboutDAL.GetAll(null)
                : _aboutDAL.GetAll(filter);
        }

        public void Update(About entity)
        {
            _aboutDAL.Update(entity);
        }
    }
}
