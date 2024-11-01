using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayingModelBinding.Models;

namespace PlayingModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create(Product product)
        {
            return Ok();
        }
    }
}
