using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Orders : IEntity
    {
        public Orders()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public bool IsStore { get; set; }
        public bool IsProcessing { get; set; }
        public bool IsDone { get; set; }
        public bool IsActive { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
