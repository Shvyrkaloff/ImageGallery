using HttpService.Services;
using ImageGallery.Web.Data.Authentication;
using ImageGallery.Web.Data.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace ImageGallery.Web.DependencyInjection;

/// <summary>
/// Class WebServiceCollectionExtensions.
/// </summary>
public static class WebServiceCollectionExtensions
{
    /// <summary>
    /// Adds the web collection.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddWebCollection(this IServiceCollection serviceCollection)
    {
        #region ПОДКЛЮЧЕНИЕ СЕРВИСОВ

        serviceCollection.AddSingleton<AuthenticationService>();
        serviceCollection.AddSingleton<UserService>();
        serviceCollection.AddSingleton<ImageFileService>();
        serviceCollection.AddSingleton<FriendUserService>();

        #endregion

        serviceCollection.AddTransient<WebsiteAuthenticator>();
        serviceCollection.AddTransient<AuthenticationStateProvider>(sp => sp.GetRequiredService<WebsiteAuthenticator>());

        serviceCollection.AddHttpClient("API", client =>
        {
            client.BaseAddress = new Uri("https://localhost:7267");
        });

        return serviceCollection;
    }
}