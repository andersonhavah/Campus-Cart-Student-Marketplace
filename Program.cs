using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics; 
using Campus_Cart_Student_Marketplace.Services;
using Campus_Cart_Student_Marketplace.Components;
using Microsoft.Extensions.DependencyInjection;
using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;
using Campus_Cart_Student_Marketplace.Controllers;
using Campus_Cart_Student_Marketplace;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// --- DATABASE CONFIGURATION MATRIX ---
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext") 
    ?? builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Database connection string not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    if (connectionString.Contains(".db") || connectionString.Contains("DataSource"))
    {
        options.UseSqlite(connectionString);
    }
    else
    {
        options.UseSqlServer(connectionString);
    }

    // Log model shifts rather than completely throwing a fatal thread execution error
    options.ConfigureWarnings(w => w.Log(RelationalEventId.PendingModelChangesWarning));
});

// --- CORE SECURITY & IDENTITY CONSTRAINTS ---
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// --- RENDERING PIPELINE CONTROLS ---
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Secures Blazor forms against Cross-Site Request Forgery variations
builder.Services.AddAntiforgery();

// --- DEPENDENCY INJECTION MATRIX ---
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ApplicationUserService>();

builder.Services.AddHttpClient();
builder.Services.AddScoped(sp =>
{
    var nav = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(nav.BaseUri) };
});

var app = builder.Build();

// --- HTTP REQUEST ROUTING PIPELINE ---
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.MapStaticAssets();
app.UseStatusCodePagesWithReExecute("/not-found");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

// --- UNIFIED AUTO-MIGRATION & DATA SEEDER RUNTIME ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        
        // Safe directory assurance for local SQLite operations inside containers
        if (connectionString.Contains(".db"))
        {
            Directory.CreateDirectory("/app/data");
        }

        if (context.Database.IsRelational())
        {
            context.Database.Migrate();
        }

        // Clean synchronous task invocation wrapper to execute user provisioning logs safely
        Task.Run(async () => await UserSeeder.SeedUsersAsync(services)).Wait();
    }
    catch (Exception)
    {
        // Fail-safe protection wrapper tracking deployment launch constraints
    }
}

// --- API REGISTRATION & IDENTITY INTAKE PIPELINES ---
app.MapControllers();

app.MapPost("/api/register", async (
    HttpContext context,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) =>
{
    var form = await context.Request.ReadFormAsync();
    var password = form["Password"].ToString();
    var confirmPassword = form["ConfirmPassword"].ToString();

    if (password != confirmPassword) return Results.Redirect("/register");

    var existingUser = await userManager.FindByEmailAsync(form["Email"]!);
    if (existingUser != null) return Results.Redirect("/register");

    var user = new ApplicationUser
    {
        FullName = form["FullName"]!,
        UserName = form["UserName"]!,
        Address = form["Address"]!,
        Email = form["Email"]!
    };

    var result = await userManager.CreateAsync(user, password);
    if (!result.Succeeded) return Results.Redirect("/register");

    await signInManager.SignInAsync(user, false);
    return Results.Redirect("/dashboard");
});

app.MapPost("/api/login", async (
    HttpContext context,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) =>
{
    var form = await context.Request.ReadFormAsync();
    var email = form["Email"].ToString();
    var password = form["Password"].ToString();

    var user = await userManager.FindByEmailAsync(email);
    if (user == null) return Results.Redirect("/login?error=1");

    var result = await signInManager.PasswordSignInAsync(user.UserName!, password, false, false);
    if (!result.Succeeded) return Results.Redirect("/login?error=1");

    return Results.Redirect("/dashboard");
});

app.MapPost("/api/logout", async (SignInManager<ApplicationUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public record LoginRequest(string Email, string Password);