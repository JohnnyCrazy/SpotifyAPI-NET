using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SpotifyAPI.Web;

namespace Example.UWP.ViewModels
{
  public class LoginViewModel : MvxViewModel, IDisposable
  {
    public LoginViewModel(ITokenPublisherService tokenPublisher, IMvxNavigationService navigation)
    {
      _tokenPublisher = tokenPublisher;
      _navigation = navigation;
    }

    public override void ViewAppeared()
    {
      base.ViewAppeared();
      _tokenPublisher.TokenReceived += TokenPublisher_TokenReceived;
    }

    public override void ViewDisappeared()
    {
      base.ViewDisappeared();
      _tokenPublisher.TokenReceived -= TokenPublisher_TokenReceived;
    }

    public void Dispose()
    {
      _tokenPublisher.TokenReceived -= TokenPublisher_TokenReceived;
    }

    private readonly ITokenPublisherService _tokenPublisher;
    private readonly IMvxNavigationService _navigation;

    private string _titleText = "Spotify OAuth2 Login";
    public string TitleText
    {
      get => _titleText;
      set => SetProperty(ref _titleText, value);
    }

    private Uri _redirectUri = new Uri("spotifyapi.web.oauth://token");
    public Uri RedirectUri
    {
      get => _redirectUri;
      set => SetProperty(ref _redirectUri, value);
    }

    private string _clientId = "";
    public string ClientId
    {
      get => _clientId;
      set {
        if(SetProperty(ref _clientId, value))
        {
          OpenAuthenticationPage.RaiseCanExecuteChanged();
        }
      }
    }

    private MvxCommand _openAuthenticationPage;
    public MvxCommand OpenAuthenticationPage => _openAuthenticationPage ?? (_openAuthenticationPage =
        new MvxCommand(
          async () => await DoOpenAuthenticationPage(),
          () => !string.IsNullOrEmpty(ClientId)
        ));

    public async Task DoOpenAuthenticationPage()
    {
      var request = new LoginRequest(new Uri("spotifyapi.web.oauth://token"), ClientId, LoginRequest.ResponseType.Token);
      await Windows.System.Launcher.LaunchUriAsync(request.ToUri());
    }

    private void TokenPublisher_TokenReceived(object sender, string token)
    {
      _navigation.Navigate<PlaylistsListViewModel, string>(token);
    }
  }
}
