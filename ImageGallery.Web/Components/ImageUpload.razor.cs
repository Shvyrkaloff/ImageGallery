using AntDesign;
using HttpService.Services;
using ImageGallery.Application.Bases.Enums;
using ImageGallery.Application.Entities.Bases.Filters;
using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Web.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ImageGallery.Web.Components;

/// <summary>
/// Class ImageUpload.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class ImageUpload
{
    /// <summary>
    /// Gets or sets the message service.
    /// </summary>
    /// <value>The message service.</value>
    [Inject]
    private MessageService MessageService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the image file service.
    /// </summary>
    /// <value>The image file service.</value>
    [Inject]
    private ImageFileService ImageFileService { get; set; } = null!;

    [Inject] 
    private UserService UserService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the authentication service.
    /// </summary>
    /// <value>The authentication service.</value>
    [Inject]
    private AuthenticationService AuthenticationService { get; set; } = null!;

    /// <summary>
    /// The avatar
    /// </summary>
    private string? _avatar;

    /// <summary>
    /// The new avatar
    /// </summary>
    private string? _newAvatar;

    /// <summary>
    /// The resized image
    /// </summary>
    private IBrowserFile? _resizedImage;

    /// <summary>
    /// The is loading image
    /// </summary>
    private bool _isLoadingImage;

    /// <summary>
    /// The is loading
    /// </summary>
    private bool _isLoading;

    /// <summary>
    /// Gets or sets the image file.
    /// </summary>
    /// <value>The image file.</value>
    private ImageFile? ImageFile { get; set; } = new();

    /// <summary>
    /// Handles the <see cref="E:InputFileChange" /> event.
    /// </summary>
    /// <param name="e">The <see cref="InputFileChangeEventArgs" /> instance containing the event data.</param>
    private async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
        _isLoadingImage = true;

        var imageFile = e.File;

        if (imageFile.ContentType != "image/jpeg" && imageFile.ContentType != "image/png")
        {
            await MessageService.Error("You can only upload JPG/PNG file!");
        }
        else
        {
            _resizedImage = await imageFile.RequestImageFileAsync("image/png", 500, 500);

            var ms = new MemoryStream();
            await _resizedImage.OpenReadStream().CopyToAsync(ms);
            var bytes = ms.ToArray();

            var b64 = Convert.ToBase64String(bytes);

            _newAvatar = "data:image/png;base64," + b64;
            _avatar = _newAvatar;
        }

        StateHasChanged();
    }

    /// <summary>
    /// Save as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    private async Task SaveAsync()
    {
        _isLoading = true;
        StateHasChanged();

        if (_isLoadingImage)
            await UploadAvatar();

        _isLoading = false;
        StateHasChanged();
    }

    /// <summary>
    /// Uploads the avatar.
    /// </summary>
    private async Task UploadAvatar()
    {
        using var content = new MultipartFormDataContent();
        var fileName = Path.GetRandomFileName();

        content.Add(
            content: new StreamContent(_resizedImage?.OpenReadStream() ?? Stream.Null),
            name: "\"files\"",
            fileName: fileName);

        var response = await ImageFileService.UploadAvatarAsync(content)!;

        if (response.IsSuccessStatusCode)
        {
            ImageFile!.FilePath = fileName;

            var user = (await UserService.GetAllByFilterAsync(new FilterParams()
            {
                FilterOption = EnumFilterOptions.Contains,
                ColumnName = "Name",
                FilterValue = AuthenticationService.AuthorizedUser?.Name!
            }) ?? Array.Empty<User>()).FirstOrDefault() ?? new User();

            var responseMessage = await ImageFileService.CreateAsync(new ImageFile()
            {
                FilePath = fileName,
                Name = fileName,
                OwnerId = user.Id,
                DateCreated = DateTime.Now,
                UserCreated = AuthenticationService.AuthorizedUser?.Name
            });

            if (responseMessage.IsSuccessStatusCode)
                await MessageService.Success(responseMessage.ReasonPhrase);

            var result = await ImageFileService.GetAvatarAsync(ImageFile!.FilePath);
            _avatar = result.RequestMessage?.RequestUri?.ToString();
        }
        else
            await MessageService.Error($"{response.ReasonPhrase}");

        _isLoadingImage = false;
    }
}