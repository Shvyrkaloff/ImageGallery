using System.Net;
using AntDesign;
using ImageGallery.Application.Entities.Users.Domains;
using ImageGallery.Web.Data;
using ImageGallery.Web.Data.Services;
using Microsoft.AspNetCore.Components;

namespace ImageGallery.Web.Components;

/// <summary>
/// Class Register.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class Register
{
    /// <summary>
    /// The is loading
    /// </summary>
    private bool _isLoading;

    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    private UserService UserService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message service.
    /// </summary>
    /// <value>The message service.</value>
    [Inject]
    private IMessageService MessageService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the login form model.
    /// </summary>
    /// <value>The login form model.</value>
    private LoginFormModel LoginFormModel { get; set; } = new();

    /// <summary>
    /// Registrations this instance.
    /// </summary>
    private async Task Registration()
    {
        _isLoading = true;
        StateHasChanged();

        var responseMessage = await UserService.CreateAsync(new User
        {
            Name = LoginFormModel.Username,
            Password = LoginFormModel.Password,
            DateCreated = DateTime.Now
        });

        if (responseMessage.StatusCode != HttpStatusCode.OK)
            await MessageService.Error(responseMessage.ReasonPhrase);

        LoginFormModel = new LoginFormModel();

        _isLoading = false;
        StateHasChanged();
    }
}