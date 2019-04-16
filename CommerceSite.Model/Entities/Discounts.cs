using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Discounts : IEntity
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int DiscountRate { get; set; }
        public bool IsActive { get; set; }
        public virtual Products Product { get; set; }
    }
}
