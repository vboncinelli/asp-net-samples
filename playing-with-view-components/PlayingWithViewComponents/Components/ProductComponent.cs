using AspnetViewComponentDemo.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using PlayingWithViewComponents.Models;

namespace AspnetViewComponentDemo.Components
{
    public class ProductComponent : ViewComponent
    {
        public ProductComponent()
        {

        }

        public IViewComponentResult Invoke(int id)
        {
            // Fetch a product from the database
            var product = new ProductViewModel() { Id = id, Name = "Calzini uomo", Description = "Calzini 100% cotone", Price = 10M };

            return View(product);
        }
    }

    public class CartComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var htmlContent = new HtmlString("<p>Contenuto HTML</p>");
            return new HtmlContentViewComponentResult(htmlContent);
        }
    }
}
