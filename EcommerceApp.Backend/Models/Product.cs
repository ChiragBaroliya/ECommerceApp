using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Backend.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100000)]
        public int Stock { get; set; }

        [StringLength(255)]
        public string? ImagePath { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
