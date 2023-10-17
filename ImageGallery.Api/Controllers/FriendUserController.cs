using ImageGallery.Api.Controllers.Bases;
using ImageGallery.Application.Entities.FriendUsers.Domains;
using ImageGallery.Application.Entities.FriendUsers.Interfaces;

namespace ImageGallery.Api.Controllers;

/// <summary>
/// Class FriendUserController.
/// Implements the <see cref="ImageGallery.Api.Controllers.Bases.BaseController{ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser, ImageGallery.Application.Entities.FriendUsers.Interfaces.IFriendUserRepository}" />
/// </summary>
/// <seealso cref="ImageGallery.Api.Controllers.Bases.BaseController{ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser, ImageGallery.Application.Entities.FriendUsers.Interfaces.IFriendUserRepository}" />
public class FriendUserController : BaseController<FriendUser, IFriendUserRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="env">The env.</param>
    public FriendUserController(IFriendUserRepository repository, IWebHostEnvironment env) : base(repository, env)
    {
    }
}