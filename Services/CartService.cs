using System;
using System.Collections.Generic;
using System.Linq;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class CartService
    {
        private readonly List<CartItem> _mockCart = new();
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
            OnCartChanged?.Invoke();
        }

        public void RemoveFromCart(int cartItemId)
        {
            var item = _mockCart.FirstOrDefault(c => c.Id == cartItemId);
            if (item != null)
            {
                _mockCart.Remove(item);
                OnCartChanged?.Invoke();
            }
        }

        public decimal GetTotal(string userId)
        {
            return _mockCart.Where(c => c.ApplicationUserId == userId)
                             .Sum(c => (c.Item?.Price ?? 0) * c.Quantity);
        }

        public bool UpdateQuanity(CartItem updatedItem)
        {
            var existingItem =  _mockCart.FirstOrDefault(i => i.Id == updatedItem.Id);

            if (existingItem == null)
                return false;

            existingItem.Quantity = updatedItem.Quantity;

            return true;
        }
    }
}