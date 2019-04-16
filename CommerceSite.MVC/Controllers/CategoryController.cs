using CommerceSite.BLL.Abstract;
using CommerceSite.DAL.Concrete.DBContext;
using CommerceSite.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceSite.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoriesBLL _categoriesService;
        
        public CategoryController(ICategoriesBLL categoriesService)
        {
            _categoriesService = categoriesService;
        }
        
        [HttpGet]
        public PartialViewResult CategoryList()
        {
            CategoriesViewModel model = new CategoriesViewModel()
            {
                Categories = _categoriesService.GetAll(),
                CurrentCategory = Convert.ToInt32(Session["category"]) 
            };

            return PartialView(model);
        }


    }
}