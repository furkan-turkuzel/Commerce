using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Favorite : IEntity
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public bool IsActive { get; set; }
        public virtual Products Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
