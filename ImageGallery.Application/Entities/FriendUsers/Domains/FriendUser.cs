using System.ComponentModel.DataAnnotations.Schema;
using ImageGallery.Application.Bases.Interfaces.IHaves;
using ImageGallery.Application.Entities.Users.Domains;

namespace ImageGallery.Application.Entities.FriendUsers.Domains;

/// <summary>
/// Class FriendUser.
/// </summary>
public class FriendUser : IHaveId, IHaveName
{
    /// <summary>
    /// Gets or sets the first friend identifier.
    /// </summary>
    /// <value>The first friend identifier.</value>
    public int FirstFriendId { get; set; }

    /// <summary>
    /// Gets or sets the first friend.
    /// </summary>
    /// <value>The first friend.</value>
    public virtual User FirstFriend { get; set; }

    /// <summary>
    /// Gets or sets the second friend identifier.
    /// </summary>
    /// <value>The second friend identifier.</value>
    public int SecondFriendId { get; set; }

    /// <summary>
    /// Gets or sets the second friend.
    /// </summary>
    /// <value>The second friend.</value>
    public virtual User SecondFriend { get; set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [NotMapped]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [NotMapped]
    public string? Name { get; set; }
}