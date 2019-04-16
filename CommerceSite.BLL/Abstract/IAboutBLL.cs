using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IAboutBLL
    {
        void Add(About entity);
        void Update(About entity);
        void Delete(About entity);
        About Get(Expression<Func<About, bool>> filter);
        List<About> GetAll(Expression<Func<About, bool>> filter = null);
    }
}
