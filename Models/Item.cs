namespace CampusCart.Models;

public class Item
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public string Condition { get; set; } = "Used";

    public bool IsAvailable { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Category Relationship
    public int CategoryId { get; set; }

    public string Category { get; set; } = string.Empty;

    // Seller Information
    public string SellerName { get; set; } = string.Empty;

    public string SellerEmail { get; set; } = string.Empty;
}