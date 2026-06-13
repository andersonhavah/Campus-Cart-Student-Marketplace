using System.ComponentModel.DataAnnotations;

namespace CampusCart.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string SellerUserId { get; set; } = string.Empty;

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;
    }
}