using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.Friends.Domains;
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
    /// Gets or sets the friends.
    /// </summary>
    /// <value>The friends.</value>
    public DbSet<Friend> Friends { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
    public DbSet<User> Users { get; set; }
}