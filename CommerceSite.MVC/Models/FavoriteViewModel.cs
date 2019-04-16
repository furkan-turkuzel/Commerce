using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceSite.MVC.Models
{
    public class FavoriteViewModel
    {
        public List<Favorite> Favorites { get; set; }
        public List<Discounts> Discounts { get; set; }
    }
}