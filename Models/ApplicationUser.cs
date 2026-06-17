using Microsoft.AspNetCore.Identity;

namespace Campus_Cart_Student_Marketplace.Models;

/// <summary>
/// ApplicationUser extends IdentityUser to add custom properties for the Campus Cart application.
/// This model represents a user in the system with authentication details and profile information.
/// Users can be either Buyers, Sellers, or both.
/// </summary>
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Gets or sets the user's full name.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the user's profile picture URL or path.
    /// </summary>
    public string? ProfilePictureUrl { get; set; }

    /// <summary>
    /// Gets or sets the date when the user's account was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the user's account bio or description.
    /// </summary>
    public string? Bio { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user's account is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Gets or sets the user's role (Buyer, Seller, Admin).
    /// Users can operate as both Buyer and Seller.
    /// </summary>
    public string UserRole { get; set; } = "Buyer"; // Default to Buyer role

    /// <summary>
    /// Gets or sets a value indicating whether the user is a seller.
    /// This allows users to list items for sale.
    /// </summary>
    public bool IsSellerAccount { get; set; } = false;

    /// <summary>
    /// Gets or sets the seller's business/store name (if they are a seller).
    /// </summary>
    public string? StoreName { get; set; }

    /// <summary>
    /// Gets or sets the seller's average rating.
    /// </summary>
    public decimal? AverageRating { get; set; }

    /// <summary>
    /// Gets or sets the total number of items sold by this seller.
    /// </summary>
    public int ItemsSold { get; set; } = 0;

    /// <summary>
    /// Navigation property: User's listings
    /// </summary>
    public virtual ICollection<Listing>? Listings { get; set; }

    /// <summary>
    /// Navigation property: User's cart items
    /// </summary>
    public virtual ICollection<CartItem>? CartItems { get; set; }
}
