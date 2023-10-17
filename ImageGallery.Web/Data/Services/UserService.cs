using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Application.Models;
using ImageGallery.Web.Data.Services.Bases;
using Microsoft.Extensions.Caching.Distributed;

namespace ImageGallery.Web.Data.Services;

/// <summary>
/// Class UserService.
/// Implements the <see cref="User" />
/// </summary>
/// <seealso cref="User" />
public class UserService: BaseService<User>
{
    /// <summary>
    /// The HTTP client
    /// </summary>
    protected readonly HttpClient? _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService" /> class.
    /// </summary>
    /// <param name="clientFactory">The client factory.</param>
    /// <param name="cache">The cache.</param>
    public UserService(IHttpClientFactory clientFactory, IDistributedCache cache) : base(clientFactory, cache)
    {
        _httpClient = clientFactory.CreateClient("API");
    }

    /// <summary>
    /// Add friendship as an asynchronous operation.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public virtual async Task<HttpResponseMessage> AddFriendshipAsync(FriendModel query)
    {
        var responseMessage = await _httpClient?.PostAsJsonAsync($"api/user/AddFriendship", query)!;
        return responseMessage;
    }

    /// <summary>
    /// Remove friendship as an asynchronous operation.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>A Task&lt;HttpResponseMessage&gt; representing the asynchronous operation.</returns>
    public virtual async Task<HttpResponseMessage> RemoveFriendshipAsync(FriendModel query)
    {
        var responseMessage = await _httpClient?.PostAsJsonAsync($"api/user/RemoveFriendship", query)!;
        return responseMessage;
    }
}