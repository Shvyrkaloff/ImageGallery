using ImageGallery.Application.Entities.Bases.Interfaces;
using ImageGallery.Application.Entities.Files.Domains;

namespace ImageGallery.Application.Entities.Files.Interfaces;

/// <summary>
/// Interface IImageFileRepository
/// Extends the <see cref="ImageGallery.Application.Entities.Bases.Interfaces.IBaseRepository{ImageGallery.Application.Entities.Files.Domains.ImageFile}" />
/// </summary>
/// <seealso cref="ImageGallery.Application.Entities.Bases.Interfaces.IBaseRepository{ImageGallery.Application.Entities.Files.Domains.ImageFile}" />
public interface IImageFileRepository : IBaseRepository<ImageFile>
{

}