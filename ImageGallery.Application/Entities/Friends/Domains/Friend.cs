using ImageGallery.Application.Bases.BaseUsers;
using ImageGallery.Application.Bases.Interfaces.IHaves;
using ImageGallery.Application.Entities.FriendUsers.Domains;

namespace ImageGallery.Application.Entities.Friends.Domains;

/// <summary>
/// Class Friend.
/// Implements the <see cref="BaseUserCu" />
/// Implements the <see cref="IHaveId" />
/// Implements the <see cref="IHaveName" />
/// </summary>
/// <seealso cref="BaseUserCu" />
/// <seealso cref="IHaveId" />
/// <seealso cref="IHaveName" />
public class Friend : BaseUserCu, IHaveId, IHaveName
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string? Name { get; set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; }

    /// <summary>
    /// Gets or sets the friend users.
    /// </summary>
    /// <value>The friend users.</value>
    public virtual List<FriendUser>? FriendUsers { get; set; }
}