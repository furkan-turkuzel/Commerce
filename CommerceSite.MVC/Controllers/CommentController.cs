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
    public class CommentController : Controller
    {
        private readonly ICommentsBLL _commentBLL;

        public CommentController(ICommentsBLL commentBLL)
        {
            _commentBLL = commentBLL;
        }
        [HttpGet]
        public PartialViewResult Index(int ID)
        {
            List<Comments> comments = _commentBLL.GetAll(x=>x.ProductID == ID);

            CommentViewModel model = new CommentViewModel()
            {
                Comments = comments,
                ProductID = ID
            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult SentMessage(CommentViewModel model)
        {
            Customer user = null;
            if (Session["user"] != null)
            {
                user = (Customer)Session["user"];
            }

            if (model.Username == "" || model.Mail == "" || model.Writing == "")
            {
                ViewBag.Message = "Lütfen bütün alanları doldurunuz";
                return PartialView();
            }
            else
            {
                Comments comment = new Comments()
                {
                    Username = model.Username,
                    Mail = model.Mail,
                    Writing = model.Writing,
                    SentDate = DateTime.Now,
                    ProductID = model.ProductID,
                    UserID = user == null ? 0 : user.ID,
                    IsActive = true
                };

                try
                {
                    _commentBLL.Add(comment);
                    ViewBag.Message = "Mesajınız başarıyla gönderildi";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Mesaj gönderimi sırasında bir hatayla karşılaşıldı.";
                }
                return RedirectToAction("ProductDetail", "Product",new { ID = model.ProductID});

            }
        }
    }
}