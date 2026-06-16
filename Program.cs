using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
// 1. ADD THIS LINE AT THE TOP TO BRIDGE THE NAMESPACE:
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Campus_Cart_Student_Marketplace.Services;
using Campus_Cart_Student_Marketplace.Components;
using Microsoft.Extensions.DependencyInjection;
using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;
using Campus_Cart_Student_Marketplace.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ApplicationUserService>();
builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddScoped(sp =>
{
    var nav = sp.GetRequiredService<NavigationManager>();

    return new HttpClient
    {
        BaseAddress = new Uri(nav.BaseUri)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapStaticAssets();
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();



using (var scope = app.Services.CreateScope())
{
    await UserSeeder.SeedUsersAsync(scope.ServiceProvider);
}

app.MapControllers();

app.MapPost("/api/auth/register",
async (
    HttpContext context,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) =>
{
    var form = await context.Request.ReadFormAsync();

    var password = form["Password"].ToString();
    var confirmPassword = form["ConfirmPassword"].ToString();

    if (password != confirmPassword)
        return Results.Redirect("/register");

    var existingUser =
        await userManager.FindByEmailAsync(
            form["Email"]);

    if (existingUser != null)
        return Results.Redirect("/register");

    var user = new ApplicationUser
    {
        FullName = form["FullName"],
        UserName = form["UserName"],
        Address = form["Address"],
        Email = form["Email"]
    };

    var result =
        await userManager.CreateAsync(
            user,
            password);

    if (!result.Succeeded)
        return Results.Redirect("/register");

    await signInManager.SignInAsync(
        user,
        false);

    return Results.Redirect("/dashboard");
});

app.MapPost("/api/login", async (
    HttpContext context,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) =>
{
    var form = await context.Request.ReadFormAsync();

    var email = form["Email"];
    var password = form["Password"];

    var user = await userManager.FindByEmailAsync(email!);

    if (user == null)
        return Results.Redirect("/login?error=1");

    var result = await signInManager.PasswordSignInAsync(
        user.UserName!,
        password!,
        false,
        false);

    if (!result.Succeeded)
        return Results.Redirect("/login?error=1");

    return Results.Redirect("/dashboard");
});

app.MapPost("/api/logout", async (
    SignInManager<ApplicationUser> signInManager) =>
{
    await signInManager.SignOutAsync();

    return Results.Ok();
});


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


public record LoginRequest(
    string Email,
    string Password);