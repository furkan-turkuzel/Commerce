using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceSite.MVC.Models
{
    public class CommentViewModel
    {
        public List<Comments> Comments { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Writing { get; set; }
        public DateTime SentDate { get; set; }
        public int ProductID { get; set; }
    }
}