using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using Shop.Interfaces;
using System.Linq;


namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        IDbService _dbService;

        public ReviewController(IDbService dbService) => _dbService = dbService;

        [HttpGet("{id}")]
        public IQueryable<Review>GetProductReviews(int id)
        {
            return _dbService.GetProductReviews(id);
        }
    }
}
