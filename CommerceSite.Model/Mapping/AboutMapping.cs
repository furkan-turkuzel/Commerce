using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Mapping
{
    public class AboutMapping : EntityTypeConfiguration<About>
    {
        public AboutMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Article)
                .IsRequired();
        }
    }
}
