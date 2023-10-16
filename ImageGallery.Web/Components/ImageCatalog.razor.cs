using HttpService.Services;
using ImageGallery.Application.Bases.Enums;
using ImageGallery.Application.Entities.Bases.Filters;
using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Web.Data.Services;
using Microsoft.AspNetCore.Components;

namespace ImageGallery.Web.Components;

public partial class ImageCatalog
{
    [Inject]
    private UserService UserService { get; set; } = null!;

    [Inject]
    private ImageFileService ImageFileService { get; set; } = null!;

    [Inject]
    private AuthenticationService AuthenticationService { get; set; } = null!;

    private User CurrentUser { get; set; } = new();

    private List<ImageFile> ImageFiles { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        CurrentUser = (await UserService.GetAllByFilterAsync(new FilterParams
        {
            FilterOption = EnumFilterOptions.Contains,
            ColumnName = "Name",
            FilterValue = AuthenticationService.AuthorizedUser?.Name!
        }) ?? Array.Empty<User>()).FirstOrDefault()!;

        var imageFiles = await ImageFileService.GetAllByFilterAsync(new FilterParams
        {
            FilterOption = EnumFilterOptions.Contains,
            ColumnName = "OwnerId",
            FilterValue = CurrentUser.Id.ToString()
        });

        if (imageFiles != null) 
            ImageFiles = imageFiles.ToList();

        foreach (var t in ImageFiles)
        {
            t.FilePath = (await ImageFileService?.GetAvatarAsync(t.FilePath ?? string.Empty)!).RequestMessage?.RequestUri?.ToString(); ;
        }
    }
}