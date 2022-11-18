using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using Shop.Interfaces;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IDbService _dbService;

        public UserController(IDbService dbService) => _dbService = dbService;

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)   
        {
           return _dbService.AddNewUser(user);
        }

    }
}
