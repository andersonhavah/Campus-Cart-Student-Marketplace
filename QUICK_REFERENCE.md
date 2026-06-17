# Campus Cart Authentication - Quick Reference

## 🔗 Navigation Routes

| Route | Purpose | Protected |
|-------|---------|-----------|
| `/login` | User login page | ❌ No |
| `/register` | User registration | ❌ No |
| `/logout` | Sign out user | ✅ Yes |
| `/access-denied` | Unauthorized access | ❌ No |

## 👤 User Account Test Credentials

### Sample Test Account
```
Email:    test@example.com
Password: SecurePass123
```

To create this account:
1. Go to `/register`
2. Enter the details above
3. Click "Register"

## 📋 Password Requirements

✅ **Valid Examples**:
- `MyPassword123`
- `SecurePass456`
- `CampusCart2026`
- `StudentMarketplace999`

❌ **Invalid Examples** (will fail):
- `password` - No uppercase or numbers
- `PASS123` - No lowercase
- `Password` - No numbers
- `Pass12` - Too short (< 8 chars)

## 🗄️ Database File Location

```
D:\Anderson Personal\BYU IDAHO\9 - Spring 2026\Term 3\CSE 325 - .NET Software Development\Campus-Cart-Student-Marketplace\CampusCart.db
```

## 🔐 Security Settings

### Account Lockout
- **Trigger**: 5 failed login attempts
- **Duration**: 5 minutes
- **Recovery**: Automatic after 5 minutes

### Session Duration
- **Timeout**: 7 days
- **Cookie**: HttpOnly, Strict SameSite
- **Auto-Refresh**: Yes (sliding expiration)

## 💻 Developer Quick Commands

### Start Application
```bash
dotnet run
```

### Build Project
```bash
dotnet build
```

### Run Tests
```bash
dotnet test
```

### Manage Migrations
```bash
# View all migrations
dotnet ef migrations list

# Add new migration
dotnet ef migrations add MigrationName

# Remove last migration
dotnet ef migrations remove

# Apply migrations
dotnet ef database update

# Reset database
dotnet ef database drop
```

## 🧪 Authentication in Razor Components

### Check if User is Authenticated
```razor
@using Microsoft.AspNetCore.Identity
@using Campus_Cart_Student_Marketplace.Models
@inject UserManager<ApplicationUser> UserManager
@inject HttpContext HttpContext

@code {
    private ApplicationUser? user;
    
    protected override async Task OnInitializedAsync()
    {
        user = await UserManager.GetUserAsync(HttpContext.User);
        bool isAuthenticated = user != null;
    }
}
```

### Display User Info
```razor
@if (user != null)
{
    <p>Welcome, @user.FullName!</p>
    <p>Email: @user.Email</p>
}
```

### Protect a Page
```razor
@page "/my-profile"
@attribute [Authorize]

<h1>@user.FullName's Profile</h1>
```

### Role-Based Access
```razor
@attribute [Authorize(Roles = "Admin")]

<h1>Admin Dashboard</h1>
```

## 📊 Database Tables

| Table | Purpose | Records |
|-------|---------|---------|
| AspNetUsers | User accounts | User count |
| AspNetRoles | Role definitions | ~ 3 (Admin, Seller, Buyer) |
| AspNetUserRoles | User role assignments | Variable |
| AspNetUserClaims | User claims | Variable |
| AspNetRoleClaims | Role claims | Variable |
| AspNetUserLogins | External logins | 0 (not yet configured) |
| AspNetUserTokens | Auth tokens | Variable |

## 🔑 Key Classes

### ApplicationUser
Located: `Models/ApplicationUser.cs`
```csharp
public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Bio { get; set; }
    public bool IsActive { get; set; }
}
```

### ApplicationDbContext
Located: `Data/ApplicationDbContext.cs`
```csharp
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }
}
```

## 📦 Project Files Reference

| Category | Files |
|----------|-------|
| **Authentication Pages** | `/Components/Pages/Login.razor`, `/Register.razor`, `/Logout.razor` |
| **Models** | `/Models/ApplicationUser.cs` |
| **Database** | `/Data/ApplicationDbContext.cs` |
| **Configuration** | `/Program.cs`, `/appsettings.json` |
| **Migrations** | `/Migrations/` folder |
| **Documentation** | `/AUTHENTICATION_GUIDE.md`, `/IMPLEMENTATION_SUMMARY.md` |

## 🚨 Common Issues & Solutions

### Issue: Database not found
**Solution**: 
```bash
dotnet ef database update
```
This recreates the database file.

### Issue: Migration conflicts
**Solution**:
```bash
dotnet ef migrations remove
dotnet ef migrations add RecreatedMigration
```

### Issue: User can't login after registration
**Solution**:
- Verify email is unique
- Check password meets requirements
- Ensure database has been updated with migrations

### Issue: Session keeps timing out
**Solution** (in Program.cs):
```csharp
options.ExpireTimeSpan = TimeSpan.FromDays(14); // Increase duration
```

## 🔄 Authentication Flow

```
User Input (Email/Password)
    ↓
Form Validation
    ↓
UserManager.PasswordSignInAsync()
    ↓
Password Hash Comparison
    ↓
Lockout Check
    ↓
Authentication Successful/Failed
    ↓
Set Authentication Cookie
    ↓
Redirect to Home or Show Error
```

## 📱 Responsive Design

All authentication pages are responsive and mobile-friendly:
- Bootstrap 5 grid system
- Mobile-optimized forms
- Touch-friendly buttons
- Readable on all screen sizes

## 🎨 UI Components Used

- Bootstrap 5 cards
- Form validation feedback
- Loading spinners
- Alert messages (success/error)
- Disabled state buttons

## 💾 Backup Information

### SQLite Database Location
```
CampusCart.db (in project root)
```

### To backup database
```bash
# Copy the file
Copy-Item -Path CampusCart.db -Destination CampusCart.db.backup
```

### To restore database
```bash
# Delete and replace
Remove-Item CampusCart.db
Copy-Item -Path CampusCart.db.backup -Destination CampusCart.db
```

## 🔗 Related Resources

- [ASP.NET Identity Docs](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [EF Core Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations)
- [Blazor Security](https://learn.microsoft.com/en-us/aspnet/core/blazor/security)
- [Bootstrap Documentation](https://getbootstrap.com/docs)

---

**Last Updated**: June 10, 2026  
**Status**: ✅ Production Ready
