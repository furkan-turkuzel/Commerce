using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Categories : IEntity
    {
        public Categories()
        {
            Products = new List<Products>();
        }
        public int ID { get; set; }
        public int SubCategory { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }

        public virtual List<Products> Products { get; set; }
    }
}
