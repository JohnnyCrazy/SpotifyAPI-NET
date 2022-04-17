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
    public OAuthClient() : this(SpotifyClientConfig.CreateDefault()) { }
    public OAuthClient(IAPIConnector apiConnector) : base(apiConnector) { }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062")]
    public OAuthClient(SpotifyClientConfig config) : base(ValidateConfig(config)) { }

    /// <summary>
    /// Requests a new token using pkce flow
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow-with-proof-key-for-code-exchange-pkce
    /// </remarks>
    /// <returns></returns>1
    public Task<PKCETokenResponse> RequestToken(PKCETokenRequest request)
    {
      return RequestToken(request, API);
    }

    /// <summary>
    /// Refreshes a token using pkce flow
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow-with-proof-key-for-code-exchange-pkce
    /// </remarks>
    /// <returns></returns>1
    public Task<PKCETokenResponse> RequestToken(PKCETokenRefreshRequest request)
    {
      return RequestToken(request, API);
    }

    /// <summary>
    /// Requests a new token using client_ids and client_secrets.
    /// If the token is expired, simply call the funtion again to get a new token
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#client-credentials-flow
    /// </remarks>
    /// <returns></returns>1
    public Task<ClientCredentialsTokenResponse> RequestToken(ClientCredentialsRequest request)
    {
      return RequestToken(request, API);
    }

    /// <summary>
    /// Refresh an already received token via Authorization Code Auth
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow
    /// </remarks>
    /// <returns></returns>
    public Task<AuthorizationCodeRefreshResponse> RequestToken(AuthorizationCodeRefreshRequest request)
    {
      return RequestToken(request, API);
    }

    /// <summary>
    /// Request an initial token via Authorization Code Auth
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow
    /// </remarks>
    /// <returns></returns>
    public Task<AuthorizationCodeTokenResponse> RequestToken(AuthorizationCodeTokenRequest request)
    {
      return RequestToken(request, API);
    }

    /// <summary>
    /// Swaps out a received code with a access token using a remote server
    /// </summary>
    /// <param name="request">The request-model which contains required and optional parameters.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/ios/guides/token-swap-and-refresh/
    /// </remarks>
    /// <returns></returns>
    public Task<AuthorizationCodeTokenResponse> RequestToken(TokenSwapTokenRequest request)
    {
      return RequestToken(request, API);
    }

    /// <summary>
    /// Gets a refreshed access token using an already received refresh token using a remote server
    /// </summary>
    /// <param name="request"></param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/ios/guides/token-swap-and-refresh/
    /// </remarks>
    /// <returns></returns>
    public Task<AuthorizationCodeRefreshResponse> RequestToken(TokenSwapRefreshRequest request)
    {
      return RequestToken(request, API);
    }

    public static Task<PKCETokenResponse> RequestToken(PKCETokenRequest request, IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string?, string?>>
      {
        new KeyValuePair<string?, string?>("client_id", request.ClientId),
        new KeyValuePair<string?, string?>("grant_type", "authorization_code"),
        new KeyValuePair<string?, string?>("code", request.Code),
        new KeyValuePair<string?, string?>("redirect_uri", request.RedirectUri.ToString()),
        new KeyValuePair<string?, string?>("code_verifier", request.CodeVerifier),
      };

      return SendOAuthRequest<PKCETokenResponse>(apiConnector, form, null, null);
    }

    public static Task<PKCETokenResponse> RequestToken(PKCETokenRefreshRequest request, IAPIConnector apiConnector)
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string?, string?>>
      {
        new KeyValuePair<string?, string?>("client_id", request.ClientId),
        new KeyValuePair<string?, string?>("grant_type", "refresh_token"),
        new KeyValuePair<string?, string?>("refresh_token", request.RefreshToken),
      };

      return SendOAuthRequest<PKCETokenResponse>(apiConnector, form, null, null);
    }

    public static Task<AuthorizationCodeRefreshResponse> RequestToken(
        TokenSwapRefreshRequest request, IAPIConnector apiConnector
      )
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string?, string?>>
      {
        new KeyValuePair<string?, string?>("refresh_token", request.RefreshToken)
      };
#pragma warning disable CA2000
      return apiConnector.Post<AuthorizationCodeRefreshResponse>(
        request.RefreshUri, null, new FormUrlEncodedContent(form)
      );
#pragma warning restore CA2000
    }

    public static Task<AuthorizationCodeTokenResponse> RequestToken(
        TokenSwapTokenRequest request, IAPIConnector apiConnector
      )
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string?, string?>>
      {
        new KeyValuePair<string?, string?>("code", request.Code)
      };

#pragma warning disable CA2000
      return apiConnector.Post<AuthorizationCodeTokenResponse>(
        request.TokenUri, null, new FormUrlEncodedContent(form)
      );
#pragma warning restore CA2000
    }

    public static Task<ClientCredentialsTokenResponse> RequestToken(
        ClientCredentialsRequest request, IAPIConnector apiConnector
      )
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string?, string?>>
      {
        new KeyValuePair<string?, string?>("grant_type", "client_credentials")
      };

      return SendOAuthRequest<ClientCredentialsTokenResponse>(apiConnector, form, request.ClientId, request.ClientSecret);
    }

    public static Task<AuthorizationCodeRefreshResponse> RequestToken(
        AuthorizationCodeRefreshRequest request, IAPIConnector apiConnector
      )
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string?, string?>>
      {
        new KeyValuePair<string?, string?>("grant_type", "refresh_token"),
        new KeyValuePair<string?, string?>("refresh_token", request.RefreshToken)
      };

      return SendOAuthRequest<AuthorizationCodeRefreshResponse>(apiConnector, form, request.ClientId, request.ClientSecret);
    }

    public static Task<AuthorizationCodeTokenResponse> RequestToken(
        AuthorizationCodeTokenRequest request, IAPIConnector apiConnector
      )
    {
      Ensure.ArgumentNotNull(request, nameof(request));
      Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

      var form = new List<KeyValuePair<string?, string?>>
      {
        new KeyValuePair<string?, string?>("grant_type", "authorization_code"),
        new KeyValuePair<string?, string?>("code", request.Code),
        new KeyValuePair<string?, string?>("redirect_uri", request.RedirectUri.ToString())
      };

      return SendOAuthRequest<AuthorizationCodeTokenResponse>(apiConnector, form, request.ClientId, request.ClientSecret);
    }

    private static Task<T> SendOAuthRequest<T>(
      IAPIConnector apiConnector,
      List<KeyValuePair<string?, string?>> form,
      string? clientId,
      string? clientSecret)
    {
      var headers = BuildAuthHeader(clientId, clientSecret);
#pragma warning disable CA2000
      return apiConnector.Post<T>(SpotifyUrls.OAuthToken, null, new FormUrlEncodedContent(form), headers);
#pragma warning restore CA2000
    }

    private static Dictionary<string, string> BuildAuthHeader(string? clientId, string? clientSecret)
    {
      if (clientId == null || clientSecret == null)
      {
        return new Dictionary<string, string>();
      }

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
