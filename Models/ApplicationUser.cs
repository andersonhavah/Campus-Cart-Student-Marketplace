using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Campus_Cart_Student_Marketplace.Models
{
    // Inherits directly from ASP.NET Core Identity
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        
        // One user can have many marketplace listings
        public List<Item> Listings { get; set; } = new();
    }
}