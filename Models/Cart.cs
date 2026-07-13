using System.ComponentModel.DataAnnotations;

namespace FarmLink.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public User Customer { get; set; } = null!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        [Required]
        public decimal Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}