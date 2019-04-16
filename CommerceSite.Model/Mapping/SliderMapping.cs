using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Mapping
{
    public class SliderMapping : EntityTypeConfiguration<Slider>
    {
        public SliderMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Image)
                .IsRequired();

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Writing)
                .IsRequired();
        }
    }
}
