using ImageGallery.Api.Controllers.Bases;
using ImageGallery.Application.Entities.Friends.Domains;
using ImageGallery.Application.Entities.Friends.Interfaces;

namespace ImageGallery.Api.Controllers;

/// <summary>
/// Class FriendController.
/// Implements the <see cref="ImageGallery.Api.Controllers.Bases.BaseController{ImageGallery.Application.Entities.Friends.Domains.Friend, ImageGallery.Application.Entities.Friends.Interfaces.IFriendRepository}" />
/// </summary>
/// <seealso cref="ImageGallery.Api.Controllers.Bases.BaseController{ImageGallery.Application.Entities.Friends.Domains.Friend, ImageGallery.Application.Entities.Friends.Interfaces.IFriendRepository}" />
public class FriendController : BaseController<Friend, IFriendRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FriendController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="env">The env.</param>
    public FriendController(IFriendRepository repository, IWebHostEnvironment env) : base(repository, env)
    {

    }
}