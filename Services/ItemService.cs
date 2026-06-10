using System.Collections.Generic;
using System.Linq;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class ItemService
    {
        private readonly List<Item> _mockItems = new();

        public List<Item> GetAllItems() => _mockItems;

        public Item? GetItemById(int id) => _mockItems.FirstOrDefault(i => i.Id == id);
    }
}