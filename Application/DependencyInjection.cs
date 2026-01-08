using Application.Services.Authentication;
using Application.Services.Items;
using Application.Services.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IItemService, ItemService>();

        return services;
    }
}
