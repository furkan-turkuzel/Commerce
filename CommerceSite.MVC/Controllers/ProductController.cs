using CommerceSite.BLL.Abstract;
using CommerceSite.DAL.Concrete.DBContext;
using CommerceSite.Model.Entities;
using CommerceSite.MVC.Models;
using CommerceSite.MVC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceSite.MVC.Controllers
{
    public class ProductController : Controller
    {
        CommerceDBContext db = new CommerceDBContext();
        private readonly ICategoriesBLL _categoriesBLL;
        private readonly IProductsBLL _productsBLL;
        private readonly IScoreBLL _scoreBLL;
        private readonly IDiscountBLL _discountBLL;
        private readonly IFavoriteBLL _favoriteBLL;
        private readonly ICommentsBLL _commentsBLL;
        public ProductController(IProductsBLL productsBLL, IScoreBLL scoreBLL, IDiscountBLL discountBLL, ICategoriesBLL categoriesBLL, IFavoriteBLL favoriteBLL, ICommentsBLL commentsBLL)
        {
            _productsBLL = productsBLL;
            _scoreBLL = scoreBLL;
            _discountBLL = discountBLL;
            _categoriesBLL = categoriesBLL;
            _favoriteBLL = favoriteBLL;
            _commentsBLL = commentsBLL;
        }
        [HttpGet]
        public ActionResult Products(int ID,int page = 1,int pageSize = 10)
        {
            Customer customer = (Customer)Session["user"];
            int subCategories = db.Categories.Where(x => x.ID == ID).Select(x => x.SubCategory).FirstOrDefault();
            List<CommerceSite.Model.Entities.Products> products = _productsBLL.GetAll(x=>x.CategoryID == subCategories);
            List<Scores> scores = _scoreBLL.GetAll();
            List<Discounts> discounts = _discountBLL.GetAll();

            List<Favorite> favorites = null;

            if (customer != null)
            {
                favorites = _favoriteBLL.GetAll(x => x.CustomerID == customer.ID && x.IsActive == true);
            }

            List<SelectListItem> SortBy = new List<SelectListItem>();
            SortBy.Add(new SelectListItem { Text = "Pozisyon", Value = "1" });
            SortBy.Add(new SelectListItem { Text = "Fiyat", Value = "2" });
            SortBy.Add(new SelectListItem { Text = "Reyting", Value = "3" });
            ViewBag.SortBy = SortBy;

            List<SelectListItem> PageBy = new List<SelectListItem>();
            PageBy.Add(new SelectListItem { Text = "10", Value = "1" });
            PageBy.Add(new SelectListItem { Text = "50", Value = "2" });
            PageBy.Add(new SelectListItem { Text = "100", Value = "3" });
            ViewBag.PageBy = PageBy;

            ProductViewModel model;

            if (Session["model"] == null)
            {
                model = new ProductViewModel()
                {
                    PageSize = pageSize,
                    PageCount = (int)(Math.Ceiling(products.Count / (double)pageSize)),
                    CurrentPage = page,
                    CurrentCategory = ID,
                    Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    Scores = scores,
                    Discounts = discounts,
                    Favorites = favorites
                };
            }
            else
            {
                model = (ProductViewModel)Session["model"];
                model.PageCount = (int)(Math.Ceiling(products.Count / (double)model.PageSize));
                model.CurrentPage = page;
                model.CurrentCategory = ID;
                model.Scores = scores;
                model.Discounts = discounts;
                model.Products = products.Skip((page - 1) * model.PageSize).Take(model.PageSize).ToList();
                model.Favorites = favorites;
            }
            
            Session["model"] = model;

            return View(model);
        }

        [HttpPost]
        public ActionResult Products()
        {
            var pageSize = 0;
            string filterType = null;
            string valueShowBy = null;
            string valuePageBy = null;
            ProductViewModel model = (ProductViewModel)Session["model"];

            if (Request.Form["ShowBy"] != null)
            {
                valueShowBy = Request.Form["ShowBy"].ToString();
            }
            if (Request.Form["PageBy"] != null)
            {
                valuePageBy = Request.Form["PageBy"].ToString();
            }


            if (valuePageBy != null)
            {
                if (Convert.ToInt32(valuePageBy) == 1)
                {
                    pageSize = 10;
                }
                else if (Convert.ToInt32(valuePageBy) == 2)
                {
                    pageSize = 50;
                }
                else
                {
                    pageSize = 100; ;
                }

                model.PageSize = pageSize;
                model.PageFilterID = Convert.ToInt32(valuePageBy);
            }


            if (valueShowBy != null)
            {
                if (Convert.ToInt32(valueShowBy) == 1)
                {
                    filterType = "pozisyon";
                }
                else if (Convert.ToInt32(valueShowBy) == 2)
                {
                    filterType = "fiyat";
                }
                else
                {
                    filterType = "reyting";
                }

                model.showFilter = filterType;
                model.showFilterID = Convert.ToInt32(valueShowBy);
            }

            Session["model"] = model;

            return RedirectToAction("Products", "Product", new { ID = model.CurrentCategory, page = model.CurrentPage, PageSize = model.PageSize });
        }

        public ActionResult ProductDetail(int ID)
        {
            Customer user = null;
            Favorite favorite = null;
            double totalScore = 0;
            int count = 0;

            Products product = _productsBLL.Get(x => x.ID == ID);
            Categories category = _categoriesBLL.Get(x => x.ID == product.CategoryID);
            List<Scores> scores = _scoreBLL.GetAll(x => x.ProductID == product.ID);
            Discounts discount = _discountBLL.Get(x => x.ProductID == product.ID);
            List<Comments> comments = _commentsBLL.GetAll(x=>x.ProductID == product.ID);

            if (Session["user"] != null)
            {
                user = (Customer)Session["user"];
                favorite = _favoriteBLL.Get(x => x.ProductID == product.ID && x.CustomerID == user.ID);
            }


            foreach (var item in scores)
            {
                totalScore += item.Score;
                count++;
            }

            ProductDetailViewModel model = new ProductDetailViewModel()
            {
                ID = product.ID,
                ProductName = product.ProductName,
                CategoryName = category.CategoryName,
                ProductImage = product.Image,
                UnitPrice = product.UnitPrice,
                UnitInStock = product.UnitInStock,
                Description = product.Description,
                ProductScore = Math.Ceiling(totalScore / count),
                DiscountRate = discount == null ? 0 : discount.DiscountRate,
                Comments = comments,
                IsFavorite = favorite == null ? false : true,
                AddedTime = product.AddedTime
            };
            

            return View(model);
        }


        public PartialViewResult TopRated()
        {
            ProductViewModel productModel = (ProductViewModel)Session["model"];
            int subCategories = db.Categories.Where(x => x.ID == productModel.CurrentCategory).Select(x => x.SubCategory).FirstOrDefault();

            TopRatedProductViewModel model = new TopRatedProductViewModel();
            CalculateScore calculate = new CalculateScore();
            model = calculate.TopScores(3, subCategories);

            return PartialView(model);
        }
    }
}