using CommerceSite.BLL.Abstract;
using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommerceSite.BLL.Concrete
{
    public class BasketService : IBasketBLL
    {
        private ProductsService _productService;

        public BasketService(ProductsService productService)
        {
            _productService = productService;
        }
        public void AddToCart(Basket basket, Products products)
        {
            try
            {
                AddedProduct addedProduct = basket.addedProduct.FirstOrDefault(x => x.product.ID == products.ID);

                if (addedProduct != null)
                {
                    addedProduct.Quantity++;
                }
                else
                {
                    basket.addedProduct.Add(new AddedProduct() { product = products, Quantity = 1 });
                }
                products.UnitInStock--;
                _productService.Update(products);
            }
            catch (Exception)
            {
                throw new Exception("Sepete ürün eklenemedi!!!");
            }
        }

        public void RemoveToCart(Basket basket, Products products)
        {
            try
            {
                basket.addedProduct.Remove(basket.addedProduct.FirstOrDefault(x => x.product.ID == products.ID));
                products.UnitInStock++;
                _productService.Update(products);
            }
            catch (Exception)
            {

                throw new Exception("Sepetten ürün silinemedi!!!");
            }
        }

        public Basket Get()
        {
            try
            {
                Basket currentBasket = (Basket)HttpContext.Current.Session["basket"];

                if (currentBasket == null)
                {
                    HttpContext.Current.Session["basket"] = new Basket();
                    currentBasket = (Basket)HttpContext.Current.Session["basket"];
                }
                return currentBasket;
            }
            catch (Exception)
            {
                throw new Exception("Sepet bulunamadı!!!");
            }
        }

        public List<AddedProduct> GetList(Basket basket)
        {
            return basket.addedProduct;
        }

        public void Set(Basket basket)
        {
            HttpContext.Current.Session["basket"] = basket;
        }

        public bool Exist(Products product)
        {
            Basket basket = Get();
            List<AddedProduct> products = basket.addedProduct;
            bool exist = false;

            foreach (var item in products)
            {
                if (item.product == product)
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }
    }
}
