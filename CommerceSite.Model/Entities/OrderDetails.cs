using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class OrderDetails : IEntity
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }

    }
}
