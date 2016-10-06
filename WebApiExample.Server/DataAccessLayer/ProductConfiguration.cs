using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using WebApiExample.Entities;

namespace WebApiExample.Server.DataAccessLayer
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            // Primary Key
            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Fields
            Property(e => e.Name).IsRequired().IsVariableLength().HasMaxLength(40);
            Property(e => e.Category).IsRequired().IsVariableLength().HasMaxLength(40);
            Property(e => e.Price).IsRequired();

            // Indexes
            Property(e => e.Name).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IDX_ProductName") { IsUnique = true }));

            // Table
            ToTable("Products", "Products");
        }
    }
}