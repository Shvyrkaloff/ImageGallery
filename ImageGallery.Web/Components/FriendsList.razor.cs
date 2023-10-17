using AntDesign;
using HttpService.Services;
using ImageGallery.Application.Bases.Enums;
using ImageGallery.Application.Bases.Interfaces.IHaves;
using ImageGallery.Application.Entities.Bases.Filters;
using ImageGallery.Application.Entities.FriendUsers.Domains;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Application.Models;
using ImageGallery.Web.Data.Services;
using Microsoft.AspNetCore.Components;

namespace ImageGallery.Web.Components;

/// <summary>
/// Class FriendsList.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class FriendsList
{
    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    private UserService UserService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the friend user service.
    /// </summary>
    /// <value>The friend user service.</value>
    [Inject]
    private FriendUserService FriendUserService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the authentication service.
    /// </summary>
    /// <value>The authentication service.</value>
    [Inject]
    private AuthenticationService AuthenticationService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message service.
    /// </summary>
    /// <value>The message service.</value>
    [Inject]
    private MessageService MessageService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the navigation manager.
    /// </summary>
    /// <value>The navigation manager.</value>
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <value>The current user.</value>
    private User CurrentUser => (User)AuthenticationService.AuthorizedUser!;

    /// <summary>
    /// The users
    /// </summary>
    private List<User> _users = new();

    /// <summary>
    /// The friends
    /// </summary>
    private List<User> _friends = new();

    /// <summary>
    /// The is loading
    /// </summary>
    private bool _isLoading;

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        if(CurrentUser != null)
        {
            _users = (await UserService.GetAllAsync() ?? Array.Empty<User>())
                .Where(u => u.Id != CurrentUser.Id)
                .ToList();

            var firstUsers = (await FriendUserService.GetAllByFilterAsync(new FilterParams()
            {
                ColumnName = "FirstFriendId",
                FilterOption = EnumFilterOptions.Contains,
                FilterValue = CurrentUser.Id.ToString()
            }) ?? Array.Empty<FriendUser>()).ToList();

            var secondUsers = (await FriendUserService.GetAllByFilterAsync(new FilterParams()
            {
                ColumnName = "SecondFriendId",
                FilterOption = EnumFilterOptions.Contains,
                FilterValue = CurrentUser.Id.ToString()
            }) ?? Array.Empty<FriendUser>()).ToList();

            foreach (var firstUser in firstUsers)
            {
                _friends.Add(firstUser.SecondFriend);
            }

            foreach (var secondUser in secondUsers)
            {
                _friends.Add(secondUser.FirstFriend);
            }

            foreach (var user in from friend in _friends from user in _users where friend.Id == user.Id select user)
            {
                _users = _users.Except(new List<User> { user }).ToList();
            }
        }
    }

    /// <summary>
    /// Adds the friend.
    /// </summary>
    /// <param name="user">The user.</param>
    private async Task AddFriend(IHaveId user)
    {
        _isLoading = true;
        StateHasChanged();

        var message = await UserService.AddFriendshipAsync(new FriendModel
        {
            FirstFriendId = CurrentUser.Id,
            SecondFriendId = user.Id
        });

        if (message.IsSuccessStatusCode)
            await MessageService.Success("Друг добавлен.");
        else
            await MessageService.Error(message.ReasonPhrase);

        _isLoading = false;
        StateHasChanged();

        NavigationManager.NavigateTo("/friends-list", true);
    }

    /// <summary>
    /// Deletes the friend.
    /// </summary>
    /// <param name="user">The user.</param>
    private async Task DeleteFriend(IHaveId user)
    {
        _isLoading = true;
        StateHasChanged();

        var message = new HttpResponseMessage();

        var friendUsers = await FriendUserService.GetAllAsync();

        if (friendUsers != null)
            foreach (var friendUser in friendUsers)
            {
                if (friendUser.FirstFriendId == user.Id && friendUser.SecondFriendId == CurrentUser.Id)
                {
                    message = await UserService.RemoveFriendshipAsync(new FriendModel
                    {
                        SecondFriendId = CurrentUser.Id,
                        FirstFriendId = user.Id
                    });
                    break;
                }
                else if (friendUser.SecondFriendId == user.Id && friendUser.FirstFriendId == CurrentUser.Id)
                {
                    message = await UserService.RemoveFriendshipAsync(new FriendModel
                    {
                        FirstFriendId = CurrentUser.Id,
                        SecondFriendId = user.Id
                    });
                    break;
                }
            }

        if (message.IsSuccessStatusCode)
            await MessageService.Success("Друг удален.");
        else
            await MessageService.Error(message.ReasonPhrase);

        _isLoading = false;
        StateHasChanged();

        NavigationManager.NavigateTo("/friends-list", true);
    }
}