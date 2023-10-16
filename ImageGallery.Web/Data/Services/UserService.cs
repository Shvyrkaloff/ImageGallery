using ImageGallery.Application.Entities.Bases.Filters;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Web.Data.Services.Bases;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ImageGallery.Web.Data.Services;

/// <summary>
/// Class UserService.
/// Implements the <see cref="User" />
/// </summary>
/// <seealso cref="User" />
public class UserService: BaseService<User>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserService" /> class.
    /// </summary>
    /// <param name="clientFactory">The client factory.</param>
    /// <param name="cache">The cache.</param>
    public UserService(IHttpClientFactory clientFactory, IDistributedCache cache) : base(clientFactory, cache)
    {

    }
}