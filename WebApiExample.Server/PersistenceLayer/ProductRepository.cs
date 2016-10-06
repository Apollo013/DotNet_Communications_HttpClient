using WebApiExample.Entities;
using WebApiExample.Server.DataAccessLayer;

namespace WebApiExample.Server.PersistenceLayer
{
    public class ProductRepository : AbstractRepository<Product>
    {
        public ProductRepository(DataContext context) : base(context)
        { }
    }
}