using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IScoreBLL
    {
        void Add(Scores entity);
        void Update(Scores entity);
        void Delete(Scores entity);
        Scores Get(Expression<Func<Scores, bool>> filter);
        List<Scores> GetAll(Expression<Func<Scores, bool>> filter = null);
    }
}
