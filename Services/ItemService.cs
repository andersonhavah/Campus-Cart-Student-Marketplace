using System.Text.Json;
using CampusCart.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class ItemService
    {
        public List<Item> GetItems()
        {
            return new()
            {
                new Item { Id = 1, Title = "Belleze Ergonomic Chair", Description = "Comfortable ergonomic office chair.", Price = 100000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, Category = "Furniture", SellerName = "John Doe", SellerEmail = "john1@campus.edu" },
                new Item { Id = 2, Title = "Study Desk", Description = "Spacious wooden study desk.", Price = 85000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 1, Category = "Furniture", SellerName = "Jane Smith", SellerEmail = "jane2@campus.edu" },
                new Item { Id = 3, Title = "Gaming Chair", Description = "Adjustable gaming chair.", Price = 120000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, Category = "Furniture", SellerName = "Alex Brown", SellerEmail = "alex3@campus.edu" },
                new Item { Id = 4, Title = "Bookshelf", Description = "5-tier bookshelf.", Price = 45000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 1, Category = "Furniture", SellerName = "Sarah Lee", SellerEmail = "sarah4@campus.edu" },
                new Item { Id = 5, Title = "Mini Fridge", Description = "Compact dorm fridge.", Price = 95000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 2, Category = "Appliances", SellerName = "David King", SellerEmail = "david5@campus.edu" },
                new Item { Id = 6, Title = "Microwave Oven", Description = "700W microwave.", Price = 55000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 2, Category = "Appliances", SellerName = "Emma Clark", SellerEmail = "emma6@campus.edu" },
                new Item { Id = 7, Title = "Laptop Stand", Description = "Aluminum adjustable stand.", Price = 15000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, Category = "Electronics", SellerName = "Michael Scott", SellerEmail = "michael7@campus.edu" },
                new Item { Id = 8, Title = "Mechanical Keyboard", Description = "RGB mechanical keyboard.", Price = 35000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 3, Category = "Electronics", SellerName = "Pam Beesly", SellerEmail = "pam8@campus.edu" },
                new Item { Id = 9, Title = "Wireless Mouse", Description = "Bluetooth mouse.", Price = 12000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, Category = "Electronics", SellerName = "Jim Halpert", SellerEmail = "jim9@campus.edu" },
                new Item { Id = 10, Title = "Monitor 24 Inch", Description = "Full HD monitor.", Price = 80000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 3, Category = "Electronics", SellerName = "Dwight Schrute", SellerEmail = "dwight10@campus.edu" },

                new Item { Id = 11, Title = "Calculus Textbook", Description = "University calculus textbook.", Price = 18000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 4, Category = "Books", SellerName = "Kevin Malone", SellerEmail = "kevin11@campus.edu" },
                new Item { Id = 12, Title = "Physics Textbook", Description = "Introductory physics.", Price = 22000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 4, Category = "Books", SellerName = "Angela Martin", SellerEmail = "angela12@campus.edu" },
                new Item { Id = 13, Title = "Chemistry Lab Kit", Description = "Basic chemistry kit.", Price = 25000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 4, Category = "Books", SellerName = "Oscar Martinez", SellerEmail = "oscar13@campus.edu" },
                new Item { Id = 14, Title = "Desk Lamp", Description = "LED study lamp.", Price = 10000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 1, Category = "Furniture", SellerName = "Creed Bratton", SellerEmail = "creed14@campus.edu" },
                new Item { Id = 15, Title = "Office Chair", Description = "Comfortable office chair.", Price = 70000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, Category = "Furniture", SellerName = "Ryan Howard", SellerEmail = "ryan15@campus.edu" },
                new Item { Id = 16, Title = "Bed Frame", Description = "Single-size bed frame.", Price = 65000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 1, Category = "Furniture", SellerName = "Kelly Kapoor", SellerEmail = "kelly16@campus.edu" },
                new Item { Id = 17, Title = "Mattress", Description = "Single mattress.", Price = 50000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, Category = "Furniture", SellerName = "Stanley Hudson", SellerEmail = "stanley17@campus.edu" },
                new Item { Id = 18, Title = "Printer", Description = "Wireless printer.", Price = 45000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, Category = "Electronics", SellerName = "Phyllis Vance", SellerEmail = "phyllis18@campus.edu" },
                new Item { Id = 19, Title = "External SSD", Description = "500GB SSD.", Price = 30000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 3, Category = "Electronics", SellerName = "Toby Flenderson", SellerEmail = "toby19@campus.edu" },
                new Item { Id = 20, Title = "Webcam", Description = "1080p webcam.", Price = 18000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, Category = "Electronics", SellerName = "Andy Bernard", SellerEmail = "andy20@campus.edu" },

                new Item { Id = 21, Title = "Bluetooth Speaker", Description = "Portable speaker.", Price = 25000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 3, Category = "Electronics", SellerName = "Erin Hannon", SellerEmail = "erin21@campus.edu" },
                new Item { Id = 22, Title = "Headphones", Description = "Noise-cancelling headphones.", Price = 40000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 3, Category = "Electronics", SellerName = "Robert California", SellerEmail = "robert22@campus.edu" },
                new Item { Id = 23, Title = "Router", Description = "High-speed Wi-Fi router.", Price = 28000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, Category = "Electronics", SellerName = "Nellie Bertram", SellerEmail = "nellie23@campus.edu" },
                new Item { Id = 24, Title = "Calculator", Description = "Scientific calculator.", Price = 9000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 4, Category = "Books", SellerName = "Clark Green", SellerEmail = "clark24@campus.edu" },
                new Item { Id = 25, Title = "Backpack", Description = "Large student backpack.", Price = 12000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 5, Category = "Accessories", SellerName = "Pete Miller", SellerEmail = "pete25@campus.edu" },
                new Item { Id = 26, Title = "Water Bottle", Description = "Insulated bottle.", Price = 5000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 5, Category = "Accessories", SellerName = "Jo Bennett", SellerEmail = "jo26@campus.edu" },
                new Item { Id = 27, Title = "Power Bank", Description = "20,000mAh power bank.", Price = 22000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 3, Category = "Electronics", SellerName = "Gabe Lewis", SellerEmail = "gabe27@campus.edu" },
                new Item { Id = 28, Title = "Extension Cord", Description = "4-outlet extension cord.", Price = 7000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 2, Category = "Appliances", SellerName = "Jan Levinson", SellerEmail = "jan28@campus.edu" },
                new Item { Id = 29, Title = "Coffee Maker", Description = "Single-cup coffee maker.", Price = 25000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 2, Category = "Appliances", SellerName = "Holly Flax", SellerEmail = "holly29@campus.edu" },
                new Item { Id = 30, Title = "Electric Kettle", Description = "Fast-boil kettle.", Price = 18000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 2, Category = "Appliances", SellerName = "Meredith Palmer", SellerEmail = "meredith30@campus.edu" },

                new Item { Id = 31, Title = "Study Chair", Description = "Simple study chair.", Price = 30000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 1, Category = "Furniture", SellerName = "Roy Anderson", SellerEmail = "roy31@campus.edu" },
                new Item { Id = 32, Title = "Whiteboard", Description = "Portable whiteboard.", Price = 15000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 4, Category = "Books", SellerName = "Karen Filippelli", SellerEmail = "karen32@campus.edu" },
                new Item { Id = 33, Title = "USB Hub", Description = "7-port USB hub.", Price = 8000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 3, Category = "Electronics", SellerName = "Mose Schrute", SellerEmail = "mose33@campus.edu" },
                new Item { Id = 34, Title = "Desk Organizer", Description = "Multi-compartment organizer.", Price = 6000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 5, Category = "Accessories", SellerName = "Val Johnson", SellerEmail = "val34@campus.edu" },
                new Item { Id = 35, Title = "Portable Fan", Description = "Rechargeable fan.", Price = 11000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 2, Category = "Appliances", SellerName = "Bob Vance", SellerEmail = "bob35@campus.edu" },
                new Item { Id = 36, Title = "Tablet Stand", Description = "Adjustable stand.", Price = 9000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 3, Category = "Electronics", SellerName = "Brian Wittle", SellerEmail = "brian36@campus.edu" },
                new Item { Id = 37, Title = "LED Strip Lights", Description = "Dorm room lights.", Price = 12000, ImageUrl = "/img/belleze.webp", Condition = "New", CategoryId = 5, Category = "Accessories", SellerName = "Jordan Garfield", SellerEmail = "jordan37@campus.edu" },
                new Item { Id = 38, Title = "Portable Projector", Description = "Mini HD projector.", Price = 95000, ImageUrl = "/img/belleze.webp", Condition = "Used", CategoryId = 3, Category = "Electronics", SellerName = "Darryl Philbin", SellerEmail = "darryl38@campus.edu" },
                new Item { Id = 39, Title = "Dorm Rug", Description = "Soft floor rug.", Price = 14000, ImageUrl = "/img/belleze.webp", Condition = "Good", CategoryId = 1, Category = "Furniture", SellerName = "Lonny Collins", SellerEmail = "lonny39@campus.edu" },
                new Item { Id = 40, Title = "Storage Bin", Description = "Large plastic storage bin.", Price = 10000, ImageUrl = "/img/belleze.webp", Condition = "Like New", CategoryId = 1, Category = "Furniture", SellerName = "Madge Madsen", SellerEmail = "madge40@campus.edu" }
            };
        }
    }
}
