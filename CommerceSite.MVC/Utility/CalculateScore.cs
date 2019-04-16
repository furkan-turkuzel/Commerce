using CommerceSite.BLL.Abstract;
using CommerceSite.BLL.Concrete;
using CommerceSite.DAL.Concrete.DBContext;
using CommerceSite.Model.Entities;
using CommerceSite.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceSite.MVC.Utility
{
    public class CalculateScore
    {
        CommerceDBContext db = new CommerceDBContext();
        public int ScoreCalculate(Products products)
        {
            int avg = 0;
            int count = 0;

            List<Scores> scores = db.Scores.ToList();

            foreach (var score in scores.Where(x=>x.ProductID == products.ID))
            {
                avg += score.Score;
                count++;
            }

            avg = avg / count;

            return avg;
        }

        public TopRatedProductViewModel TopScores(int productCount,int categoryID)
        {
            int gecici = 0;
            Products tempProduct = new Products();
            List<Scores> scores = db.Scores.ToList();
            List<Products> products = db.Products.Where(x=>x.CategoryID == categoryID).ToList();

            TopRatedProductViewModel model = new TopRatedProductViewModel();

            foreach (var p in products)
            {
                int avg = 0;
                int counter = 0;

                foreach (var s in scores.Where(x=>x.ProductID == p.ID))
                {
                    avg += s.Score;
                    counter++;
                }

                if (counter > 0)
                {
                    avg = avg / counter;
                }
                
                model.Products.Add(p);
                model.Scores.Add(avg);
            }

            for (int i = 0; i < model.Scores.Count - 1; i++)
            {
                for (int j = i; j < model.Scores.Count; j++)
                {
                    // >(büyük) işareti <(küçük ) olarak değiştirilirse büyükten küçüğe sıralanır
                    if (model.Scores[i] < model.Scores[j])
                    {
                        gecici = model.Scores[j];
                        model.Scores[j] = model.Scores[i];
                        model.Scores[i] = gecici;

                        tempProduct = model.Products[j];
                        model.Products[j] = model.Products[i];
                        model.Products[i] = tempProduct;
                    }
                }
            }

            TopRatedProductViewModel topRated = new TopRatedProductViewModel();
            topRated.Products = model.Products.Take(productCount).ToList();
            topRated.Scores = model.Scores.Take(productCount).ToList();

            return topRated;
        }
    }
}