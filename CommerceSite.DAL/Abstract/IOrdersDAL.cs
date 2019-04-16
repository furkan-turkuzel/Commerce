using CommerceSite.Core.DataAccess;
using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.DAL.Abstract
{
    public interface IOrdersDAL : IEntityRepositoryBase<Orders>
    {
    }
}
