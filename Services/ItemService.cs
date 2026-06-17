using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class ItemService
    {
        private readonly List<Item> Items = new List<Item>
        {
            new Item { Id = 1, Title = "Belleze Ergonomic Chair", Description = "Comfortable ergonomic office chair.", Price = 100000, ImageUrl = "https://images.unsplash.com/photo-1505797149-43b0069ec26b?w=500", Condition = "Used", CategoryId = 1, SellerId = "student1", ApplicationUserId = "student1" },
            new Item { Id = 2, Title = "Study Desk", Description = "Spacious wooden study desk.", Price = 85000, ImageUrl = "https://images.unsplash.com/photo-1518455027359-f3f8164ba6bd?w=500", Condition = "Like New", CategoryId = 1, SellerId = "student2", ApplicationUserId = "student2" },
            new Item { Id = 3, Title = "Gaming Chair", Description = "Adjustable gaming chair.", Price = 120000, ImageUrl = "https://images.unsplash.com/photo-1598550476439-6847785fce6e?w=500", Condition = "Used", CategoryId = 1, SellerId = "student3", ApplicationUserId = "student3" },
            new Item { Id = 4, Title = "Bookshelf", Description = "5-tier bookshelf.", Price = 45000, ImageUrl = "https://images.unsplash.com/photo-1544644181-1484b3fdfc62?w=500", Condition = "Good", CategoryId = 1, SellerId = "student4", ApplicationUserId = "student4" },
            new Item { Id = 5, Title = "Mini Fridge", Description = "Compact dorm fridge.", Price = 95000, ImageUrl = "https://images.unsplash.com/photo-1584622781564-1d987f7333c1?w=500", Condition = "Used", CategoryId = 2, SellerId = "student5", ApplicationUserId = "student5" }
        };

        // Synchronous Mappings
        public List<Item> GetItems() => Items;
        public Item? GetItemById(int id) => Items.FirstOrDefault(i => i.Id == id);
        public List<Item> GetItemsByCategory(int categoryId) => Items.Where(i => i.CategoryId == categoryId).ToList();

        // --- ASYNCHRONOUS TARGET EXTENSIONS (Fixes UI Errors) ---
        public Task<List<Item>> GetItemsAsync() => Task.FromResult(Items);
        public Task<Item?> GetItemByIdAsync(int id) => Task.FromResult(Items.FirstOrDefault(i => i.Id == id));
        public Task<List<Item>> GetItemsByCategoryAsync(int categoryId) => Task.FromResult(Items.Where(i => i.CategoryId == categoryId).ToList());

        public Task<int> AddItemAsync(Item item)
        {
            item.Id = Items.Any() ? Items.Max(i => i.Id) + 1 : 1;
            Items.Add(item);
            return Task.FromResult(item.Id);
        }

        public Task<bool> UpdateItemAsync(Item updatedItem)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == updatedItem.Id);
            if (existingItem == null) return Task.FromResult(false);

            existingItem.Title = updatedItem.Title;
            existingItem.Description = updatedItem.Description;
            existingItem.Price = updatedItem.Price;
            existingItem.ImageUrl = updatedItem.ImageUrl;
            existingItem.Condition = updatedItem.Condition;
            existingItem.CategoryId = updatedItem.CategoryId;
            existingItem.SellerId = updatedItem.SellerId;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null) return Task.FromResult(false);
            Items.Remove(item);
            return Task.FromResult(true);
        }
    }
}