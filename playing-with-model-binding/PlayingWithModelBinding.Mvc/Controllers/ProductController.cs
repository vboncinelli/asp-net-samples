using Microsoft.AspNetCore.Mvc;
using ModelBindingMvc.Models;

namespace ModelBindingMvc.Controllers
{
    public class ProductController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductViewModel());

        }

        [HttpPost]
        public IActionResult Create([FromForm] ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            product.Id = 1;
            product.Price = 10;

            // Pattern Post-Redirect-Get
            // Serve a evitare che l'utente reinvii il form 
            // aggiornando la pagina
            return RedirectToAction(nameof(Details), product);
        }

        [HttpGet]
        public IActionResult Details(ProductViewModel product)
        {
            return View(product);
        }
    }
}
