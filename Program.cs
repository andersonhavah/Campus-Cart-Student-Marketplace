using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
// 1. ADD THIS LINE AT THE TOP TO BRIDGE THE NAMESPACE:
using Campus_Cart_Student_Marketplace.Services;
using Campus_Cart_Student_Marketplace.Components;

var builder = WebApplication.CreateBuilder(args);

// 2. REGISTER YOUR DELIVERABLES FOR DEPENDENCY INJECTION:
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddSingleton<CategoryService>();

// ... (The rest of Anderson's identity and DB service setups remain below)
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();