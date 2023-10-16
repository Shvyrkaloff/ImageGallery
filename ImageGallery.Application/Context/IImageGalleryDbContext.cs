using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.FriendUsers.Domains;
using ImageGallery.Application.Entities.Users.Domains;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.Application.Context;

/// <summary>
/// Interface IImageGalleryContext
/// </summary>
public interface IImageGalleryContext
{
    /// <summary>
    /// Gets or sets the image files.
    /// </summary>
    /// <value>The image files.</value>
    public DbSet<ImageFile> ImageFiles { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Gets or sets the friends user.
    /// </summary>
    /// <value>The friends user.</value>
    public DbSet<FriendUser> FriendUsers { get; set; }

}