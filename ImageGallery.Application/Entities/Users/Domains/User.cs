using System.Text.Json.Serialization;
using HttpService.Model.User.Domain;
using ImageGallery.Application.Bases.BaseUsers;
using ImageGallery.Application.Bases.Interfaces.IHaves;
using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.FriendUsers.Domains;

namespace ImageGallery.Application.Entities.Users.Domains;

/// <summary>
/// Class User.
/// Implements the <see cref="BaseUserCu" />
/// Implements the <see cref="IHaveId" />
/// Implements the <see cref="IHaveName" />
/// </summary>
/// <seealso cref="BaseUserCu" />
/// <seealso cref="IHaveId" />
/// <seealso cref="IHaveName" />
public class User : BaseUserCu, IHaveId, IHaveName, IBaseUser
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
    /// Gets or sets the password.
    /// </summary>
    /// <value>The password.</value>
    public string? Password { get; set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; }

    /// <summary>
    /// The image files
    /// </summary>
    private List<ImageFile>? _imageFiles;

    /// <summary>
    /// Gets the image files.
    /// </summary>
    /// <value>The image files.</value>
    [JsonIgnore]
    public virtual IReadOnlyCollection<ImageFile>? ImageFiles => _imageFiles;

    /// <summary>
    /// Gets or sets the first friend users.
    /// </summary>
    /// <value>The first friend users.</value>
    public virtual List<FriendUser>? FirstFriendUsers { get; set; }

    /// <summary>
    /// Gets or sets the second friend users.
    /// </summary>
    /// <value>The second friend users.</value>
    public virtual List<FriendUser>? SecondFriendUsers { get; set; }
}