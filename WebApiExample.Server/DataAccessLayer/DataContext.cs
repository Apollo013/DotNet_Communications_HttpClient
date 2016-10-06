using System.Data.Entity;
using WebApiExample.Entities;

namespace WebApiExample.Server.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public DataContext() : base("name = LocalConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}