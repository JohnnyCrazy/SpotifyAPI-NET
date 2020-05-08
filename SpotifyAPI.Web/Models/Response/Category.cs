using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Category
  {
    public string Href { get; set; }
    public List<Image> Icons { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
  }
}
