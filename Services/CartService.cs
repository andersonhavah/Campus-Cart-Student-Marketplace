using System;
using System.Collections.Generic;
using System.Linq;
using CampusCart.Models;

namespace CampusCart.Services
{
    public class CartService
    {
        private readonly List<CartItem> _mockCart = new();

        // Event to notify UI components (like a layout badge) to re-render when items change
        public event Action? OnCartChanged;

        public List<CartItem> GetCartItems(string userId)
        {
            return _mockCart.Where(c => c.ApplicationUserId == userId).ToList();
        }

        public void AddToCart(Item item, string userId)
        {
            var existingItem = _mockCart.FirstOrDefault(c => c.ItemId == item.Id && c.ApplicationUserId == userId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _mockCart.Add(new CartItem
                {
                    Id = _mockCart.Count + 1,
                    ItemId = item.Id,
                    Item = item,
                    ApplicationUserId = userId,
                    Quantity = 1
                });
            }
            NotifyCartChanged();
        }

        public void RemoveFromCart(int cartItemId)
        {
            var item = _mockCart.FirstOrDefault(c => c.Id == cartItemId);
            if (item != null)
            {
                _mockCart.Remove(item);
                NotifyCartChanged();
            }
        }

        public void UpdateQuantity(int cartItemId, int quantity)
        {
            var item = _mockCart.FirstOrDefault(c => c.Id == cartItemId);
            if (item != null && quantity > 0)
            {
                item.Quantity = quantity;
                NotifyCartChanged();
            }
        }

        public decimal GetTotal(string userId)
        {
            return _mockCart.Where(c => c.ApplicationUserId == userId)
                             .Sum(c => (c.Item?.Price ?? 0) * c.Quantity);
        }

        private void NotifyCartChanged() => OnCartChanged?.Invoke();
    }
}