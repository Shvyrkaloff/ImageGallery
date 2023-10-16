using ImageGallery.Application.Context;
using ImageGallery.Application.Entities.Bases.Repositories;
using ImageGallery.Application.Entities.Friends.Domains;
using ImageGallery.Application.Entities.Friends.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.Application.Entities.Friends.Repositories;

/// <summary>
/// Class FriendRepository.
/// Implements the <see cref="ImageGallery.Application.Entities.Bases.Repositories.BaseRepository{ImageGallery.Application.Entities.Friends.Domains.Friend}" />
/// Implements the <see cref="IFriendRepository" />
/// </summary>
/// <seealso cref="ImageGallery.Application.Entities.Bases.Repositories.BaseRepository{ImageGallery.Application.Entities.Friends.Domains.Friend}" />
/// <seealso cref="IFriendRepository" />
public class FriendRepository : BaseRepository<Friend>, IFriendRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FriendRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public FriendRepository(IImageGalleryContext context) : base((DbContext)context)
    {

    }
}