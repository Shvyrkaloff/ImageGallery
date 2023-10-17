using ImageGallery.Application.Entities.FriendUsers.Domains;
using ImageGallery.Web.Data.Services.Bases;
using Microsoft.Extensions.Caching.Distributed;

namespace ImageGallery.Web.Data.Services;

/// <summary>
/// Class FriendUserService.
/// Implements the <see cref="ImageGallery.Web.Data.Services.Bases.BaseService{ImageGallery.Application.Entities.Users.Domains.User}" />
/// </summary>
/// <seealso cref="ImageGallery.Web.Data.Services.Bases.BaseService{ImageGallery.Application.Entities.Users.Domains.User}" />
public class FriendUserService : BaseService<FriendUser>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FriendUserService"/> class.
    /// </summary>
    /// <param name="clientFactory">The client factory.</param>
    /// <param name="cache">The cache.</param>
    public FriendUserService(IHttpClientFactory clientFactory, IDistributedCache cache) : base(clientFactory, cache)
    {
    }
}