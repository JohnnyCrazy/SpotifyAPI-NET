using System.Collections.Generic;
namespace SpotifyAPI.Web.Auth
{
  public class LoginRequest
  {
    public LoginRequest(string clientId, ResponseType responseType)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));

      ClientId = clientId;
      ResponseTypeParam = responseType;
    }

    public ResponseType ResponseTypeParam { get; }
    public string ClientId { get; }
    public string State { get; set; }
    public ICollection<string> Scope { get; set; }
    public bool? ShowDialog { get; set; }

    public enum ResponseType
    {
      Code,
      Token
    }
  }
}
