using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Authentication;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Application.Common.Interface.Authentication;
using Application.Common.Interface.Persistence;
using Application.Common.Interface.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // FIX: Add this using directive
using Microsoft.Extensions.DependencyInjection; // FIX: Add this using directive
using Microsoft.AspNetCore.Identity; // FIX: Ensure correct using for AddIdentity

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        
        // Add DbContext
        services.AddDbContext<CustomerOrderManagementContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // FIX: Ensure AddIdentity extension method is available by referencing the correct NuGet package and using directive
        services.AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CustomerOrderManagementContext>();

        return services;
    }
}

// Ensure the following NuGet package is installed in your project:
// Microsoft.AspNetCore.Identity.EntityFrameworkCore
