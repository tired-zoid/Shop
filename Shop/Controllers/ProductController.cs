
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.Entities;
using Shop.Interfaces;
using System.Linq;

namespace Shop.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        IDbService _dbService;
        IEmailService _emailService;

        public ProductController(IDbService dbService, IEmailService emailService)
        {
            _dbService = dbService;
            _emailService = emailService;
        }                        

        [HttpGet]
        [Route("[controller]")]
        public IQueryable<Product> GetSelected([FromQuery] PageParameters pageP, [FromQuery] string? name, string? category, int? price)
        {
            return _dbService.GetSelected(pageP, name, category, price);
        }

        [HttpGet]
        [Route("[controller]/all")]
        public IQueryable<Product> GetAll([FromQuery] PageParameters pageP)
        {
            return _dbService.GetAll(pageP);
        }

        [HttpPut]
        [Route("[controller]")]
        public void Update([FromBody] Product product)
        {
            _dbService.UpdateProduct(product);
        }

        //[HttpPost]
        //[Route("[controller]")]
        //public IActionResult Create(Product product)
        //{
        //    _emailService.Send(product);
        //    return _dbService.CreateProduct(product);
        //}

        [HttpDelete]
        [Route("[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            _dbService.DeleteProduct(id);
            return Ok();
        }

        [HttpPost]
        [Route("[controller]/create")]
        public void CreateProduct([FromForm(Name = "data")] string data, [FromForm(Name = "image")] IFormFile uploadedFile)
        {
            _ = new Product();
            Product product = JsonConvert.DeserializeObject<Product>(data);
            _dbService.CreateProduct(product, uploadedFile);
            _emailService.Send(product);
                   
        }

    }
}
 