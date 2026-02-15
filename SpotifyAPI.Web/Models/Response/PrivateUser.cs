using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class PrivateUser
  {
    [System.Obsolete("Field 'country' has been removed.")]
    public string Country { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
    [System.Obsolete("Field 'email' has been removed.")]
    public string Email { get; set; } = default!;
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    [System.Obsolete("Field 'followers' has been removed.")]
    public Followers Followers { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Id { get; set; } = default!;
    public List<Image> Images { get; set; } = default!;
    [System.Obsolete("Field 'product' has been removed.")]
    public string Product { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Uri { get; set; } = default!;
  }
}

