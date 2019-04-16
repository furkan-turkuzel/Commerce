using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Products : IEntity
    {
        public Products()
        {
            OrderDetails = new List<OrderDetails>();
            Discounts = new List<Discounts>();
            Comments = new List<Comments>();
            Scores = new List<Scores>();
            Favorites = new List<Favorite>();
        }
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string Description { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsActive { get; set; }
        public virtual Categories Category { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
        public virtual List<Discounts> Discounts { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public virtual List<Scores> Scores { get; set; }
        public virtual List<Favorite> Favorites { get; set; }


    }
}
