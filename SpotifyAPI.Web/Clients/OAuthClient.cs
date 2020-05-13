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

    public Task<TokenResponse> RequestToken(ClientCredentialsRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      var form = new List<KeyValuePair<string, string>>
      {
        new KeyValuePair<string, string>("grant_type", "client_credentials")
      };

      var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{request.ClientId}:{request.ClientSecret}"));
      var headers = new Dictionary<string, string>
      {
        { "Authorization", $"Basic {base64}"}
      };

      return API.Post<TokenResponse>(SpotifyUrls.OAuthToken, null, new FormUrlEncodedContent(form), headers);
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
