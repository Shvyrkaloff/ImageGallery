using ImageGallery.Application.Entities.Bases.Interfaces;
using ImageGallery.Application.Entities.FriendUsers.Domains;

namespace ImageGallery.Application.Entities.FriendUsers.Interfaces;

/// <summary>
/// Interface IFriendUserRepository
/// Extends the <see cref="ImageGallery.Application.Entities.Bases.Interfaces.IBaseRepository{ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser}" />
/// </summary>
/// <seealso cref="ImageGallery.Application.Entities.Bases.Interfaces.IBaseRepository{ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser}" />
public interface IFriendUserRepository : IBaseRepository<FriendUser>
{

}