using CommerceSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Mapping
{
    public class CustomersMapping : EntityTypeConfiguration<Customer>
    {
        public CustomersMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.UserName)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName, 
                new IndexAnnotation(
                new IndexAttribute("IX_UserName", 1) { IsUnique = true}));

            Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(70)
                .IsRequired();
        }
    }
}
