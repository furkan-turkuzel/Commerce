using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Mapping
{
    public class CommentsMapping : EntityTypeConfiguration<Comments>
    {
        public CommentsMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Product)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(true);

        }
    }
}
