using CommerceSite.BLL.Abstract;
using CommerceSite.DAL.Concrete.DBContext;
using CommerceSite.Model.Entities;
using CommerceSite.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceSite.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ISliderBLL _sliderBLL;
        private IBLogBLL _blogBLL;
        private IAboutBLL _aboutBLL;
        private IContactBLL _contactBLL;
        private IProductsBLL _productBLL;

        public HomeController(ISliderBLL sliderBLL, IBLogBLL bLogBLL, IAboutBLL aboutBLL, IContactBLL contactBLL, IProductsBLL productBLL)
        {
            _sliderBLL = sliderBLL;
            _blogBLL = bLogBLL;
            _aboutBLL = aboutBLL;
            _contactBLL = contactBLL;
            _productBLL = productBLL;
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Blog()
        {

            return View();
        }

        public ActionResult About()
        {
            return View(); 
        }

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult Slider()
        {
            SliderViewModel model = new SliderViewModel()
            {
                Slider = _sliderBLL.GetAll()
            };

            return PartialView(model);
        }

        public PartialViewResult NewCollection()
        {
            List<Products> products = _productBLL.GetAll();
            List<Products> newCollection = new List<Products>();
            DateTime dateTime = products[0].AddedTime; 

            for (int i = 0; i < products.Count-1; i++)
            {
                for (int j = i; j < products.Count; j++)
                {
                    if (products[i].AddedTime > products[j].AddedTime)
                    {
                        dateTime = products[j].AddedTime;
                        products[j].AddedTime = products[i].AddedTime;
                        products[i].AddedTime = dateTime;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                newCollection.Add(products[i]);
            }

            IndexViewModel model = new IndexViewModel()
            {
                NewCollection = newCollection
            };

            return PartialView(model);
        }



        public ActionResult AddProduct()
        {
            for (int i = 0; i < 20; i++)
            {
                Products product = new Products();
                product.CategoryID = 1;
                product.ProductName = "Dizüstü bilgisayar";
                product.Image = "~/Content/img/laptop.jpeg";
                product.UnitPrice = 2600;
                product.UnitInStock = 100;
                product.IsActive = true;
                product.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product.AddedTime = DateTime.Now;
                _productBLL.Add(product);


                Products product2 = new Products();
                product2.CategoryID = 1;
                product2.ProductName = "Tablet";
                product2.Image = "~/Content/img/tablet.jpg";
                product2.UnitPrice = 1200;
                product2.UnitInStock = 100;
                product2.IsActive = true;
                product2.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product2.AddedTime = DateTime.Now;
                _productBLL.Add(product2);


                Products product3 = new Products();
                product3.CategoryID = 1;
                product3.ProductName = "Masaüstü Bilgisayar";
                product3.Image = "~/Content/img/bilgisayar.jpg";
                product3.UnitPrice = 2200;
                product3.UnitInStock = 100;
                product3.IsActive = true;
                product3.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product3.AddedTime = DateTime.Now;
                _productBLL.Add(product3);


                Products product4 = new Products();
                product4.CategoryID = 1;
                product4.ProductName = "Oyuncu Özel";
                product4.Image = "~/Content/img/oyuncu-özel.jpg";
                product4.UnitPrice = 1400;
                product4.UnitInStock = 100;
                product4.IsActive = true;
                product4.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product4.AddedTime = DateTime.Now;
                _productBLL.Add(product4);


                Products product5 = new Products();
                product5.CategoryID = 1;
                product5.ProductName = "Veri Depolama";
                product5.Image = "~/Content/img/harddisk.jpg";
                product5.UnitPrice = 300;
                product5.UnitInStock = 100;
                product5.IsActive = true;
                product5.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product5.AddedTime = DateTime.Now;
                _productBLL.Add(product5);


                Products product6 = new Products();
                product6.CategoryID = 1;
                product6.ProductName = "Bilgisayar Bileşenleri";
                product6.Image = "~/Content/img/bilgisayar-bileşen.jpg";
                product6.UnitPrice = 1300;
                product6.UnitInStock = 100;
                product6.IsActive = true;
                product6.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product6.AddedTime = DateTime.Now;
                _productBLL.Add(product6);


                Products product7 = new Products();
                product7.CategoryID = 1;
                product7.ProductName = "Çevre Birimleri";
                product7.Image = "~/Content/img/çevre-birim.jpg";
                product7.UnitPrice = 100;
                product7.UnitInStock = 100;
                product7.IsActive = true;
                product7.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product7.AddedTime = DateTime.Now;
                _productBLL.Add(product7);


                Products product8 = new Products();
                product8.CategoryID = 1;
                product8.ProductName = "Bilgisayar Bileşenleri";
                product8.Image = "~/Content/img/kulaklık.jpeg";
                product8.UnitPrice = 250;
                product8.UnitInStock = 100;
                product8.IsActive = true;
                product8.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product8.AddedTime = DateTime.Now;
                _productBLL.Add(product8);


                Products product9 = new Products();
                product9.CategoryID = 3;
                product9.ProductName = "Lazer Yazıcılar";
                product9.Image = "~/Content/img/lazer-yazici.jpg";
                product9.UnitPrice = 850;
                product9.UnitInStock = 100;
                product9.IsActive = true;
                product9.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product9.AddedTime = DateTime.Now;
                _productBLL.Add(product9);



                Products product11 = new Products();
                product11.CategoryID = 3;
                product11.ProductName = "Tarayıcılar";
                product11.Image = "~/Content/img/tarayıcı.jpg";
                product11.UnitPrice = 550;
                product11.UnitInStock = 100;
                product11.IsActive = true;
                product11.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product11.AddedTime = DateTime.Now;
                _productBLL.Add(product11);


                Products product12 = new Products();
                product12.CategoryID = 3;
                product12.ProductName = "Tanklı Yazıcılar";
                product12.Image = "~/Content/img/tanklı-yazıcı.jpg";
                product12.UnitPrice = 3400;
                product12.UnitInStock = 100;
                product12.IsActive = true;
                product12.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product12.AddedTime = DateTime.Now;
                _productBLL.Add(product12);


                Products product13 = new Products();
                product13.CategoryID = 3;
                product13.ProductName = "Projeksiyon Sistemleri";
                product13.Image = "~/Content/img/projeksiyon.jpg";
                product13.UnitPrice = 2200;
                product13.UnitInStock = 100;
                product13.IsActive = true;
                product13.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product13.AddedTime = DateTime.Now;
                _productBLL.Add(product13);


                Products product14 = new Products();
                product14.CategoryID = 2;
                product14.ProductName = "Cep Telefonu";
                product14.Image = "~/Content/img/telefon.jpg";
                product14.UnitPrice = 2400;
                product14.UnitInStock = 100;
                product14.IsActive = true;
                product14.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product14.AddedTime = DateTime.Now;
                _productBLL.Add(product14);


                Products product15 = new Products();
                product15.CategoryID = 2;
                product15.ProductName = "Cep Telefonu Aksesuarı";
                product15.Image = "~/Content/img/telefon-aksesuar-.jpg";
                product15.UnitPrice = 100;
                product15.UnitInStock = 100;
                product15.IsActive = true;
                product15.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product15.AddedTime = DateTime.Now;
                _productBLL.Add(product15);


                Products product16 = new Products();
                product16.CategoryID = 2;
                product16.ProductName = "Akıllı Saatler";
                product16.Image = "~/Content/img/akıllı-saat.jpg";
                product16.UnitPrice = 700;
                product16.UnitInStock = 100;
                product16.IsActive = true;
                product16.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product16.AddedTime = DateTime.Now;
                _productBLL.Add(product16);


                Products product17 = new Products();
                product17.CategoryID = 2;
                product17.ProductName = "Bluetooth Kulaklık";
                product17.Image = "~/Content/img/bluetooth-kulaklık.jpg";
                product17.UnitPrice = 300;
                product17.UnitInStock = 100;
                product17.IsActive = true;
                product17.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product17.AddedTime = DateTime.Now;
                _productBLL.Add(product17);


                Products product18 = new Products();
                product18.CategoryID = 2;
                product18.ProductName = "Kılıf ve Ekran Koruyucular";
                product18.Image = "~/Content/img/telefon-kılıf.jpg";
                product18.UnitPrice = 50;
                product18.UnitInStock = 100;
                product18.IsActive = true;
                product18.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product18.AddedTime = DateTime.Now;
                _productBLL.Add(product18);


                Products product19 = new Products();
                product19.CategoryID = 4;
                product19.ProductName = "Güvenlik";
                product19.Image = "~/Content/img/kamera_sistemleri.jpg";
                product19.UnitPrice = 450;
                product19.UnitInStock = 100;
                product19.IsActive = true;
                product19.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product19.AddedTime = DateTime.Now;
                _productBLL.Add(product19);


                Products product20 = new Products();
                product20.CategoryID = 4;
                product20.ProductName = "Ev Kontrol";
                product20.Image = "~/Content/img/akıllı-ev.jpg";
                product20.UnitPrice = 2500;
                product20.UnitInStock = 100;
                product20.IsActive = true;
                product20.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product20.AddedTime = DateTime.Now;
                _productBLL.Add(product20);


                Products product21 = new Products();
                product21.CategoryID = 4;
                product21.ProductName = "Ev Aletleri";
                product21.Image = "~/Content/img/ev-alet.jpg";
                product21.UnitPrice = 3500;
                product21.UnitInStock = 100;
                product21.IsActive = true;
                product21.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product21.AddedTime = DateTime.Now;
                _productBLL.Add(product21);


                Products product22 = new Products();
                product22.CategoryID = 4;
                product22.ProductName = "Eğlence";
                product22.Image = "~/Content/img/smart-tv.jpg";
                product22.UnitPrice = 5000;
                product22.UnitInStock = 100;
                product22.IsActive = true;
                product22.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product22.AddedTime = DateTime.Now;
                _productBLL.Add(product22);


                Products product23 = new Products();
                product23.CategoryID = 4;
                product23.ProductName = "Yaşam";
                product23.Image = "~/Content/img/akıllı-gözlük.jpg";
                product23.UnitPrice = 2500;
                product23.UnitInStock = 100;
                product23.IsActive = true;
                product23.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product23.AddedTime = DateTime.Now;
                _productBLL.Add(product23);

                Products product24 = new Products();
                product24.CategoryID = 6;
                product24.ProductName = "Televizyon";
                product24.Image = "~/Content/img/tv.jpg";
                product24.UnitPrice = 2000;
                product24.UnitInStock = 100;
                product24.IsActive = true;
                product24.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product24.AddedTime = DateTime.Now;
                _productBLL.Add(product24);


                Products product25 = new Products();
                product25.CategoryID = 6;
                product25.ProductName = "Ev Sinema Sistemleri";
                product25.Image = "~/Content/img/ev-sinema.jpg";
                product25.UnitPrice = 3200;
                product25.UnitInStock = 100;
                product25.IsActive = true;
                product25.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product25.AddedTime = DateTime.Now;
                _productBLL.Add(product25);


                Products product26 = new Products();
                product26.CategoryID = 6;
                product26.ProductName = "Müzik Sistemleri";
                product26.Image = "~/Content/img/müzik-sistem.jpg";
                product26.UnitPrice = 1800;
                product26.UnitInStock = 100;
                product26.IsActive = true;
                product26.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product26.AddedTime = DateTime.Now;
                _productBLL.Add(product26);


                Products product27 = new Products();
                product27.CategoryID = 6;
                product27.ProductName = "Uydu Alıcıları";
                product27.Image = "~/Content/img/uydu-alıcısı.jpg";
                product27.UnitPrice = 400;
                product27.UnitInStock = 100;
                product27.IsActive = true;
                product27.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product27.AddedTime = DateTime.Now;
                _productBLL.Add(product27);


                Products product28 = new Products();
                product28.CategoryID = 8;
                product28.ProductName = "Çamaşır Makinesi";
                product28.Image = "~/Content/img/çamaşır makinesi.jpg";
                product28.UnitPrice = 2400;
                product28.UnitInStock = 100;
                product28.IsActive = true;
                product28.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product28.AddedTime = DateTime.Now;
                _productBLL.Add(product28);


                Products product29 = new Products();
                product29.CategoryID = 8;
                product29.ProductName = "Buzdolabı";
                product29.Image = "~/Content/img/buzdolabı.jpg";
                product29.UnitPrice = 2700;
                product29.UnitInStock = 100;
                product29.IsActive = true;
                product29.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product29.AddedTime = DateTime.Now;
                _productBLL.Add(product29);


                Products product30 = new Products();
                product30.CategoryID = 8;
                product30.ProductName = "Bulaşık Makinesi";
                product30.Image = "~/Content/img/bulaşık-makinesi.jpg";
                product30.UnitPrice = 1900;
                product30.UnitInStock = 100;
                product30.IsActive = true;
                product30.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product30.AddedTime = DateTime.Now;
                _productBLL.Add(product30);



                Products product31 = new Products();
                product31.CategoryID = 8;
                product31.ProductName = "Fırınlar";
                product31.Image = "~/Content/img/fırın.jpg";
                product31.UnitPrice = 1200;
                product31.UnitInStock = 100;
                product31.IsActive = true;
                product31.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product31.AddedTime = DateTime.Now;
                _productBLL.Add(product31);


                Products product32 = new Products();
                product32.CategoryID = 8;
                product32.ProductName = "Sebiller";
                product32.Image = "~/Content/img/sebil.jpg";
                product32.UnitPrice = 1100;
                product32.UnitInStock = 100;
                product32.IsActive = true;
                product32.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product32.AddedTime = DateTime.Now;
                _productBLL.Add(product32);


                Products product33 = new Products();
                product33.CategoryID = 9;
                product33.ProductName = "Elektrikli Mutfak Aletleri";
                product33.Image = "~/Content/img/elektrikli-mutfak.jpg";
                product33.UnitPrice = 760;
                product33.UnitInStock = 100;
                product33.IsActive = true;
                product33.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product33.AddedTime = DateTime.Now;
                _productBLL.Add(product33);


                Products product34 = new Products();
                product34.CategoryID = 9;
                product34.ProductName = "Süpürgeler";
                product34.Image = "~/Content/img/süpürge.jpg";
                product34.UnitPrice = 1260;
                product34.UnitInStock = 100;
                product34.IsActive = true;
                product34.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product34.AddedTime = DateTime.Now;
                _productBLL.Add(product34);


                Products product35 = new Products();
                product35.CategoryID = 9;
                product35.ProductName = "Ütüler";
                product35.Image = "~/Content/img/ütü.jpg";
                product35.UnitPrice = 540;
                product35.UnitInStock = 100;
                product35.IsActive = true;
                product35.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product35.AddedTime = DateTime.Now;
                _productBLL.Add(product35);


                Products product36 = new Products();
                product36.CategoryID = 9;
                product36.ProductName = "Kişisel Bakım Aletleri";
                product36.Image = "~/Content/img/traş-makinesi.jpg";
                product36.UnitPrice = 500;
                product36.UnitInStock = 100;
                product36.IsActive = true;
                product36.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product36.AddedTime = DateTime.Now;
                _productBLL.Add(product36);


                Products product37 = new Products();
                product37.CategoryID = 10;
                product37.ProductName = "Dijital Fotoğraf Makinesi";
                product37.Image = "~/Content/img/foto-makine.jpg";
                product37.UnitPrice = 2500;
                product37.UnitInStock = 100;
                product37.IsActive = true;
                product37.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product37.AddedTime = DateTime.Now;
                _productBLL.Add(product37);


                Products product38 = new Products();
                product38.CategoryID = 10;
                product38.ProductName = "Video Kameralar";
                product38.Image = "~/Content/img/kamera.jpg";
                product38.UnitPrice = 3700;
                product38.UnitInStock = 100;
                product38.IsActive = true;
                product38.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product38.AddedTime = DateTime.Now;
                _productBLL.Add(product38);


                Products product39 = new Products();
                product39.CategoryID = 10;
                product39.ProductName = "Aksesuarlar";
                product39.Image = "~/Content/img/lens.jpg";
                product39.UnitPrice = 1300;
                product39.UnitInStock = 100;
                product39.IsActive = true;
                product39.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product39.AddedTime = DateTime.Now;
                _productBLL.Add(product39);

                Products product40 = new Products();
                product40.CategoryID = 11;
                product40.ProductName = "Klimalar";
                product40.Image = "~/Content/img/klima.jpg";
                product40.UnitPrice = 1900;
                product40.UnitInStock = 100;
                product40.IsActive = true;
                product40.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product40.AddedTime = DateTime.Now;
                _productBLL.Add(product40);


                Products product41 = new Products();
                product41.CategoryID = 11;
                product41.ProductName = "Sobalar ve Isıtıcılar";
                product41.Image = "~/Content/img/Soba.jpg";
                product41.UnitPrice = 1400;
                product41.UnitInStock = 100;
                product41.IsActive = true;
                product41.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product41.AddedTime = DateTime.Now;
                _productBLL.Add(product41);


                Products product42 = new Products();
                product42.CategoryID = 11;
                product42.ProductName = "Kombiler";
                product42.Image = "~/Content/img/şofben.jpg";
                product42.UnitPrice = 5500;
                product42.UnitInStock = 100;
                product42.IsActive = true;
                product42.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product42.AddedTime = DateTime.Now;
                _productBLL.Add(product42);


                Products product43 = new Products();
                product43.CategoryID = 11;
                product43.ProductName = "Şofbenler";
                product43.Image = "~/Content/img/şofben.jpg";
                product43.UnitPrice = 2500;
                product43.UnitInStock = 100;
                product43.IsActive = true;
                product43.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product43.AddedTime = DateTime.Now;
                _productBLL.Add(product43);


                Products product44 = new Products();
                product44.CategoryID = 12;
                product44.ProductName = "Playstation 4";
                product44.Image = "~/Content/img/oyun-konsol.jpg";
                product44.UnitPrice = 2100;
                product44.UnitInStock = 100;
                product44.IsActive = true;
                product44.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product44.AddedTime = DateTime.Now;
                _productBLL.Add(product44);


                Products product45 = new Products();
                product45.CategoryID = 12;
                product45.ProductName = "Playstation 3";
                product45.Image = "~/Content/img/oyun-konsol.jpg";
                product45.UnitPrice = 1300;
                product45.UnitInStock = 100;
                product45.IsActive = true;
                product45.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product45.AddedTime = DateTime.Now;
                _productBLL.Add(product45);


                Products product46 = new Products();
                product46.CategoryID = 12;
                product46.ProductName = "XBox 360";
                product46.Image = "~/Content/img/xbox.jpg";
                product46.UnitPrice = 1500;
                product46.UnitInStock = 100;
                product46.IsActive = true;
                product46.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product46.AddedTime = DateTime.Now;
                _productBLL.Add(product46);


                Products product47 = new Products();
                product47.CategoryID = 12;
                product47.ProductName = "XBox One";
                product47.Image = "~/Content/img/xbox.jpg";
                product47.UnitPrice = 3500;
                product47.UnitInStock = 100;
                product47.IsActive = true;
                product47.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor scelerisque neque, vel pulvinar nisl. Cras in fringilla arcu. Fusce efficitur bibendum justo sed ornare. Praesent non nibh quis felis pellentesque tincidunt. Maecenas porta commodo metus, quis interdum urna fermentum ac. Quisque non laoreet justo. Aliquam molestie varius bibendum. Nullam nunc neque, dictum et vulputate et, faucibus ac mi. Quisque varius tellus a elit faucibus consectetur. Sed commodo, erat in vehicula placerat, mi sem posuere nisl, quis hendrerit arcu metus et nisl. Maecenas venenatis, felis sed venenatis sollicitudin, diam dui cursus justo, eget facilisis libero magna egestas tellus. Aliquam rutrum eros lectus. Donec id nisi odio. Quisque eu gravida nunc. Aliquam erat volutpat.";
                product47.AddedTime = DateTime.Now;
                _productBLL.Add(product47);
            }

            return View();
        }

    }
}