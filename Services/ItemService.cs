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

        public async Task<List<Item>> GetItemsAsync()
        {
            return await _context.Item
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await _context.Item
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Item>> SearchItemsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetItemsAsync();

            searchTerm = searchTerm.Trim().ToLower();

            return await _context.Item
                .Where(i =>
                    i.Title.ToLower().Contains(searchTerm) ||
                    i.Description.ToLower().Contains(searchTerm))
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Item>> GetItemsByCategoryAsync(int categoryId)
        {
            return await _context.Item
                .Where(i => i.CategoryId == categoryId)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Item>> GetItemsBySellerAsync(string sellerId)
        {
            return await _context.Item
                .Where(i => i.SellerId == sellerId)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> AddItemAsync(Item item)
        {
            item.CreatedAt = DateTime.UtcNow;

            await _context.Item.AddAsync(item);
            await _context.SaveChangesAsync();

            return item.Id;
        }

        public async Task<bool> UpdateItemAsync(Item updatedItem)
        {
            var existingItem =
                await _context.Item.FindAsync(updatedItem.Id);

            if (existingItem == null)
                return false;

            existingItem.Title = updatedItem.Title;
            existingItem.Description = updatedItem.Description;
            existingItem.Price = updatedItem.Price;
            existingItem.ImageUrl = updatedItem.ImageUrl;
            existingItem.Condition = updatedItem.Condition;
            existingItem.IsAvailable = updatedItem.IsAvailable;
            existingItem.CategoryId = updatedItem.CategoryId;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
                return false;

            _context.Item.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<int> CountItemsAsync()
        {
            return await _context.Item.CountAsync();
        }
    }
}