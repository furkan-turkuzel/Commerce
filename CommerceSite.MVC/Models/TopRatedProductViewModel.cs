using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceSite.MVC.Models
{
    public class TopRatedProductViewModel
    {
        public TopRatedProductViewModel()
        {
            Products = new List<Products>();
            Scores = new List<int>();
        }

        public List<Products> Products { get; set; }
        public List<int> Scores { get; set; }
    }
}