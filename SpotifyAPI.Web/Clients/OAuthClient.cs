using System.Text;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class OAuthClient : APIClient, IOAuthClient
  {
    public OAuthClient(IAPIConnector apiConnector) : base(apiConnector) { }
    public OAuthClient() : this(SpotifyClientConfig.CreateDefault()) { }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062")]
    public OAuthClient(SpotifyClientConfig config) : base(ValidateConfig(config)) { }

    public Task<CredentialsTokenResponse> RequestToken(ClientCredentialsRequest request)
    {
      return RequestToken(request, API);
    }

    public Task<AuthorizationCodeRefreshResponse> RequestToken(AuthorizationCodeRefreshRequest request)
    {
      return RequestToken(request, API);
    }

    public Task<AuthorizationCodeTokenResponse> RequestToken(AuthorizationCodeTokenRequest request)
    {
      return RequestToken(request, API);
    }


    public static Task<CredentialsTokenResponse> RequestToken(
        ClientCredentialsRequest request, IAPIConnector apiConnector
      )
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string, string>>
      {
        new KeyValuePair<string, string>("grant_type", "client_credentials")
      };

      return SendOAuthRequest<CredentialsTokenResponse>(apiConnector, form, request.ClientId, request.ClientSecret);
    }

    public static Task<AuthorizationCodeRefreshResponse> RequestToken(
        AuthorizationCodeRefreshRequest request, IAPIConnector apiConnector
      )
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string, string>>
      {
        new KeyValuePair<string, string>("grant_type", "refresh_token"),
        new KeyValuePair<string, string>("refresh_token", request.RefreshToken)
      };

      return SendOAuthRequest<AuthorizationCodeRefreshResponse>(apiConnector, form, request.ClientId, request.ClientSecret);
    }

    public static Task<AuthorizationCodeTokenResponse> RequestToken(
        AuthorizationCodeTokenRequest request, IAPIConnector apiConnector
      )
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string, string>>
      {
        new KeyValuePair<string, string>("grant_type", "authorization_code"),
        new KeyValuePair<string, string>("code", request.Code),
        new KeyValuePair<string, string>("redirect_uri", request.RedirectUri.ToString())
      };

      return SendOAuthRequest<AuthorizationCodeTokenResponse>(apiConnector, form, request.ClientId, request.ClientSecret);
    }

    private static Task<T> SendOAuthRequest<T>(
      IAPIConnector apiConnector,
      List<KeyValuePair<string, string>> form,
      string clientId,
      string clientSecret)
    {
      var headers = BuildAuthHeader(clientId, clientSecret);
      return apiConnector.Post<T>(SpotifyUrls.OAuthToken, null, new FormUrlEncodedContent(form), headers);
    }

    private static Dictionary<string, string> BuildAuthHeader(string clientId, string clientSecret)
    {
      var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
      return new Dictionary<string, string>
      {
        { "Authorization", $"Basic {base64}"}
      };
    }

    private static APIConnector ValidateConfig(SpotifyClientConfig config)
    {
      Ensure.ArgumentNotNull(config, nameof(config));

      return new APIConnector(
        config.BaseAddress,
        config.Authenticator,
        config.JSONSerializer,
        config.HTTPClient,
        config.RetryHandler,
        config.HTTPLogger
      );
    }
  }
}
