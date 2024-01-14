using System.ComponentModel.DataAnnotations;

namespace ModelBindingMvc.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(1, 1_000)]
        public decimal Price { get; set; }
    }
}
