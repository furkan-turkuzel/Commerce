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
    public class BasketController : Controller
    {
        private IBasketBLL _basketBLL;
        private IProductsBLL _productsBLL;
        private IDiscountBLL _discountBLL;

        public BasketController(IBasketBLL basketBLL, IProductsBLL productsBLL, IDiscountBLL discountBLL)
        {
            _basketBLL   = basketBLL;
            _productsBLL = productsBLL;
            _discountBLL = discountBLL;
        }

        public ActionResult Index()
        {
            Basket basket = _basketBLL.Get();
            List<Discounts> discounts = _discountBLL.GetAll();

            BasketViewModel model = new BasketViewModel()
            {
                Basket = basket,
                Discounts = discounts
            };

            return View(model);
        }
        public ActionResult AddToBasket(int ID)
        {
            var basket = _basketBLL.Get();
            var product = _productsBLL.Get(x=>x.ID == ID);

            if (product.UnitInStock != 0)
            {
                _basketBLL.AddToCart(basket, product);
                _basketBLL.Set(basket);
                ViewBag.Message = string.Format("{0} isimli ürün sepetinize başarıyla eklenmiştir.", product.ProductName);
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Message = string.Format("{0} isimli ürün stoklarda bulunmadığı için sepete eklenemedi.", product.ProductName);
                ViewBag.Status = "warning";
            }

            ProductViewModel model = (ProductViewModel)Session["model"];

            return RedirectToAction("Products","Product", new { ID = model.CurrentCategory, page = model.CurrentPage, PageSize = model.PageSize });
        }

        public PartialViewResult Basket()
        {
            var basket = _basketBLL.Get();

            BasketSummaryViewModel model = new BasketSummaryViewModel()
            {
                Basket = basket
            };

            return PartialView(model);
        }

        public ActionResult RemoveToBasket(int ID)
        {
            var basket = _basketBLL.Get();
            var product = _productsBLL.Get(x=>x.ID == ID);

            _basketBLL.RemoveToCart(basket, product);
            _basketBLL.Set(basket);

            ProductViewModel model = (ProductViewModel)Session["model"];

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}