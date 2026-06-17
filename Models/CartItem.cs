namespace Campus_Cart_Student_Marketplace.Models;

/// <summary>
/// CartItem represents an item in a user's shopping cart.
/// Users can add listings to their cart before contacting sellers.
/// </summary>
public class CartItem
{
    /// <summary>
    /// Gets or sets the unique identifier for the cart item.
    /// </summary>
    public int CartItemId { get; set; }

    /// <summary>
    /// Gets or sets the buyer's user ID (foreign key to ApplicationUser).
    /// </summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the listing ID (foreign key to Listing).
    /// </summary>
    public int ListingId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of this item in the cart.
    /// </summary>
    public int Quantity { get; set; } = 1;

    /// <summary>
    /// Gets or sets the date when the item was added to the cart.
    /// </summary>
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Navigation property: User (ApplicationUser)
    /// </summary>
    public virtual ApplicationUser? User { get; set; }

    /// <summary>
    /// Navigation property: Listing
    /// </summary>
    public virtual Listing? Listing { get; set; }
}
