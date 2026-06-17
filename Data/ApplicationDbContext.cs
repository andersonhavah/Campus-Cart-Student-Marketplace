using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Data;

/// <summary>
/// ApplicationDbContext is the main database context for the Campus Cart application.
/// It inherits from IdentityDbContext to provide built-in Identity support for user authentication and authorization.
/// This context manages all database operations including user management, roles, listings, categories, and cart items.
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    /// <summary>
    /// Initializes a new instance of the ApplicationDbContext class.
    /// </summary>
    /// <param name="options">The DbContextOptions containing database configuration.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the Categories DbSet for managing marketplace categories.
    /// </summary>
    public DbSet<Category> Categories { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Listings DbSet for managing marketplace listings.
    /// </summary>
    public DbSet<Listing> Listings { get; set; } = null!;

    /// <summary>
    /// Gets or sets the CartItems DbSet for managing shopping cart items.
    /// </summary>
    public DbSet<CartItem> CartItems { get; set; } = null!;

    /// <summary>
    /// Called when the model is being created.
    /// This method is used to configure the model, including entity relationships, table names, and constraints.
    /// </summary>
    /// <param name="modelBuilder">The ModelBuilder used to configure the entity model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Call the base OnModelCreating to configure Identity tables and relationships
        base.OnModelCreating(modelBuilder);

        // Configure ApplicationUser entity
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("AspNetUsers");
            entity.HasKey(u => u.Id);
            
            // Configure one-to-many relationship: User has many Listings
            entity.HasMany(u => u.Listings)
                .WithOne(l => l.Seller)
                .HasForeignKey(l => l.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-many relationship: User has many CartItems
            entity.HasMany(u => u.CartItems)
                .WithOne(ci => ci.User)
                .HasForeignKey(ci => ci.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Category entity
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");
            entity.HasKey(c => c.CategoryId);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Description).HasMaxLength(500);

            // Configure one-to-many relationship: Category has many Listings
            entity.HasMany(c => c.Listings)
                .WithOne(l => l.Category)
                .HasForeignKey(l => l.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Add unique constraint on category name
            entity.HasIndex(c => c.Name).IsUnique();
        });

        // Configure Listing entity
        modelBuilder.Entity<Listing>(entity =>
        {
            entity.ToTable("Listings");
            entity.HasKey(l => l.ListingId);
            
            entity.Property(l => l.Title).IsRequired().HasMaxLength(200);
            entity.Property(l => l.Description).IsRequired();
            entity.Property(l => l.Price).HasPrecision(10, 2);
            entity.Property(l => l.Condition).HasMaxLength(50);
            entity.Property(l => l.Location).HasMaxLength(200);

            // Foreign key relationships
            entity.HasOne(l => l.Seller)
                .WithMany(u => u.Listings)
                .HasForeignKey(l => l.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(l => l.Category)
                .WithMany(c => c.Listings)
                .HasForeignKey(l => l.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-many relationship: Listing has many CartItems
            entity.HasMany(l => l.CartItems)
                .WithOne(ci => ci.Listing)
                .HasForeignKey(ci => ci.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Create indexes for better query performance
            entity.HasIndex(l => l.SellerId);
            entity.HasIndex(l => l.CategoryId);
            entity.HasIndex(l => l.IsAvailable);
            entity.HasIndex(l => l.CreatedAt);
        });

        // Configure CartItem entity
        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.ToTable("CartItems");
            entity.HasKey(ci => ci.CartItemId);

            entity.Property(ci => ci.Quantity).IsRequired();

            // Foreign key relationships
            entity.HasOne(ci => ci.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(ci => ci.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ci => ci.Listing)
                .WithMany(l => l.CartItems)
                .HasForeignKey(ci => ci.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Create unique constraint: a user can have each listing only once in cart
            entity.HasIndex(ci => new { ci.UserId, ci.ListingId }).IsUnique();

            // Create indexes for better query performance
            entity.HasIndex(ci => ci.UserId);
            entity.HasIndex(ci => ci.ListingId);
        });

        // Add seed data for default categories
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Textbooks", Description = "Course textbooks and study materials" },
            new Category { CategoryId = 2, Name = "Electronics", Description = "Laptops, phones, and other electronics" },
            new Category { CategoryId = 3, Name = "Furniture", Description = "Dorm furniture and room essentials" },
            new Category { CategoryId = 4, Name = "Clothing", Description = "Apparel and accessories" },
            new Category { CategoryId = 5, Name = "Sports", Description = "Sports equipment and gear" },
            new Category { CategoryId = 6, Name = "Other", Description = "Miscellaneous items" }
        );
    }
}

