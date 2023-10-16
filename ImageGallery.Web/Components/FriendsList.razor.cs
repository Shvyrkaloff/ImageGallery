using HttpService.Services;
using ImageGallery.Application.Bases.Interfaces.IHaves;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Application.Models;
using ImageGallery.Web.Data.Services;
using Microsoft.AspNetCore.Components;

namespace ImageGallery.Web.Components;

public partial class FriendsList
{
    [Inject]
    private UserService UserService{ get; set; }

    [Inject]
    private AuthenticationService AuthenticationService { get; set; } = null!;

    private User CurrentUser => (User)AuthenticationService.AuthorizedUser!;

    private List<User> Users = new();

    protected override async Task OnInitializedAsync()
    {
        Users = (await UserService.GetAllAsync()).ToList();
    }

    private async Task AddFriend(IHaveId user)
    {
        await UserService.AddFriendshipAsync(new FriendModel
        {
            FirstFriendId = CurrentUser.Id,
            SecondFriendId = user.Id
        });
    }
}