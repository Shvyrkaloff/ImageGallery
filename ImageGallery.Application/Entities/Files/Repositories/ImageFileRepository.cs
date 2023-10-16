using ImageGallery.Application.Context;
using ImageGallery.Application.Entities.Bases.Repositories;
using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.Files.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.Application.Entities.Files.Repositories;

/// <summary>
/// Class ImageFileRepository.
/// Implements the <see cref="ImageGallery.Application.Entities.Bases.Repositories.BaseRepository{ImageGallery.Application.Entities.Files.Domains.ImageFile}" />
/// Implements the <see cref="IImageFileRepository" />
/// </summary>
/// <seealso cref="ImageGallery.Application.Entities.Bases.Repositories.BaseRepository{ImageGallery.Application.Entities.Files.Domains.ImageFile}" />
/// <seealso cref="IImageFileRepository" />
public class ImageFileRepository : BaseRepository<ImageFile>, IImageFileRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageFileRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public ImageFileRepository(IImageGalleryContext context) : base((DbContext)context)
    {

    }
}