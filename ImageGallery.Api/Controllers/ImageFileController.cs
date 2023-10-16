using ImageGallery.Api.Controllers.Bases;
using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.Files.Interfaces;

namespace ImageGallery.Api.Controllers;

/// <summary>
/// Class ImageFileController.
/// Implements the <see cref="ImageGallery.Api.Controllers.Bases.BaseController{ImageGallery.Application.Entities.Files.Domains.ImageFile, ImageGallery.Application.Entities.Files.Interfaces.IImageFileRepository}" />
/// </summary>
/// <seealso cref="ImageGallery.Api.Controllers.Bases.BaseController{ImageGallery.Application.Entities.Files.Domains.ImageFile, ImageGallery.Application.Entities.Files.Interfaces.IImageFileRepository}" />
public class ImageFileController : BaseController<ImageFile, IImageFileRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageFileController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="env">The env.</param>
    public ImageFileController(IImageFileRepository repository, IWebHostEnvironment env) : base(repository, env)
    {

    }
}