using System.ComponentModel.DataAnnotations;

namespace PlayingModelBinding.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        [Range(0, 1_000)]
        public decimal Price { get; set; }
    }
}
