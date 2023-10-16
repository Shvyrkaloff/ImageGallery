using ImageGallery.Application.Entities.Friends.Domains;
using ImageGallery.Application.Entities.Users.Domains;

namespace ImageGallery.Application.Entities.FriendUsers.Domains;

/// <summary>
/// Class FriendUser.
/// </summary>
public class FriendUser
{
    /// <summary>
    /// Gets or sets the friend identifier.
    /// </summary>
    /// <value>The friend identifier.</value>
    public int FriendId { get; set; }

    /// <summary>
    /// Gets or sets the friend.
    /// </summary>
    /// <value>The friend.</value>
    public virtual Friend Friend { get; set; }

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    /// <value>The user identifier.</value>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    public virtual User User { get; set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; }
}