using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Campus_Cart_Student_Marketplace.Services; 
using Campus_Cart_Student_Marketplace.Components;

// 🌟 ADD THIS EXACT LINE TO POINT TO THE ROOT APP COMPONENT:
using Campus_Cart_Student_Marketplace; 

var builder = WebApplication.CreateBuilder(args);

// Add standard Blazor components services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 🌟 ADD THIS EXACT LINE TO SECURE FORMS AND FIX THE RUNTIME CRASH:
builder.Services.AddAntiforgery();

// Your custom workspace scoped services
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<ItemService>();

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
