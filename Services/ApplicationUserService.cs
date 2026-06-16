using Campus_Cart_Student_Marketplace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Campus_Cart_Student_Marketplace.Services;

public class ApplicationUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET ALL USERS
    public async Task<List<ApplicationUser>> GetUsers()
    {
        return await _userManager.Users.ToListAsync();
    }

    // GET SINGLE USER
    public async Task<ApplicationUser?> GetUser(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    // CREATE USER
    public async Task<bool> AddUser(ApplicationUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }

    // UPDATE USER
    public async Task<bool> UpdateUser(ApplicationUser user)
    {
        var existing = await _userManager.FindByIdAsync(user.Id);

        if (existing == null)
            return false;

        existing.FullName = user.FullName;
        existing.PhoneNumber = user.PhoneNumber;
        existing.Address = user.Address;
        existing.Seller = user.Seller;

        var result = await _userManager.UpdateAsync(existing);
        return result.Succeeded;
    }

    // DELETE USER
    public async Task<bool> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return false;

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }
}