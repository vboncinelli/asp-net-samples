using Microsoft.AspNetCore.Mvc;
using PlayingWithCookies.Web.Mvc.Models;
using System.Diagnostics;

namespace PlayingWithCookies.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var options = new CookieOptions()
            {
                HttpOnly = true, // rende accessibile il cookie solo dal server, no javascript
                Expires = DateTime.Now.AddDays(1), // imposta la scadenza del cookie
            };

            Response.Cookies.Append("MyCookie", "Hello world from a cookie", options);

            return View();
        }

        public IActionResult ShowCookie()
        {
            string? cookieValue = Request.Cookies["MyCookie"];

            return cookieValue is null ? View("ShowCookie", "No cookie for you") : View("ShowCookie", cookieValue);
        }

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
