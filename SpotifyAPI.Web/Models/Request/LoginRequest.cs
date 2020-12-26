using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SpotifyAPI.Web
{
  public class LoginRequest
  {
    public LoginRequest(Uri redirectUri, string clientId, ResponseType responseType)
    {
      Ensure.ArgumentNotNull(redirectUri, nameof(redirectUri));
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));

      RedirectUri = redirectUri;
      ClientId = clientId;
      ResponseTypeParam = responseType;
    }

    public Uri RedirectUri { get; }
    public ResponseType ResponseTypeParam { get; }
    public string ClientId { get; }
    public string? State { get; set; }
    public ICollection<string>? Scope { get; set; }
    public bool? ShowDialog { get; set; }
    public string? CodeChallengeMethod { get; set; }
    public string? CodeChallenge { get; set; }

    public Uri ToUri()
    {
      var builder = new StringBuilder(SpotifyUrls.Authorize.ToString());
      builder.Append($"?client_id={ClientId}");
      builder.Append($"&response_type={ResponseTypeParam.ToString().ToLower(CultureInfo.InvariantCulture)}");
      builder.Append($"&redirect_uri={HttpUtility.UrlEncode(RedirectUri.ToString())}");
      if (!string.IsNullOrEmpty(State))
      {
        builder.Append($"&state={HttpUtility.UrlEncode(State)}");
      }
      if (Scope != null)
      {
        builder.Append($"&scope={HttpUtility.UrlEncode(string.Join(" ", Scope))}");
      }
      if (ShowDialog != null)
      {
        builder.Append($"&show_dialog={ShowDialog.Value}");
      }
      if (CodeChallenge != null)
      {
        builder.Append($"&code_challenge={CodeChallenge}");
      }
      if (CodeChallengeMethod != null)
      {
        builder.Append($"&code_challenge_method={CodeChallengeMethod}");
      }

      return new Uri(builder.ToString());
    }

    public enum ResponseType
    {
      Code,
      Token
    }
  }
}

