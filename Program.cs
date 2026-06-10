using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
// 1. ADD THIS LINE AT THE TOP TO BRIDGE THE NAMESPACE:
using Campus_Cart_Student_Marketplace.Services;
using Campus_Cart_Student_Marketplace.Components;
using CampusCart.Services;

var builder = WebApplication.CreateBuilder(args);

// 2. REGISTER YOUR DELIVERABLES FOR DEPENDENCY INJECTION:
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddSingleton<CategoryService>();

// ... (The rest of Anderson's identity and DB service setups remain below)
var app = builder.Build();