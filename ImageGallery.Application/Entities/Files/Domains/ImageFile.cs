using System.Text.Json.Serialization;
using ImageGallery.Application.Bases.BaseUsers;
using ImageGallery.Application.Bases.Interfaces.IHaves;
using ImageGallery.Application.Entities.Users.Domains;

namespace ImageGallery.Application.Entities.Files.Domains;

/// <summary>
/// Class ImageFile.
/// Implements the <see cref="BaseUserCu" />
/// Implements the <see cref="IHaveId" />
/// Implements the <see cref="IHaveName" />
/// </summary>
/// <seealso cref="BaseUserCu" />
/// <seealso cref="IHaveId" />
/// <seealso cref="IHaveName" />
public class ImageFile : BaseUserCu, IHaveId, IHaveName
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
    /// Gets or sets the file path.
    /// </summary>
    /// <value>The file path.</value>
    public string? FilePath { get; set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; }

    /// <summary>
    /// Gets or sets the owner identifier.
    /// </summary>
    /// <value>The owner identifier.</value>
    public int? OwnerId { get; set; }

    /// <summary>
    /// Gets or sets the owner.
    /// </summary>
    /// <value>The owner.</value>
    [JsonIgnore]
    public virtual User? Owner { get; set; }
}