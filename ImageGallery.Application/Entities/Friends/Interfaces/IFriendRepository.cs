using ImageGallery.Application.Entities.Bases.Interfaces;
using ImageGallery.Application.Entities.Friends.Domains;

namespace ImageGallery.Application.Entities.Friends.Interfaces;

/// <summary>
/// Interface IFriendRepository
/// Extends the <see cref="ImageGallery.Application.Entities.Bases.Interfaces.IBaseRepository{ImageGallery.Application.Entities.Friends.Domains.Friend}" />
/// </summary>
/// <seealso cref="ImageGallery.Application.Entities.Bases.Interfaces.IBaseRepository{ImageGallery.Application.Entities.Friends.Domains.Friend}" />
public interface IFriendRepository : IBaseRepository<Friend>
{

}