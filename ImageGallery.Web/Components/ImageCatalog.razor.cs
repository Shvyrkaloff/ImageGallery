using HttpService.Services;
using ImageGallery.Application.Bases.Enums;
using ImageGallery.Application.Entities.Bases.Filters;
using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.FriendUsers.Domains;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Web.Data.Services;
using Microsoft.AspNetCore.Components;

namespace ImageGallery.Web.Components;

/// <summary>
/// Class ImageCatalog.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class ImageCatalog
{
    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    private UserService UserService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the image file service.
    /// </summary>
    /// <value>The image file service.</value>
    [Inject]
    private ImageFileService ImageFileService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the authentication service.
    /// </summary>
    /// <value>The authentication service.</value>
    [Inject]
    private AuthenticationService AuthenticationService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the friend user service.
    /// </summary>
    /// <value>The friend user service.</value>
    [Inject]
    private FriendUserService FriendUserService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the current user.
    /// </summary>
    /// <value>The current user.</value>
    private User CurrentUser => (User)AuthenticationService.AuthorizedUser!;

    /// <summary>
    /// Gets or sets the image files.
    /// </summary>
    /// <value>The image files.</value>
    private List<ImageFile> ImageFiles { get; set; } = new();

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
            _isLoading = true;
            StateHasChanged();

            var firstUsers = (await FriendUserService.GetAllByFilterAsync(new FilterParams
            {
                ColumnName = "FirstFriendId",
                FilterOption = EnumFilterOptions.Contains,
                FilterValue = CurrentUser.Id.ToString()
            }) ?? Array.Empty<FriendUser>()).ToList();

            var secondUsers = (await FriendUserService.GetAllByFilterAsync(new FilterParams
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

            var imageFiles = await ImageFileService.GetAllByFilterAsync(new FilterParams
            {
                FilterOption = EnumFilterOptions.Contains,
                ColumnName = "OwnerId",
                FilterValue = CurrentUser.Id.ToString()
            });

            if (imageFiles != null)
                ImageFiles.AddRange(imageFiles.ToList());

            foreach (var friend in _friends)
            {
                imageFiles = await ImageFileService.GetAllByFilterAsync(new FilterParams
                {
                    FilterOption = EnumFilterOptions.Contains,
                    ColumnName = "OwnerId",
                    FilterValue = friend.Id.ToString()
                });

                if (imageFiles != null)
                    ImageFiles.AddRange(imageFiles.ToList());
            }

            foreach (var t in ImageFiles)
            {
                t.FilePath = (await ImageFileService?.GetAvatarAsync(t.FilePath ?? string.Empty)!).RequestMessage
                    ?.RequestUri?.ToString();
                ;
            }

            _isLoading = false;
            StateHasChanged();
        }
    }
}