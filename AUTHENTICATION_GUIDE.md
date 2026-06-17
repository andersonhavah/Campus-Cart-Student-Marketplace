# Campus Cart - Authentication Implementation Guide

## ✅ Completed Implementation

This document outlines the complete ASP.NET Identity authentication system that has been implemented for the Campus Cart Student Marketplace application.

---

## 📋 Overview of Changes

### 1. **NuGet Packages Added**
The following packages were added to support ASP.NET Identity and Entity Framework Core with SQLite:

- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` - ASP.NET Identity with EF Core
- `Microsoft.EntityFrameworkCore.Sqlite` - SQLite database provider
- `Microsoft.EntityFrameworkCore.Design` - EF Core design-time tools

### 2. **Project Structure**

```
Campus-Cart-Student-Marketplace/
├── Models/
│   └── ApplicationUser.cs          ← Custom user model extending IdentityUser
├── Data/
│   └── ApplicationDbContext.cs     ← Database context for Identity
├── Components/Pages/
│   ├── Login.razor                ← Login page
│   ├── Register.razor             ← Registration page
│   ├── Logout.razor               ← Logout page
│   └── AccessDenied.razor         ← Access denied page
├── Migrations/
│   ├── 20260610161323_InitialCreate.cs    ← Initial migration
│   ├── 20260610161323_InitialCreate.Designer.cs
│   └── ApplicationDbContextModelSnapshot.cs
├── Program.cs                     ← Updated with Identity configuration
├── appsettings.json               ← Connection string for SQLite database
└── CampusCart.db                  ← SQLite database file (auto-created)
```

---

## 🔐 Key Features Implemented

### ApplicationUser Model (`Models/ApplicationUser.cs`)
- Extends `IdentityUser` with custom properties:
  - `FullName` - User's full name
  - `ProfilePictureUrl` - User profile picture URL
  - `CreatedAt` - Account creation timestamp
  - `Bio` - User biography
  - `IsActive` - Account status flag

### ApplicationDbContext (`Data/ApplicationDbContext.cs`)
- Inherits from `IdentityDbContext<ApplicationUser>`
- Configured for SQLite database
- Includes automatic migration support
- All Identity tables pre-configured

### Authentication Pages

#### **Login Page** (`Components/Pages/Login.razor`)
- Email and password-based authentication
- Remember me functionality
- Account lockout protection (5 failed attempts = 5-minute lockout)
- Error handling and user feedback
- Loading state indicators

#### **Register Page** (`Components/Pages/Register.razor`)
- Full name, email, and password input
- Password confirmation validation
- Optional bio field
- Email uniqueness validation
- Strong password requirements enforcement
  - Minimum 8 characters
  - Must include uppercase, lowercase, and numeric characters

#### **Logout Page** (`Components/Pages/Logout.razor`)
- Automatic sign-out on page load
- Redirects to home page

#### **Access Denied Page** (`Components/Pages/AccessDenied.razor`)
- User-friendly error page for unauthorized access

### Program.cs Configuration
The application is configured with:

1. **Database Context**
   ```csharp
   builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlite(connectionString));
   ```

2. **Identity Services**
   - Password requirements (8+ chars, uppercase, lowercase, numeric)
   - Lockout policy (5 failed attempts)
   - Email uniqueness requirement
   - Cookie-based authentication

3. **Authentication Middleware**
   ```csharp
   app.UseAuthentication();
   app.UseAuthorization();
   ```

4. **Automatic Migrations**
   - Database migrations are automatically applied on startup

---

## 🗄️ Database

### SQLite Configuration
- **Connection String**: `Data Source=CampusCart.db`
- **Location**: Root project directory
- **File**: `CampusCart.db` (auto-created)

### Identity Tables Created
The migration creates the following tables:

1. **AspNetUsers** - User accounts with identity info
2. **AspNetRoles** - User roles
3. **AspNetUserRoles** - User-role mappings
4. **AspNetUserClaims** - User claims
5. **AspNetUserLogins** - External login information
6. **AspNetUserTokens** - Token storage for password recovery, etc.
7. **AspNetRoleClaims** - Role claims

---

## 🧪 Testing the Authentication System

### 1. **Run the Application**
```bash
dotnet run
```

The application will:
- Start on `https://localhost:5001` (or similar)
- Automatically apply migrations
- Create the SQLite database if it doesn't exist

### 2. **Test Registration**
1. Navigate to `/register`
2. Enter:
   - Full Name: Any name (e.g., "John Doe")
   - Email: A valid email (e.g., "john@example.com")
   - Password: Must be 8+ chars with uppercase, lowercase, and numbers (e.g., "SecurePass123")
   - Confirm Password: Same password
   - Bio: Optional
3. Click "Register"
4. You'll be redirected to login

### 3. **Test Login**
1. Navigate to `/login`
2. Enter:
   - Email: The email you registered with
   - Password: Your password
   - Remember Me: Optional
3. Click "Login"
4. You should be redirected to the home page
5. The user is now authenticated

### 4. **Test Logout**
1. Navigate to `/logout`
2. You'll be signed out and redirected to home

### 5. **Test Lockout**
1. Go to `/login`
2. Enter an email and wrong password
3. Repeat 5 times
4. Account will be locked for 5 minutes

### 6. **Test Access Denied**
1. Navigate to `/access-denied`
2. You should see the access denied message

---

## 📝 Password Requirements

- **Minimum Length**: 8 characters
- **Uppercase Letters**: Required (A-Z)
- **Lowercase Letters**: Required (a-z)
- **Numbers**: Required (0-9)
- **Special Characters**: Not required

**Example Valid Password**: `MyPassword123`

---

## 🔧 Configuration Details

### Password Policy
```csharp
options.Password.RequireDigit = true;
options.Password.RequireLowercase = true;
options.Password.RequireUppercase = true;
options.Password.RequireNonAlphanumeric = false;
options.Password.RequiredLength = 8;
```

### Lockout Policy
```csharp
options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
options.Lockout.MaxFailedAccessAttempts = 5;
```

### Cookie Settings
```csharp
options.Cookie.HttpOnly = true;
options.Cookie.SameSite = SameSiteMode.Strict;
options.ExpireTimeSpan = TimeSpan.FromDays(7);
options.SlidingExpiration = true;
```

---

## 📚 File Descriptions

| File | Purpose |
|------|---------|
| `Models/ApplicationUser.cs` | Custom user class extending IdentityUser |
| `Data/ApplicationDbContext.cs` | Database context with Identity configuration |
| `Components/Pages/Login.razor` | User login form and authentication logic |
| `Components/Pages/Register.razor` | User registration form |
| `Components/Pages/Logout.razor` | User logout functionality |
| `Components/Pages/AccessDenied.razor` | Error page for unauthorized access |
| `Program.cs` | Application startup configuration |
| `appsettings.json` | Database connection string |
| `CampusCart.db` | SQLite database file |
| `Migrations/` | Entity Framework Core migrations |

---

## 🚀 Next Steps

### To Use Authentication in Other Pages
Add the `@using` directives and inject the required services:

```razor
@using Microsoft.AspNetCore.Identity
@using Campus_Cart_Student_Marketplace.Models
@inject SignInManager<ApplicationUser> SignInManager
@inject UserManager<ApplicationUser> UserManager
@inject NavigationManager NavigationManager

@code {
    private ApplicationUser? currentUser;
    
    protected override async Task OnInitializedAsync()
    {
        currentUser = await UserManager.GetUserAsync(HttpContext.User);
    }
}
```

### To Protect Pages with Authorization
Add the `@attribute` directive:

```razor
@page "/protected-page"
@attribute [Authorize]

<h1>Protected Content</h1>
<p>This page is only visible to authenticated users.</p>
```

### To Create Roles
In `Program.cs`, add role creation:

```csharp
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    
    string[] roles = { "Admin", "Seller", "Buyer" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
```

---

## ⚙️ Configuration Options

### To Enable Email Confirmation
Update `Program.cs`:
```csharp
options.SignIn.RequireConfirmedEmail = true;
```

### To Use SQL Server Instead of SQLite
1. Update `.csproj`: Replace `Microsoft.EntityFrameworkCore.Sqlite` with `Microsoft.EntityFrameworkCore.SqlServer`
2. Update `Program.cs`: Replace `UseSqlite()` with `UseSqlServer()`
3. Update `appsettings.json` connection string to SQL Server format

### To Extend ApplicationUser
Add properties to `Models/ApplicationUser.cs`:
```csharp
public string Department { get; set; } = "";
public DateTime DateOfBirth { get; set; }
```

Then create a migration:
```bash
dotnet ef migrations add AddDepartmentAndDateOfBirth
dotnet ef database update
```

---

## 🐛 Troubleshooting

### Database Connection Issues
- Ensure `CampusCart.db` exists in the project root
- Check that the connection string in `appsettings.json` is correct
- Delete `CampusCart.db` and restart the app to regenerate it

### Migration Errors
```bash
# Remove last migration
dotnet ef migrations remove

# Recreate with changes
dotnet ef migrations add YourMigrationName
dotnet ef database update
```

### Build Errors
```bash
# Clean and rebuild
dotnet clean
dotnet build
```

---

## 📖 Resources

- [ASP.NET Core Identity Documentation](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [Entity Framework Core Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations)
- [Blazor Security Documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/security)

---

## ✨ Summary

The Campus Cart application now has a complete, production-ready authentication system with:

✅ User registration with strong password requirements
✅ Secure login with email and password
✅ Account lockout protection
✅ User session management
✅ Authorization framework for future role-based access control
✅ SQLite database for easy development and testing
✅ Clean, user-friendly interface

**The system is ready for use and can be tested immediately!**
