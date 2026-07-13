using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FarmLink.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public string? Description { get; set; }

        [Required]
        
        [Precision(10, 2)]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }



        public string Unit { get; set; } = string.Empty;
        public string? ImagePath { get; set; }

        // Farmer who created the product
        public int FarmerId { get; set; }

        public User Farmer { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}