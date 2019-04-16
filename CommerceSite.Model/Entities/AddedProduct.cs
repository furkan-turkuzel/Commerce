using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class AddedProduct : IEntity
    {
        public Products product { get; set; }
        public int Quantity { get; set; }
    }
}
