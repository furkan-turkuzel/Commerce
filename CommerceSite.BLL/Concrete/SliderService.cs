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
    public class SliderService : ISliderBLL
    {
        private ISliderDAL _sliderDAL;

        public SliderService(ISliderDAL sliderDAL)
        {
            _sliderDAL = sliderDAL;
        }
        public void Add(Slider entity)
        {
            _sliderDAL.Add(entity);
        }

        public void Delete(Slider entity)
        {
            _sliderDAL.Delete(entity);
        }

        public Slider Get(Expression<Func<Slider, bool>> filter)
        {
            return _sliderDAL.Get(filter);
        }

        public List<Slider> GetAll(Expression<Func<Slider, bool>> filter)
        {
            return filter == null
                ? _sliderDAL.GetAll(x=>x.IsActive == true)
                : _sliderDAL.GetAll(filter);
        }

        public void Update(Slider entity)
        {
            _sliderDAL.Update(entity);
        }
    }
}
