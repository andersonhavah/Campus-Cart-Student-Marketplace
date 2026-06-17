using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Cart_Student_Marketplace.Services;

/// <summary>
/// ListingService handles all marketplace listing operations.
/// It manages creating, reading, updating, and deleting listings.
/// </summary>
public class ListingService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ListingService> _logger;

    public ListingService(ApplicationDbContext context, ILogger<ListingService> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new listing in the marketplace.
    /// </summary>
    /// <param name="listing">The listing to create</param>
    /// <returns>The created listing with ID</returns>
    public async Task<Listing> CreateListingAsync(Listing listing)
    {
        try
        {
            if (string.IsNullOrEmpty(listing.Title) || string.IsNullOrEmpty(listing.SellerId))
            {
                throw new ArgumentException("Title and SellerId are required.");
            }

            listing.CreatedAt = DateTime.UtcNow;
            listing.UpdatedAt = DateTime.UtcNow;
            listing.ViewCount = 0;

            await _context.Listings.AddAsync(listing);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Created listing {listing.ListingId} by seller {listing.SellerId}");
            return listing;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating listing");
            throw;
        }
    }

    /// <summary>
    /// Retrieves a listing by ID with all related data.
    /// </summary>
    /// <param name="listingId">The ID of the listing</param>
    /// <returns>The listing or null if not found</returns>
    public async Task<Listing?> GetListingAsync(int listingId)
    {
        try
        {
            return await _context.Listings
                .Include(l => l.Seller)
                .Include(l => l.Category)
                .FirstOrDefaultAsync(l => l.ListingId == listingId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving listing {listingId}");
            throw;
        }
    }

    /// <summary>
    /// Gets all available listings with pagination and filtering.
    /// </summary>
    /// <param name="categoryId">Optional: filter by category ID</param>
    /// <param name="searchTerm">Optional: search term for title/description</param>
    /// <param name="pageNumber">Page number (1-based)</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <returns>List of listings</returns>
    public async Task<List<Listing>> GetListingsAsync(int? categoryId = null, string? searchTerm = null, int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            var query = _context.Listings
                .Where(l => l.IsAvailable)
                .Include(l => l.Seller)
                .Include(l => l.Category)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(l => l.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var searchLower = searchTerm.ToLower();
                query = query.Where(l =>
                    l.Title.ToLower().Contains(searchLower) ||
                    l.Description.ToLower().Contains(searchLower));
            }

            return await query
                .OrderByDescending(l => l.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving listings");
            throw;
        }
    }

    /// <summary>
    /// Gets all listings created by a specific seller.
    /// </summary>
    /// <param name="sellerId">The ID of the seller</param>
    /// <returns>List of seller's listings</returns>
    public async Task<List<Listing>> GetSellerListingsAsync(string sellerId)
    {
        try
        {
            return await _context.Listings
                .Where(l => l.SellerId == sellerId)
                .Include(l => l.Category)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving listings for seller {sellerId}");
            throw;
        }
    }

    /// <summary>
    /// Updates an existing listing (only if user is the owner).
    /// </summary>
    /// <param name="listingId">The ID of the listing</param>
    /// <param name="updatedListing">The updated listing data</param>
    /// <param name="userId">The ID of the user making the update</param>
    /// <returns>The updated listing</returns>
    public async Task<Listing?> UpdateListingAsync(int listingId, Listing updatedListing, string userId)
    {
        try
        {
            var listing = await _context.Listings.FindAsync(listingId);
            if (listing == null)
            {
                return null;
            }

            // Check authorization: only owner can edit
            if (listing.SellerId != userId)
            {
                throw new UnauthorizedAccessException("You can only edit your own listings.");
            }

            listing.Title = updatedListing.Title;
            listing.Description = updatedListing.Description;
            listing.Price = updatedListing.Price;
            listing.CategoryId = updatedListing.CategoryId;
            listing.ImageUrl = updatedListing.ImageUrl;
            listing.Condition = updatedListing.Condition;
            listing.Location = updatedListing.Location;
            listing.UpdatedAt = DateTime.UtcNow;

            _context.Listings.Update(listing);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Updated listing {listingId} by user {userId}");
            return listing;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating listing {listingId}");
            throw;
        }
    }

    /// <summary>
    /// Deletes a listing (only if user is the owner).
    /// </summary>
    /// <param name="listingId">The ID of the listing</param>
    /// <param name="userId">The ID of the user making the deletion</param>
    /// <returns>True if deleted, false if not found</returns>
    public async Task<bool> DeleteListingAsync(int listingId, string userId)
    {
        try
        {
            var listing = await _context.Listings.FindAsync(listingId);
            if (listing == null)
            {
                return false;
            }

            // Check authorization: only owner can delete
            if (listing.SellerId != userId)
            {
                throw new UnauthorizedAccessException("You can only delete your own listings.");
            }

            // Delete associated cart items
            var cartItems = await _context.CartItems
                .Where(ci => ci.ListingId == listingId)
                .ToListAsync();
            _context.CartItems.RemoveRange(cartItems);

            // Delete listing
            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Deleted listing {listingId} by user {userId}");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting listing {listingId}");
            throw;
        }
    }

    /// <summary>
    /// Marks a listing as unavailable.
    /// </summary>
    /// <param name="listingId">The ID of the listing</param>
    /// <param name="userId">The ID of the user (must be owner)</param>
    /// <returns>The updated listing</returns>
    public async Task<Listing?> DelistAsync(int listingId, string userId)
    {
        try
        {
            var listing = await _context.Listings.FindAsync(listingId);
            if (listing == null)
            {
                return null;
            }

            if (listing.SellerId != userId)
            {
                throw new UnauthorizedAccessException("You can only delist your own listings.");
            }

            listing.IsAvailable = false;
            listing.UpdatedAt = DateTime.UtcNow;
            _context.Listings.Update(listing);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Delisted listing {listingId} by user {userId}");
            return listing;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error delisting listing {listingId}");
            throw;
        }
    }

    /// <summary>
    /// Increments the view count for a listing.
    /// </summary>
    /// <param name="listingId">The ID of the listing</param>
    public async Task IncrementViewCountAsync(int listingId)
    {
        try
        {
            var listing = await _context.Listings.FindAsync(listingId);
            if (listing != null)
            {
                listing.ViewCount++;
                _context.Listings.Update(listing);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error incrementing view count for listing {listingId}");
        }
    }

    /// <summary>
    /// Gets all available categories.
    /// </summary>
    /// <returns>List of categories</returns>
    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            return await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving categories");
            throw;
        }
    }

    /// <summary>
    /// Gets a category by ID.
    /// </summary>
    /// <param name="categoryId">The ID of the category</param>
    /// <returns>The category or null if not found</returns>
    public async Task<Category?> GetCategoryAsync(int categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }
}
