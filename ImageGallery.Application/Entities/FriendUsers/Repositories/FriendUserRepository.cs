using ImageGallery.Application.Context;
using ImageGallery.Application.Entities.Bases.Repositories;
using ImageGallery.Application.Entities.FriendUsers.Domains;
using ImageGallery.Application.Entities.FriendUsers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.Application.Entities.FriendUsers.Repositories;

/// <summary>
/// Class FriendUserRepository.
/// Implements the <see cref="ImageGallery.Application.Entities.Bases.Repositories.BaseRepository{ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser}" />
/// Implements the <see cref="IFriendUserRepository" />
/// </summary>
/// <seealso cref="ImageGallery.Application.Entities.Bases.Repositories.BaseRepository{ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser}" />
/// <seealso cref="IFriendUserRepository" />
public class FriendUserRepository : BaseRepository<FriendUser>, IFriendUserRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FriendUserRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public FriendUserRepository(IImageGalleryContext context) : base((DbContext)context)
    {

    }
}