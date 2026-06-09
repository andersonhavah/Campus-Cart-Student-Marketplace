using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Campus_Cart_Student_Marketplace.Models
{
    // Inherits directly from ASP.NET Core Identity
    public class ApplicationUser : IdentityUser
    {
        // Custom student profile extensions
        public string FullName { get; set; } = string.Empty;

        // Navigation tracking for seller property linkages
        public List<Item> Listings { get; set; } = new();
    }
}