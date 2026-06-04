using System;

namespace CampusCart.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        // Links the cart item to a specific logged-in user
        public string ApplicationUserId { get; set; } = string.Empty;

        public int ItemId { get; set; }

        // Navigation property to Nico's core Item model
        public Item? Item { get; set; }

        public int Quantity { get; set; } = 1;

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}