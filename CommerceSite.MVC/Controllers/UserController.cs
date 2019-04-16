using CommerceSite.BLL.Abstract;
using CommerceSite.Model.Entities;
using CommerceSite.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CommerceSite.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICustomersBLL _customersBLL;

        public UserController(ICustomersBLL customersBLL)
        {
            _customersBLL = customersBLL;
        }
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (model.Username != null && model.Password != null)
            {
                Customer customer = _customersBLL.Get(x => x.UserName == model.Username && x.Password == model.Password);

                if (customer != null)
                {
                    FormsAuthentication.SetAuthCookie(customer.UserName, false);
                    Session["user"] = customer;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Geçersiz kullanıcı adı veya şifre";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Lütfen bütün alanları doldurunuz";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult Users()
        {
            Customer customer = (Customer)Session["user"];

            UserViewModel model = new UserViewModel()
            {
                Customer = customer
            };

            return PartialView(model);
        }

    }
}