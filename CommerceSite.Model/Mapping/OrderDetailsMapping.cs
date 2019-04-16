using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Mapping
{
    public class OrderDetailsMapping : EntityTypeConfiguration<OrderDetails>
    {
        public OrderDetailsMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.UnitPrice)
                .IsRequired();

            Property(x => x.Quantity)
                .IsRequired();

            HasRequired(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderID)
                .WillCascadeOnDelete(true);

            HasRequired(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(true);
        }
    }
}
