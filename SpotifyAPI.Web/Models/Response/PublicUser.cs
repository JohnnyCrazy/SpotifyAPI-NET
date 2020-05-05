using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class PublicUser
  {
    public string DisplayName { get; private set; }
    public Dictionary<string, string> ExternalUrls { get; private set; }
    public Followers Followers { get; private set; }
    public string Href { get; private set; }
    public string Id { get; private set; }
    public List<Image> Images { get; private set; }
    public string Type { get; private set; }
    public string Uri { get; private set; }
  }
}
