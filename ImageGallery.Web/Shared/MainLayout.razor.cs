using HttpService.Services;
using Microsoft.AspNetCore.Components;

namespace ImageGallery.Web.Shared;

public partial class MainLayout
{
    [Inject]
    private AuthenticationService AuthenticationService { get; set; } = null!;
}