using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Category
  {
    public string Href { get; private set; }
    public List<Image> Icons { get; private set; }
    public string Id { get; private set; }
    public string Name { get; private set; }
  }
}
