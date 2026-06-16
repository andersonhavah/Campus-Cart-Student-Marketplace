using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class ItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Item> GetItems()
        {
            return _context.Item
                .ToList();
        }

        public Item? GetItemById(int id)
        {
            return _context.Item
                .FirstOrDefault(i => i.Id == id);
        }

        public List<Item> SearchItems(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetItems();

            searchTerm = searchTerm.ToLower();

            return _context.Item
                .Where(i =>
                    i.Title.ToLower().Contains(searchTerm) ||
                    i.Description.ToLower().Contains(searchTerm))
                .ToList();
        }

        public List<Item> GetItemsByCategory(int categoryId)
        {
            return _context.Item
                .Where(i => i.CategoryId == categoryId)
                .ToList();
        }

        public async Task<int> AddItem(Item item)
        {
            item.CreatedAt = DateTime.UtcNow;

            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            return item.Id;
        }

        public async Task<bool> UpdateItem(Item updatedItem)
        {
            var existing = await _context.Item.FindAsync(updatedItem.Id);

            if (existing == null) return false;

            existing.Title = updatedItem.Title;
            existing.Description = updatedItem.Description;
            existing.Price = updatedItem.Price;
            existing.ImageUrl = updatedItem.ImageUrl;
            existing.Condition = updatedItem.Condition;
            existing.IsAvailable = updatedItem.IsAvailable;
            existing.CategoryId = updatedItem.CategoryId;
            existing.SellerId = updatedItem.SellerId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null) return false;

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}