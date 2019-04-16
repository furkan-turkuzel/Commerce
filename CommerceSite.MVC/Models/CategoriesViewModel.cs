using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceSite.MVC.Models
{
    public class CategoriesViewModel
    {
        public CategoriesViewModel()
        {
            Categories = new List<Categories>();
        }
        public List<Categories> Categories { get; set; }
        public int CurrentCategory { get; set; }
    }
}