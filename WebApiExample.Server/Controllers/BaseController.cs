using System.Web.Http;
using WebApiExample.Server.PersistenceLayer;

namespace WebApiExample.Server.Controllers
{
    public class BaseController : ApiController
    {
        private ProductRepository _db;
        protected ProductRepository DB
        {
            get
            {
                if (_db == null)
                {
                    _db = new ProductRepository(new DataAccessLayer.DataContext());
                }
                return _db;
            }
        }
    }
}