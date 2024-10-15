using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService) => 
            ProductService = productService;

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        [Route("Rate")]
        [HttpGet]
        //呼叫方式 https://localhost:44300/products/Rate?ProductId=jenlooper-light&Rating=3
        public ActionResult Get([FromQuery] string ProductId, 
                                [FromQuery] int Rating)
        {
            int rtncode = ProductService.AddRating(ProductId, Rating);
            if (rtncode == 0)
                return Ok();
            else
                return BadRequest();
        }

        //[HttpPatch]
        //public ActionResult Patch([FromBody] RatingRequest request)
        //{
        //    if (request?.ProductId == null)
        //        return BadRequest();

        //    ProductService.AddRating(request.ProductId, request.Rating);

        //    return Ok();
        //}

        //public class RatingRequest
        //{
        //    public string? ProductId { get; set; }
        //    public int Rating { get; set; }
        //}
    }
}
