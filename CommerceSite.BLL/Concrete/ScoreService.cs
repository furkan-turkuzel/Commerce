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
    public class ScoreService : IScoreBLL
    {
        private IScoreDAL _scoreDAL;

        public ScoreService(IScoreDAL scoreDAL)
        {
            _scoreDAL = scoreDAL;
        }
        public void Add(Scores entity)
        {
            _scoreDAL.Add(entity);
        }

        public void Delete(Scores entity)
        {
            _scoreDAL.Delete(entity);
        }

        public Scores Get(Expression<Func<Scores, bool>> filter)
        {
            return _scoreDAL.Get(filter);
        }

        public List<Scores> GetAll(Expression<Func<Scores, bool>> filter)
        {
            return filter == null
                ? _scoreDAL.GetAll(x=>x.IsActive == true)
                : _scoreDAL.GetAll(filter);
        }

        public void Update(Scores entity)
        {
            _scoreDAL.Update(entity);
        }
    }
}
