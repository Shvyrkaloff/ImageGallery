using ImageGallery.Application.Context;
using ImageGallery.Application.Entities.Bases.Filters;
using ImageGallery.Application.Entities.Bases.Repositories;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Application.Entities.Users.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ImageGallery.Application.Entities.Users.Repositories;

/// <summary>
/// Class UserRepository.
/// Implements the <see cref="ImageGallery.Application.Entities.Bases.Repositories.BaseRepository{ImageGallery.Application.Entities.Users.Domains.User}" />
/// Implements the <see cref="IUserRepository" />
/// </summary>
/// <seealso cref="ImageGallery.Application.Entities.Bases.Repositories.BaseRepository{ImageGallery.Application.Entities.Users.Domains.User}" />
/// <seealso cref="IUserRepository" />
public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly IImageGalleryContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UserRepository(IImageGalleryContext context) : base((DbContext)context)
    {
        _context = context;
    }
}