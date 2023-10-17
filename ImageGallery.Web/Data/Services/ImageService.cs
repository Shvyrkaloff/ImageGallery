using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Web.Data.Services.Bases;
using Microsoft.Extensions.Caching.Distributed;

namespace ImageGallery.Web.Data.Services;

/// <summary>
/// Class ImageFileService.
/// Implements the <see cref="ImageGallery.Web.Data.Services.Bases.BaseService{ImageGallery.Application.Entities.Files.Domains.ImageFile}" />
/// </summary>
/// <seealso cref="ImageGallery.Web.Data.Services.Bases.BaseService{ImageGallery.Application.Entities.Files.Domains.ImageFile}" />
public class ImageFileService: BaseService<ImageFile>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageFileService"/> class.
    /// </summary>
    /// <param name="clientFactory">The client factory.</param>
    /// <param name="cache">The cache.</param>
    public ImageFileService(IHttpClientFactory clientFactory, IDistributedCache cache) : base(clientFactory, cache)
    {

    }
}