using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Cart_Student_Marketplace.Services;

/// <summary>
/// CartService handles all shopping cart operations for the Campus Cart application.
/// It manages adding/removing items, updating quantities, and retrieving cart data.
/// </summary>
public class CartService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CartService> _logger;

    /// <summary>
    /// Event triggered when the cart changes (item added/removed/quantity changed).
    /// Subscribers can use this to update UI elements like cart badges.
    /// </summary>
    public event Action? OnCartChanged;

    public CartService(ApplicationDbContext context, ILogger<CartService> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Adds an item to the user's cart, or increments quantity if already in cart.
    /// </summary>
    /// <param name="userId">The ID of the user adding the item</param>
    /// <param name="listingId">The ID of the listing to add</param>
    /// <param name="quantity">The quantity to add (default 1)</param>
    /// <returns>The updated CartItem</returns>
    public async Task<CartItem> AddToCartAsync(string userId, int listingId, int quantity = 1)
    {
        try
        {
            // Check if listing exists and is available
            var listing = await _context.Listings.FindAsync(listingId);
            if (listing == null || !listing.IsAvailable)
            {
                throw new InvalidOperationException($"Listing {listingId} is not available.");
            }

            // Check if item already in cart
            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ListingId == listingId);

            CartItem cartItem;
            if (existingCartItem != null)
            {
                // Increment quantity
                existingCartItem.Quantity += quantity;
                _context.CartItems.Update(existingCartItem);
                cartItem = existingCartItem;
                _logger.LogInformation($"Incremented quantity for listing {listingId} in user {userId}'s cart");
            }
            else
            {
                // Add new item to cart
                cartItem = new CartItem
                {
                    UserId = userId,
                    ListingId = listingId,
                    Quantity = quantity,
                    AddedAt = DateTime.UtcNow
                };
                await _context.CartItems.AddAsync(cartItem);
                _logger.LogInformation($"Added listing {listingId} to user {userId}'s cart");
            }

            await _context.SaveChangesAsync();
            OnCartChanged?.Invoke();

            return cartItem;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error adding item to cart for user {userId}");
            throw;
        }
    }

    /// <summary>
    /// Removes an item from the user's cart.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <param name="listingId">The ID of the listing to remove</param>
    /// <returns>True if item was removed, false if not found</returns>
    public async Task<bool> RemoveFromCartAsync(string userId, int listingId)
    {
        try
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ListingId == listingId);

            if (cartItem == null)
            {
                return false;
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            OnCartChanged?.Invoke();

            _logger.LogInformation($"Removed listing {listingId} from user {userId}'s cart");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error removing item from cart for user {userId}");
            throw;
        }
    }

    /// <summary>
    /// Updates the quantity of an item in the cart.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <param name="listingId">The ID of the listing</param>
    /// <param name="newQuantity">The new quantity</param>
    /// <returns>The updated CartItem, or null if not found</returns>
    public async Task<CartItem?> UpdateQuantityAsync(string userId, int listingId, int newQuantity)
    {
        try
        {
            if (newQuantity <= 0)
            {
                await RemoveFromCartAsync(userId, listingId);
                return null;
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ListingId == listingId);

            if (cartItem == null)
            {
                return null;
            }

            cartItem.Quantity = newQuantity;
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
            OnCartChanged?.Invoke();

            _logger.LogInformation($"Updated quantity for listing {listingId} in user {userId}'s cart to {newQuantity}");
            return cartItem;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating quantity in cart for user {userId}");
            throw;
        }
    }

    /// <summary>
    /// Gets all items in the user's cart with related listing and category data.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>List of CartItems with all related data loaded</returns>
    public async Task<List<CartItem>> GetCartAsync(string userId)
    {
        try
        {
            return await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Listing)
                    .ThenInclude(l => l!.Category)
                .Include(ci => ci.Listing)
                    .ThenInclude(l => l!.Seller)
                .OrderByDescending(ci => ci.AddedAt)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving cart for user {userId}");
            throw;
        }
    }

    /// <summary>
    /// Gets the total number of items in the user's cart.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>Total item count</returns>
    public async Task<int> GetCartCountAsync(string userId)
    {
        try
        {
            return await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .SumAsync(ci => ci.Quantity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting cart count for user {userId}");
            return 0;
        }
    }

    /// <summary>
    /// Gets the total price of all items in the user's cart.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>Total price</returns>
    public async Task<decimal> GetCartTotalAsync(string userId)
    {
        try
        {
            return await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Listing)
                .SumAsync(ci => ci.Listing!.Price * ci.Quantity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting cart total for user {userId}");
            return 0;
        }
    }

    /// <summary>
    /// Clears all items from the user's cart.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    public async Task ClearCartAsync(string userId)
    {
        try
        {
            var cartItems = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .ToListAsync();

            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
            OnCartChanged?.Invoke();

            _logger.LogInformation($"Cleared cart for user {userId}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error clearing cart for user {userId}");
            throw;
        }
    }

    /// <summary>
    /// Checks if a listing is already in the user's cart.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <param name="listingId">The ID of the listing</param>
    /// <returns>True if in cart, false otherwise</returns>
    public async Task<bool> IsInCartAsync(string userId, int listingId)
    {
        return await _context.CartItems
            .AnyAsync(ci => ci.UserId == userId && ci.ListingId == listingId);
    }
}
