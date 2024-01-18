using Microsoft.AspNetCore.Mvc;
using PlayingWithXSS.Models;

namespace PlayingWithXSS.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            var todo = new Todo()
            {
                Id = (int) TempData["Id"],
                Description = TempData["Description"]?.ToString(),
            };

            return View(todo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            TempData["Id"] = todo.Id;
            TempData["Description"] = todo.Description;
            TempData["DueDate"] = todo.DueDate;

            return RedirectToAction("Details");
        }
    }
}
