using Application;
using Application.Services.Items;
using Application.Services.Orders;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

builder.Services.AddHttpContextAccessor();

//builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<CustomerOrderManagementContext>();
    dbContext.Database.Migrate();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }
}
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.MapGet("/order", async (IOrderService orderService) => orderService.GetAllOrders());
app.MapGet("/item", async (IItemService itemService) => itemService.GetAllItems());

app.MapGet("/order/{id}", (Guid id, IOrderService orderService) =>
{
    var order = orderService.GetOrderById(id);
    return order is null ? Results.NotFound() : Results.Ok(order);
});

app.MapGet("/item/{id}", (Guid id, IItemService itemService) =>
{
    var item = itemService.GetItemById(id);
    return item is null ? Results.NotFound() : Results.Ok(item);
});

app.Run();