using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Campus_Cart_Student_Marketplace.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Campus_Cart_Student_Marketplace.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Campus_Cart_Student_Marketplace.Models.Category> Category { get; set; } = default!;
        public DbSet<Campus_Cart_Student_Marketplace.Models.CartItem> CartItem { get; set; } = default!;
        public DbSet<Campus_Cart_Student_Marketplace.Models.Message> Message { get; set; } = default!;
        public DbSet<Campus_Cart_Student_Marketplace.Models.Item> Item { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Furniture" },
                new Category { Id = 2, Name = "Appliances" },
                new Category { Id = 3, Name = "Electronics" },
                new Category { Id = 4, Name = "Books" },
                new Category { Id = 5, Name = "Accessories" },
                new Category { Id = 6, Name = "Clothing" },
                new Category { Id = 7, Name = "Sports" },
                new Category { Id = 8, Name = "School Supplies" },
                new Category { Id = 9, Name = "Dorm Essentials" },
                new Category { Id = 10, Name = "Other" }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Title = "Belleze Ergonomic Chair", Description = "Comfortable ergonomic office chair.", Price = 100000, ImageUrl = "https://images.unsplash.com/photo-1505797149-43b0069ec26b?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 1, SellerId = "student1" },
                new Item { Id = 2, Title = "Study Desk", Description = "Spacious wooden study desk.", Price = 85000, ImageUrl = "https://images.unsplash.com/photo-1518455027359-f3f8164ba6bd?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 1, SellerId = "student2" },
                new Item { Id = 3, Title = "Gaming Chair", Description = "Adjustable gaming chair.", Price = 120000, ImageUrl = "https://images.unsplash.com/photo-1598550476439-6847785fce6e?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 1, SellerId = "student3" },
                new Item { Id = 4, Title = "Bookshelf", Description = "5-tier bookshelf.", Price = 45000, ImageUrl = "https://images.unsplash.com/photo-1544644181-1484b3fdfc62?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 1, SellerId = "student4" },
                new Item { Id = 14, Title = "Desk Lamp", Description = "LED study lamp.", Price = 10000, ImageUrl = "https://images.unsplash.com/photo-1507473885765-e6ed057f782c?w=500&auto=format&fit=crop&q=60", Condition = "New", CategoryId = 1, SellerId = "student14" },
                new Item { Id = 15, Title = "Office Chair", Description = "Comfortable office chair.", Price = 70000, ImageUrl = "https://images.unsplash.com/photo-1580481072645-022f9a6dbf27?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 1, SellerId = "student15" },
                new Item { Id = 16, Title = "Bed Frame", Description = "Single-size bed frame.", Price = 65000, ImageUrl = "https://images.unsplash.com/photo-1505693416388-ac5ce068fe85?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 1, SellerId = "student16" },
                new Item { Id = 17, Title = "Mattress", Description = "Single mattress.", Price = 50000, ImageUrl = "https://images.unsplash.com/photo-1631049307264-da0ec9d70304?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 1, SellerId = "student17" },
                new Item { Id = 31, Title = "Study Chair", Description = "Simple study chair.", Price = 30000, ImageUrl = "https://images.unsplash.com/photo-1562184552-997c461abbe6?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 1, SellerId = "student31" },
                new Item { Id = 39, Title = "Dorm Rug", Description = "Soft floor rug.", Price = 14000, ImageUrl = "https://images.unsplash.com/photo-1600121848594-d8644e57abab?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 1, SellerId = "student39" },
                new Item { Id = 40, Title = "Storage Bin", Description = "Large plastic storage bin.", Price = 10000, ImageUrl = "https://images.unsplash.com/photo-1604176354204-9268737828e4?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 1, SellerId = "student40" },

                // Category 2: Appliances & Essentials
                new Item { Id = 5, Title = "Mini Fridge", Description = "Compact dorm fridge.", Price = 95000, ImageUrl = "https://images.unsplash.com/photo-1584622781564-1d987f7333c1?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 2, SellerId = "student5" },
                new Item { Id = 6, Title = "Microwave Oven", Description = "700W microwave.", Price = 55000, ImageUrl = "https://images.unsplash.com/photo-1574269909862-7e1d70bb8078?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 2, SellerId = "student6" },
                new Item { Id = 28, Title = "Extension Cord", Description = "4-outlet extension cord.", Price = 7000, ImageUrl = "https://images.unsplash.com/photo-1558538337-aab544368de8?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 2, SellerId = "student28" },
                new Item { Id = 29, Title = "Coffee Maker", Description = "Single-cup coffee maker.", Price = 25000, ImageUrl = "https://images.unsplash.com/photo-1517256064527-09c53b2d0c6b?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 2, SellerId = "student29" },
                new Item { Id = 30, Title = "Electric Kettle", Description = "Fast-boil kettle.", Price = 18000, ImageUrl = "https://images.unsplash.com/photo-1576092768241-dec231879fc3?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 2, SellerId = "student30" },
                new Item { Id = 35, Title = "Portable Fan", Description = "Rechargeable fan.", Price = 11000, ImageUrl = "https://images.unsplash.com/photo-1618945032343-340a62a13be5?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 2, SellerId = "student35" },

                // Category 3: Electronics & Computer Equipment
                new Item { Id = 7, Title = "Laptop Stand", Description = "Aluminum adjustable stand.", Price = 15000, ImageUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 3, SellerId = "student7" },
                new Item { Id = 8, Title = "Mechanical Keyboard", Description = "RGB mechanical keyboard.", Price = 35000, ImageUrl = "https://images.unsplash.com/photo-1618384887929-16ec33fab9ef?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 3, SellerId = "student8" },
                new Item { Id = 9, Title = "Wireless Mouse", Description = "Bluetooth mouse.", Price = 12000, ImageUrl = "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 3, SellerId = "student9" },
                new Item { Id = 10, Title = "24 Inch Monitor", Description = "Full HD monitor.", Price = 80000, ImageUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 3, SellerId = "student10" },
                new Item { Id = 18, Title = "Printer", Description = "Wireless printer.", Price = 45000, ImageUrl = "https://images.unsplash.com/photo-1612815154858-60aa4c59eaa6?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 3, SellerId = "student18" },
                new Item { Id = 19, Title = "External SSD 500GB", Description = "Portable SSD storage.", Price = 30000, ImageUrl = "https://images.unsplash.com/photo-1601524909162-be87252be298?w=500&auto=format&fit=crop&q=60", Condition = "New", CategoryId = 3, SellerId = "student19" },
                new Item { Id = 20, Title = "1080p Webcam", Description = "HD webcam for meetings.", Price = 18000, ImageUrl = "https://images.unsplash.com/photo-1603184017968-945045663bd4?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 3, SellerId = "student20" },
                new Item { Id = 21, Title = "Bluetooth Speaker", Description = "Portable speaker.", Price = 25000, ImageUrl = "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 3, SellerId = "student21" },
                new Item { Id = 22, Title = "Headphones", Description = "Noise-cancelling headphones.", Price = 40000, ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 3, SellerId = "student22" },
                new Item { Id = 23, Title = "Wi-Fi Router", Description = "High-speed Wi-Fi router.", Price = 28000, ImageUrl = "https://images.unsplash.com/photo-1544197150-b99a580bb7a8?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 3, SellerId = "student23" },
                new Item { Id = 27, Title = "Power Bank", Description = "20,000mAh power bank.", Price = 22000, ImageUrl = "https://images.unsplash.com/photo-1609592424109-dd9892f1b177?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 3, SellerId = "student27" },
                new Item { Id = 33, Title = "USB Hub", Description = "7-port USB hub.", Price = 8000, ImageUrl = "https://images.unsplash.com/photo-1468495244123-6c6c332eeece?w=500&auto=format&fit=crop&q=60", Condition = "New", CategoryId = 3, SellerId = "student33" },
                new Item { Id = 36, Title = "Tablet Stand", Description = "Adjustable stand.", Price = 9000, ImageUrl = "https://images.unsplash.com/photo-1586105251261-72a756497a11?w=500&auto=format&fit=crop&q=60", Condition = "New", CategoryId = 3, SellerId = "student36" },
                new Item { Id = 38, Title = "Portable Projector", Description = "Mini HD projector.", Price = 95000, ImageUrl = "https://images.unsplash.com/photo-1535016120720-40c646be5580?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 3, SellerId = "student38" },

                // Category 4: Books & Academic Materials
                new Item { Id = 11, Title = "Calculus Textbook", Description = "University calculus textbook.", Price = 18000, ImageUrl = "https://images.unsplash.com/photo-1543002588-bfa74002ed7e?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 4, SellerId = "student11" },
                new Item { Id = 12, Title = "Physics Textbook", Description = "Introductory physics textbook.", Price = 22000, ImageUrl = "https://images.unsplash.com/photo-1497633762265-9d179a990aa6?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 4, SellerId = "student12" },
                new Item { Id = 13, Title = "Chemistry Lab Kit", Description = "Basic chemistry kit.", Price = 25000, ImageUrl = "https://images.unsplash.com/photo-1532187863486-abf9d39d6618?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 4, SellerId = "student13" },
                new Item { Id = 24, Title = "Scientific Calculator", Description = "Student scientific calculator.", Price = 9000, ImageUrl = "https://images.unsplash.com/photo-1635070041078-e363dbe005cb?w=500&auto=format&fit=crop&q=60", Condition = "Used", CategoryId = 4, SellerId = "student24" },
                new Item { Id = 32, Title = "Whiteboard", Description = "Portable whiteboard.", Price = 15000, ImageUrl = "https://images.unsplash.com/photo-1611224885990-ab7363d12259?w=500&auto=format&fit=crop&q=60", Condition = "Like New", CategoryId = 4, SellerId = "student32" },

                // Category 5: Accessories & Small Gear
                new Item { Id = 25, Title = "Backpack", Description = "Large student backpack.", Price = 12000, ImageUrl = "https://images.unsplash.com/photo-1553062407-98eeb64c6a62?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 5, SellerId = "student25" },
                new Item { Id = 26, Title = "Water Bottle", Description = "Insulated bottle.", Price = 5000, ImageUrl = "https://images.unsplash.com/photo-1602143407151-7111542de6e8?w=500&auto=format&fit=crop&q=60", Condition = "New", CategoryId = 5, SellerId = "student26" },
                new Item { Id = 34, Title = "Desk Organizer", Description = "Multi-compartment organizer.", Price = 6000, ImageUrl = "https://images.unsplash.com/photo-1513151233558-d860c5398176?w=500&auto=format&fit=crop&q=60", Condition = "Good", CategoryId = 5, SellerId = "student34" },
                new Item { Id = 37, Title = "LED Strip Lights", Description = "Dorm room lights.", Price = 12000, ImageUrl = "https://images.unsplash.com/photo-1565814636199-ae8133055c1c?w=500&auto=format&fit=crop&q=60", Condition = "New", CategoryId = 5, SellerId = "student37" }
            );
        }

    }
}
