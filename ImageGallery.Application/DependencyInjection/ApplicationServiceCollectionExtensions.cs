using ImageGallery.Application.Entities.Files.Interfaces;
using ImageGallery.Application.Entities.Files.Repositories;
using ImageGallery.Application.Entities.Friends.Interfaces;
using ImageGallery.Application.Entities.Friends.Repositories;
using ImageGallery.Application.Entities.Users.Interfaces;
using ImageGallery.Application.Entities.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ImageGallery.Application.DependencyInjection;

/// <summary>
/// Class ApplicationServiceCollectionExtensions.
/// </summary>
public static class ApplicationServiceCollectionExtensions
{
    /// <summary>
    /// Adds the application.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IImageFileRepository, ImageFileRepository>();
        serviceCollection.AddScoped<IFriendRepository, FriendRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        
        return serviceCollection;
    }
}