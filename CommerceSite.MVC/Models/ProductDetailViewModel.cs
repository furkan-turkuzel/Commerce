using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceSite.MVC.Models
{
    public class ProductDetailViewModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string ProductImage { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string Description { get; set; }
        public double ProductScore { get; set; }
        public int DiscountRate { get; set; }
        public List<Comments> Comments { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime AddedTime { get; set; }
    }
}