using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services;

public class ApplicationUserService 
{
    private readonly List<ApplicationUser> _users = new();

    public ApplicationUserService()
    {
        _users.Add(new ApplicationUser
        {
            FullName = "Faith Oluwatise Idowu",
            Username = "faithidowu",
            Email = "faith@email.com",
            PhoneNumber = "+2348000000000",
            Address = "Kano, Nigeria",
            Seller = true
        });

        _users.Add(new ApplicationUser
        {
            FullName = "Anderson Komi Havah",
            Username = "anderson",
            Email = "anderson@email.com",
            PhoneNumber = "+2348000000001",
            Address = "Abuja, Nigeria",
            Seller = false
        });
    }

    public List<ApplicationUser> GetUsers()
    {
        return _users;
    }

    public ApplicationUser? GetUser(string id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public void AddUser(ApplicationUser user)
    {
        _users.Add(user);
    }

    public void UpdateUser(ApplicationUser user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);

        if (existingUser is null)
            return;

        existingUser.FullName = user.FullName;
        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.Address = user.Address;
        existingUser.Seller = user.Seller;
        existingUser.Listings = user.Listings;
    }

    public void DeleteUser(string id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);

        if (user is not null)
        {
            _users.Remove(user);
        }
    }
}