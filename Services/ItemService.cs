using System.Collections.Generic;
using System.Linq;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class ItemService
    {
        private readonly List<Item> _mockItems = new()
        {
            new Item { Id = 1, Title = "Engineering Textbook", Price = 45.00m, ApplicationUserId = "mock-seller-999", ImageUrl = "images/placeholder.png" },
            new Item { Id = 2, Title = "Scientific Calculator", Price = 15.50m, ApplicationUserId = "mock-seller-888", ImageUrl = "images/placeholder.png" }
        };

        public List<Item> GetAllItems() => _mockItems;

        public Item? GetItemById(int id) => _mockItems.FirstOrDefault(i => i.Id == id);
    }
}