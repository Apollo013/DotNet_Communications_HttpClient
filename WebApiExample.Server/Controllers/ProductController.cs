using System;
using System.Web.Http;
using WebApiExample.Entities;

namespace WebApiExample.Server.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseController
    {
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var product = DB.GetById(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DB.Add(product);
                DB.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (product.Id != id)
            {
                return BadRequest("product.id does not match id parameter");
            }

            var prod = DB.GetById(id);

            if (prod == null)
            {
                return NotFound();
            }

            try
            {
                DB.Update(product);
                DB.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var prod = DB.GetById(id);

            if (prod == null)
            {
                return NotFound();
            }

            try
            {
                DB.Delete(id);
                DB.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
