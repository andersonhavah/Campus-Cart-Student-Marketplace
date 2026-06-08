using System;

namespace Campus_Cart_Student_Marketplace.Models
{
    public class Item
    {
        public int Id { get; set; }

        // Basic details
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Pricing and stock
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Optional metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
