using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public event Action? OnCartChanged;

        public async Task<List<CartItem>?> GetCartItemAsync(int Id)
        {
            return _context.CartItem
                .Include(c => c.Item)
                .Where(c => c.ItemId == Id)
                .ToList();
        }

        public List<CartItem> GetCartItems(string userId)
        {
            return _context.CartItem
                .Include(c => c.Item)
                .Where(c => c.ApplicationUserId == userId)
                .ToList();
        }

        public async Task AddToCart(Item item, string userId)
        {
            var existing = await _context.CartItem
                .FirstOrDefaultAsync(c => c.ItemId == item.Id && c.ApplicationUserId == userId);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                _context.CartItem.Add(new CartItem
                {
                    ItemId = item.Id,
                    ApplicationUserId = userId,
                    Quantity = 1
                });
            }

            await _context.SaveChangesAsync();
            OnCartChanged?.Invoke();
        }

        public async Task RemoveFromCart(int cartItemId)
        {
            var item = await _context.CartItem.FindAsync(cartItemId);

            if (item != null)
            {
                _context.CartItem.Remove(item);
                await _context.SaveChangesAsync();
                OnCartChanged?.Invoke();
            }
        }

        public decimal GetTotal(string userId)
        {
            return _context.CartItem
                .Include(c => c.Item)
                .Where(c => c.ApplicationUserId == userId)
                .Sum(c => (c.Item.Price) * c.Quantity);
        }

        public async Task<bool> UpdateQuantity(CartItem updatedItem)
        {
            var existing = await _context.CartItem.FindAsync(updatedItem.Id);

            if (existing == null) return false;

            existing.Quantity = updatedItem.Quantity;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}