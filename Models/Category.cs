namespace Campus_Cart_Student_Marketplace.Models;

/// <summary>
/// Category represents a marketplace item category.
/// Categories are used to organize listings and help buyers browse items by type.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets or sets the unique identifier for the category.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category name (e.g., "Textbooks", "Electronics", "Furniture").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the category icon or image URL.
    /// </summary>
    public string? IconUrl { get; set; }

    /// <summary>
    /// Gets or sets the date when the category was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Navigation property: Listings in this category
    /// </summary>
    public virtual ICollection<Listing>? Listings { get; set; }
}
