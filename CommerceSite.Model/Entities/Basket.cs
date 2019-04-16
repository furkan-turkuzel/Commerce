using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Basket : IEntity
    {
        public Basket()
        {
            addedProduct = new List<AddedProduct>();
        }
        public List<AddedProduct> addedProduct { get; set; }

        public decimal total
        {
            get
            {
                return addedProduct.Sum(x => x.product.UnitPrice * x.Quantity);
            }
        }
    }
}
