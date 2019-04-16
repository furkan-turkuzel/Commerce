using CommerceSite.BLL.Abstract;
using CommerceSite.Model.Entities;
using CommerceSite.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceSite.MVC.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteBLL _favoriteBLL;
        private readonly IProductsBLL _productsBLL;
        private readonly IDiscountBLL _discountBLL;
        private readonly IBasketBLL   _basketBLL;

        public FavoriteController(IFavoriteBLL favoriteBLL, IProductsBLL productsBLL, IDiscountBLL discountBLL, IBasketBLL basketBLL)
        {
            _favoriteBLL = favoriteBLL;
            _productsBLL = productsBLL;
            _discountBLL = discountBLL;
            _basketBLL   = basketBLL;
        }
        public ActionResult Index()
        {
            Customer user = (Customer)Session["user"];
            List<Favorite> favorites = _favoriteBLL.GetAll(x=>x.CustomerID == user.ID && x.IsActive == true);
            List<Discounts> discounts = _discountBLL.GetAll();

            FavoriteViewModel model = new FavoriteViewModel()
            {
                Favorites = favorites,
                Discounts = discounts
            };

            return View(model);
        }

        public ActionResult Add(int ID)
        {
            Products product = _productsBLL.Get(x => x.ID == ID);
            Customer customer = (Customer)Session["user"];
            Favorite existFavorite = _favoriteBLL.Get(x => x.ProductID == product.ID && x.CustomerID == customer.ID && x.IsActive == true);

            if (product != null && existFavorite == null)
            {
                Favorite favorite = new Favorite();

                favorite.CustomerID = customer.ID;
                favorite.ProductID = product.ID;
                favorite.IsActive = true;

                _favoriteBLL.Add(favorite);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult AddToBasket(int ID)
        {
            Favorite favorite = _favoriteBLL.Get(x => x.ID == ID);

            var basket = _basketBLL.Get();
            var product = _productsBLL.Get(x => x.ID == favorite.ProductID);
            bool productExist = _basketBLL.Exist(product);

            if (product.UnitInStock != 0)
            {
                if (!productExist)
                {
                    _basketBLL.AddToCart(basket, product);
                    _basketBLL.Set(basket);
                    ViewBag.Message = string.Format("{0} isimli ürün sepetinize başarıyla eklenmiştir.", product.ProductName);
                    ViewBag.Status = "warning";
                }
                else
                {
                    ViewBag.Message = string.Format("{0} isimli ürün zaten sepetinizde mevcut.", product.ProductName);
                    ViewBag.Status = "success";
                }
                
            }
            else
            {
                ViewBag.Message = string.Format("{0} isimli ürün stoklarda bulunmadığı için sepete eklenemedi.", product.ProductName);
                ViewBag.Status = "warning";
            }

            ProductViewModel model = (ProductViewModel)Session["model"];

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            Customer user = (Customer)Session["user"];
            Favorite favorite = _favoriteBLL.Get(x => x.ProductID == ID && x.CustomerID == user.ID);

            if (favorite != null)
            {
                _favoriteBLL.Delete(favorite);
            }
            
            return Redirect(Request.UrlReferrer.ToString());
        }


        public ActionResult DeleteFavorite(int ID)
        {
            Favorite favorite = _favoriteBLL.Get(x => x.ID == ID);

            if (favorite != null)
            {
                _favoriteBLL.Delete(favorite);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}