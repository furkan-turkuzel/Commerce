using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface ISliderBLL
    {
        void Add(Slider entity);
        void Update(Slider entity);
        void Delete(Slider entity);
        Slider Get(Expression<Func<Slider, bool>> filter);
        List<Slider> GetAll(Expression<Func<Slider, bool>> filter = null);
    }
}
