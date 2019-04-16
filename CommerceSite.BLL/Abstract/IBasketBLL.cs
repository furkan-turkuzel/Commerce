using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.BLL.Abstract
{
    public interface IBasketBLL
    {
        void AddToCart(Basket basket, Products products);
        void RemoveToCart(Basket basket, Products products);
        List<AddedProduct> GetList(Basket basket);
        Basket Get();
        void Set(Basket basket);
        bool Exist(Products product);
    }
}
