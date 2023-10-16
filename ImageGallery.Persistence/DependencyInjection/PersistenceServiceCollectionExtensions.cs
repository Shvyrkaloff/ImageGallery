using ImageGallery.Application.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImageGallery.Persistence.DependencyInjection;

/// <summary>
/// Class PersistenceServiceCollectionExtensions.
/// </summary>
public static class PersistenceServiceCollectionExtensions
{
    /// <summary>
    /// Adds the persistence.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];

        services.AddDbContext<ImageGalleryDbContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IImageGalleryContext>(provider => provider.GetService<ImageGalleryDbContext>()!);
        return services;
    }
}