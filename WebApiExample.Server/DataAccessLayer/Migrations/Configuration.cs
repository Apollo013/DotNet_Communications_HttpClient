namespace WebApiExample.Server.DataAccessLayer.Migrations
{
    using Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiExample.Server.DataAccessLayer.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataAccessLayer\Migrations";
        }

        protected override void Seed(WebApiExample.Server.DataAccessLayer.DataContext context)
        {
            context.Products.AddOrUpdate(
                p => p.Name,
                new Product() { Name = "Nike Runner", Category = "Footwear", Price = 1000.99M },
                new Product() { Name = "Addidas Runner", Category = "Footwear", Price = 10001.00M },
                new Product() { Name = "Lee Denim Shirt", Category = "Shirts", Price = 100.00M },
                new Product() { Name = "Ralph Lauren Shirt", Category = "Shirts", Price = 150.99M },
                new Product() { Name = "Levi Jeans", Category = "Trousers", Price = 150.99M },
                new Product() { Name = "Hugo Boss Jacket", Category = "Jackets", Price = 150.99M }
            );
        }
    }
}
