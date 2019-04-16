using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceSite.MVC.Models
{
    public class IndexViewModel
    {
        public List<Products> NewCollection { get; set; }
        public List<Products> Opportunity { get; set; }
        public List<Products> HighestScores { get; set; }
        public List<Products> BestSellers { get; set; }
    }
}