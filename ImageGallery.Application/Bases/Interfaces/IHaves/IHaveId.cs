using ImageGallery.Application.Bases.Interfaces.ICans;

namespace ImageGallery.Application.Bases.Interfaces.IHaves;

/// <summary>
/// Interface IHaveId
/// Extends the <see cref="ICanEntityChangeLog" />
/// Extends the <see cref="IHaveDescription" />
/// </summary>
/// <seealso cref="ICanEntityChangeLog" />
/// <seealso cref="IHaveDescription" />
public interface IHaveId : ICanEntityChangeLog, IHaveDescription
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    int Id { get; set; }
}