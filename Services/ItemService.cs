using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class ItemService
    {
        private List<Item> Items = new List<Item>
        {  
            new Item { Id = 1, Title = "Belleze Ergonomic Chair", Description = "Comfortable ergonomic office chair.", Price = 100000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, SellerId = "student1" },
            new Item { Id = 2, Title = "Study Desk", Description = "Spacious wooden study desk.", Price = 85000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 1, SellerId = "student2" },
            new Item { Id = 3, Title = "Gaming Chair", Description = "Adjustable gaming chair.", Price = 120000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, SellerId = "student3" },
            new Item { Id = 4, Title = "Bookshelf", Description = "5-tier bookshelf.", Price = 45000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 1, SellerId = "student4" },
            new Item { Id = 5, Title = "Mini Fridge", Description = "Compact dorm fridge.", Price = 95000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 2, SellerId = "student5" },
            new Item { Id = 6, Title = "Microwave Oven", Description = "700W microwave.", Price = 55000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 2, SellerId = "student6" },
            new Item { Id = 7, Title = "Laptop Stand", Description = "Aluminum adjustable stand.", Price = 15000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, SellerId = "student7" },
            new Item { Id = 8, Title = "Mechanical Keyboard", Description = "RGB mechanical keyboard.", Price = 35000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 3, SellerId = "student8" },
            new Item { Id = 9, Title = "Wireless Mouse", Description = "Bluetooth mouse.", Price = 12000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, SellerId = "student9" },
            new Item { Id = 10, Title = "24 Inch Monitor", Description = "Full HD monitor.", Price = 80000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 3, SellerId = "student10" },

            new Item { Id = 11, Title = "Calculus Textbook", Description = "University calculus textbook.", Price = 18000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 4, SellerId = "student11" },
            new Item { Id = 12, Title = "Physics Textbook", Description = "Introductory physics textbook.", Price = 22000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 4, SellerId = "student12" },
            new Item { Id = 13, Title = "Chemistry Lab Kit", Description = "Basic chemistry kit.", Price = 25000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 4, SellerId = "student13" },
            new Item { Id = 14, Title = "Desk Lamp", Description = "LED study lamp.", Price = 10000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 1, SellerId = "student14" },
            new Item { Id = 15, Title = "Office Chair", Description = "Comfortable office chair.", Price = 70000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, SellerId = "student15" },
            new Item { Id = 16, Title = "Bed Frame", Description = "Single-size bed frame.", Price = 65000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 1, SellerId = "student16" },
            new Item { Id = 17, Title = "Mattress", Description = "Single mattress.", Price = 50000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, SellerId = "student17" },
            new Item { Id = 18, Title = "Printer", Description = "Wireless printer.", Price = 45000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, SellerId = "student18" },
            new Item { Id = 19, Title = "External SSD 500GB", Description = "Portable SSD storage.", Price = 30000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 3, SellerId = "student19" },
            new Item { Id = 20, Title = "1080p Webcam", Description = "HD webcam for meetings.", Price = 18000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, SellerId = "student20" },

            new Item { Id = 21, Title = "Bluetooth Speaker", Description = "Portable speaker.", Price = 25000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 3, SellerId = "student21" },
            new Item { Id = 22, Title = "Headphones", Description = "Noise-cancelling headphones.", Price = 40000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 3, SellerId = "student22" },
            new Item { Id = 23, Title = "Wi-Fi Router", Description = "High-speed Wi-Fi router.", Price = 28000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, SellerId = "student23" },
            new Item { Id = 24, Title = "Scientific Calculator", Description = "Student scientific calculator.", Price = 9000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 4, SellerId = "student24" },
            new Item { Id = 25, Title = "Backpack", Description = "Large student backpack.", Price = 12000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 5, SellerId = "student25" },
            new Item { Id = 26, Title = "Water Bottle", Description = "Insulated bottle.", Price = 5000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 5, SellerId = "student26" },
            new Item { Id = 27, Title = "Power Bank", Description = "20,000mAh power bank.", Price = 22000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, SellerId = "student27" },
            new Item { Id = 28, Title = "Extension Cord", Description = "4-outlet extension cord.", Price = 7000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 2, SellerId = "student28" },
            new Item { Id = 29, Title = "Coffee Maker", Description = "Single-cup coffee maker.", Price = 25000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 2, SellerId = "student29" },
            new Item { Id = 30, Title = "Electric Kettle", Description = "Fast-boil kettle.", Price = 18000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 2, SellerId = "student30" },

            new Item { Id = 31, Title = "Study Chair", Description = "Simple study chair.", Price = 30000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, SellerId = "student31" },
            new Item { Id = 32, Title = "Whiteboard", Description = "Portable whiteboard.", Price = 15000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 4, SellerId = "student32" },
            new Item { Id = 33, Title = "USB Hub", Description = "7-port USB hub.", Price = 8000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 3, SellerId = "student33" },
            new Item { Id = 34, Title = "Desk Organizer", Description = "Multi-compartment organizer.", Price = 6000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 5, SellerId = "student34" },
            new Item { Id = 35, Title = "Portable Fan", Description = "Rechargeable fan.", Price = 11000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 2, SellerId = "student35" },
            new Item { Id = 36, Title = "Tablet Stand", Description = "Adjustable stand.", Price = 9000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 3, SellerId = "student36" },
            new Item { Id = 37, Title = "LED Strip Lights", Description = "Dorm room lights.", Price = 12000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 5, SellerId = "student37" },
            new Item { Id = 38, Title = "Portable Projector", Description = "Mini HD projector.", Price = 95000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 3, SellerId = "student38" },
            new Item { Id = 39, Title = "Dorm Rug", Description = "Soft floor rug.", Price = 14000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 1, SellerId = "student39" },
            new Item { Id = 40, Title = "Storage Bin", Description = "Large plastic storage bin.", Price = 10000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 1, SellerId = "student40" }
        }; 

        public List<Item> GetItems()
        {
            
            return Items;
        }

        public Item? GetItemById(int id)
        {
            return Items.FirstOrDefault(i => i.Id == id);
        }

        public List<Item> SearchItems(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return Items;

            searchTerm = searchTerm.Trim().ToLower();

            return Items.Where(i =>
                i.Title.ToLower().Contains(searchTerm) ||
                i.Description.ToLower().Contains(searchTerm))
                .ToList();
        }

        public List<Item> GetItemsByCategory(int categoryId)
        {
            return Items.Where(i => i.CategoryId == categoryId).ToList();
        }

        public int AddItem(Item item)
        {
            item.Id = Items.Any()
                ? Items.Max(i => i.Id) + 1
                : 1;

            item.CreatedAt = DateTime.UtcNow;

            Items.Add(item);
            return item.Id;
        }

        public bool UpdateItem(Item updatedItem)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == updatedItem.Id);

            if (existingItem == null)
                return false;

            existingItem.Title = updatedItem.Title;
            existingItem.Description = updatedItem.Description;
            existingItem.Price = updatedItem.Price;
            existingItem.ImageUrl = updatedItem.ImageUrl;
            existingItem.Condition = updatedItem.Condition;
            existingItem.IsAvailable = updatedItem.IsAvailable;
            existingItem.CategoryId = updatedItem.CategoryId;
            existingItem.SellerId = updatedItem.SellerId;

            return true;
        }

        public bool DeleteItem(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return false;

            Items.Remove(item);

            return true;
        }
    }
}