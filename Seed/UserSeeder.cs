using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Campus_Cart_Student_Marketplace.Models;

public static class UserSeeder
{
    public static async Task SeedUsersAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        if (!await userManager.Users.AnyAsync())
        {
            var user1 = new ApplicationUser
            {
                FullName = "Faith Oluwatise Idowu",
                UserName = "faithidowu",
                Email = "faith@email.com",
                PhoneNumber = "+2348000000000",
                Address = "Kano, Nigeria",
                Seller = true
            };

            await userManager.CreateAsync(user1, "Password123!");

            var user2 = new ApplicationUser
            {
                FullName = "Anderson Komi Havah",
                UserName = "anderson",
                Email = "anderson@email.com",
                PhoneNumber = "+2348000000001",
                Address = "Abuja, Nigeria",
                Seller = false
            };

            await userManager.CreateAsync(user2, "Password123!");
        }
    }
}