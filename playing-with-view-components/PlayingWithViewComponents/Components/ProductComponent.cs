using AspnetViewComponentDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspnetViewComponentDemo.Components
{
    public class ProductComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            // Fetch a product from the database
            var product = new ProductViewModel() { Id = id, Name = "Calzini uomo", Description = "Calzini 100% cotone", Price = 10M };

            return View(product);
        }
    }
}
