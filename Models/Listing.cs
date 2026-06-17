namespace Campus_Cart_Student_Marketplace.Models;

/// <summary>
/// Listing represents a marketplace item that a seller has listed for sale.
/// Users browse and purchase from listings.
/// </summary>
public class Listing
{
    /// <summary>
    /// Gets or sets the unique identifier for the listing.
    /// </summary>
    public int ListingId { get; set; }

    /// <summary>
    /// Gets or sets the seller's user ID (foreign key to ApplicationUser).
    /// </summary>
    public string SellerId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the listing title/name.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the detailed description of the item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the item.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the category ID (foreign key to Category).
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the main image URL for the listing.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the condition of the item (New, Like New, Good, Fair, Poor).
    /// </summary>
    public string Condition { get; set; } = "Good";

    /// <summary>
    /// Gets or sets a value indicating whether the item is available for purchase.
    /// </summary>
    public bool IsAvailable { get; set; } = true;

    /// <summary>
    /// Gets or sets the date when the listing was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date when the listing was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the number of views this listing has received.
    /// </summary>
    public int ViewCount { get; set; } = 0;

    /// <summary>
    /// Gets or sets the location/campus area where the item is located.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Navigation property: Seller (ApplicationUser)
    /// </summary>
    public virtual ApplicationUser? Seller { get; set; }

    /// <summary>
    /// Navigation property: Category
    /// </summary>
    public virtual Category? Category { get; set; }

    /// <summary>
    /// Navigation property: Cart items containing this listing
    /// </summary>
    public virtual ICollection<CartItem>? CartItems { get; set; }
}
