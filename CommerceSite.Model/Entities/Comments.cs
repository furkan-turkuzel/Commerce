using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Comments : IEntity
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Writing { get; set; }
        public int UserID { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Products Product { get; set; }

    }
}
