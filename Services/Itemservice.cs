using CampusCart.Models;

namespace CampusCart.Services
{
    public class ItemService
    {
        private readonly List<Item> _items = new();

        public List<Item> GetAllItems()
        {
            return _items;
        }

        public Item? GetItem(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public void AddItem(Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var existing = GetItem(item.Id);

            if (existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description;
                existing.Price = item.Price;
                existing.Category = item.Category;
                existing.ImageUrl = item.ImageUrl;
            }
        }

        public void DeleteItem(int id)
        {
            var item = GetItem(id);

            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}