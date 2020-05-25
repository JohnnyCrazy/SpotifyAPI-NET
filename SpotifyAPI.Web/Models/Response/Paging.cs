using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Paging<T>
  {
    public string Href { get; set; } = default!;
    public List<T> Items { get; set; } = default!;
    public int Limit { get; set; }
    public string Next { get; set; } = default!;
    public int Offset { get; set; }
    public string Previous { get; set; } = default!;
    public int Total { get; set; }
  }

  public class Paging<T, TNext>
  {
    public string Href { get; set; } = default!;
    public List<T> Items { get; set; } = default!;
    public int Limit { get; set; }
    public string Next { get; set; } = default!;
    public int Offset { get; set; }
    public string Previous { get; set; } = default!;
    public int Total { get; set; }
  }
}

