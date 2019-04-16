using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceSite.MVC.Models
{
    public class ProductViewModel
    {
        public List<Products> Products { get; set; }
        public List<Scores> Scores { get; set; }
        public List<Discounts> Discounts { get; set; }
        public List<Favorite> Favorites { get; set; }
        public int CurrentCategory { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int PageFilterID { get; set; }
        public string showFilter { get; set; }
        public int showFilterID { get; set; }

    }
}