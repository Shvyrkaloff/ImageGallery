using ImageGallery.Api.Controllers.Bases;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Application.Entities.Users.Interfaces;

namespace ImageGallery.Api.Controllers;

/// <summary>
/// Class UserController.
/// Implements the <see cref="ImageGallery.Api.Controllers.Bases.BaseController{ImageGallery.Application.Entities.Users.Domains.User, ImageGallery.Application.Entities.Users.Interfaces.IUserRepository}" />
/// </summary>
/// <seealso cref="ImageGallery.Api.Controllers.Bases.BaseController{ImageGallery.Application.Entities.Users.Domains.User, ImageGallery.Application.Entities.Users.Interfaces.IUserRepository}" />
public class UserController : BaseController<User, IUserRepository>
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="env">The env.</param>
    public UserController(IUserRepository repository, IWebHostEnvironment env) : base(repository, env)
    {
        _userRepository = repository;
    }
}