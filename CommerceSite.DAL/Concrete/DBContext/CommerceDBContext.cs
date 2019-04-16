using CommerceSite.Model.Entities;
using CommerceSite.Model.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.DAL.Concrete.DBContext
{
    public class CommerceDBContext : DbContext
    {
        public CommerceDBContext() : base("Server=.;Database=CommerceDB;Integrated Security=true")
        {
            Database.SetInitializer(new DataBaseDataCreater());
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriesMapping());
            modelBuilder.Configurations.Add(new ProductsMapping());
            modelBuilder.Configurations.Add(new BlogMapping());
            modelBuilder.Configurations.Add(new CommentsMapping());
            modelBuilder.Configurations.Add(new DiscountMapping());
            modelBuilder.Configurations.Add(new CustomersMapping());
            modelBuilder.Configurations.Add(new FavoriteMapping());
            modelBuilder.Configurations.Add(new OrderDetailsMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new ScoreMapping());
            modelBuilder.Configurations.Add(new SliderMapping());
            modelBuilder.Configurations.Add(new ContactMapping());
            modelBuilder.Configurations.Add(new AboutMapping());
        }

        public class DataBaseDataCreater : CreateDatabaseIfNotExists<CommerceDBContext>
        {
            protected override void Seed(CommerceDBContext context)
            {
                base.Seed(context);
            }
        }


    }
}
