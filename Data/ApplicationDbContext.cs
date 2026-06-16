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
        }
    }
}
