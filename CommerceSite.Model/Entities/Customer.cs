using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Customer : IEntity
    {
        public Customer()
        {
            Orders = new List<Orders>();
            Comments = new List<Comments>();
            Scores = new List<Scores>();
            Favorites = new List<Favorite>();
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Birth { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Orders> Orders { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public virtual List<Scores> Scores { get; set; }
        public virtual List<Favorite> Favorites { get; set; }

    }
}
