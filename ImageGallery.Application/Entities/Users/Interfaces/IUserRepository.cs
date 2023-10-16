using ImageGallery.Application.Entities.Bases.Interfaces;
using ImageGallery.Application.Entities.Users.Domains;

namespace ImageGallery.Application.Entities.Users.Interfaces;

/// <summary>
/// Interface IUserRepository
/// Extends the <see cref="ImageGallery.Application.Entities.Bases.Interfaces.IBaseRepository{ImageGallery.Application.Entities.Users.Domains.User}" />
/// </summary>
/// <seealso cref="ImageGallery.Application.Entities.Bases.Interfaces.IBaseRepository{ImageGallery.Application.Entities.Users.Domains.User}" />
public interface IUserRepository : IBaseRepository<User>
{
    
}