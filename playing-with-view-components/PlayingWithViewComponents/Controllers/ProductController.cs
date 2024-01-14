using AspnetViewComponentDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AspnetViewComponentDemo.Controllers
{
    [ViewComponent(Name = "ProductHybridComponent")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<ProductViewModel>(ViewData, new ProductViewModel()
                {
                    Id = 666,
                    Name = "Calzini ibridi",
                    Description = "Calzini in a hybrid view component",
                    Price = 100M
                })
            };
        }
    }
}
