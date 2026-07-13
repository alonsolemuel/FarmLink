using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FarmLink.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Category { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        
        public int Quantity { get; set; }

        [Required]
        public string Unit { get; set; } = string.Empty;

        public IFormFile? ImageFile { get; set; }
    }
}