namespace SpotifyAPI.Web
{
  public class ClientCredentialsRequest
  {
    public ClientCredentialsRequest(string clientId, string clientSecret)
    {
      Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
      Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));

      ClientId = clientId;
      ClientSecret = clientSecret;
    }
    public string ClientId { get; }
    public string ClientSecret { get; }
  }
}
