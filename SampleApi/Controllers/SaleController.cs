using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Model;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            products.Add(product);
            return Ok(products);    
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var prd = products.Where(x => x.Id == product.Id).FirstOrDefault();
            if(prd == null)
            {
                return NotFound();
            }
            else
            {
                prd.Name = product.Name;
                prd.Price = product.Price;
                return Ok(prd);
            }
        }
    }
}
