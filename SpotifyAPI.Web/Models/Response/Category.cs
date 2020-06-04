using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Category
  {
    public string Href { get; set; } = default!;
    public List<Image> Icons { get; set; } = default!;
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
  }
}

