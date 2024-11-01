using Microsoft.AspNetCore.Mvc;
using PlayingWithActionFilters.Filters;
using PlayingWithActionFilters.Models;
using System.Diagnostics;

namespace PlayingWithActionFilters.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    
        [ServiceFilter(typeof(LoggingActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        [ServiceFilter(typeof(ValidationActionFilter))]
        public IActionResult Create(Product product)
        {
            return View(product);
        }

        [ResponseHeader("MyHeader", "MyValue")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
