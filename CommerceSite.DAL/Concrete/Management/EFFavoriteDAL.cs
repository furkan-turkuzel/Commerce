using CommerceSite.Core.DataAccess.EntityFramework;
using CommerceSite.DAL.Abstract;
using CommerceSite.DAL.Concrete.DBContext;
using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.DAL.Concrete.Management
{
    public class EFFavoriteDAL : EFEntityRepositoryBase<CommerceDBContext, Favorite>,IFavoriteDAL
    {
    }
}
