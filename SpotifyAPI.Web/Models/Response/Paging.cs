using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Paging<T>
  {
    public string Href { get; set; }
    public List<T> Items { get; set; }
    public int Limit { get; set; }
    public string Next { get; set; }
    public int Offset { get; set; }
    public string Previous { get; set; }
    public int Total { get; set; }
  }

  public class Paging<T, TNext>
  {
    public string Href { get; set; }
    public List<T> Items { get; set; }
    public int Limit { get; set; }
    public string Next { get; set; }
    public int Offset { get; set; }
    public string Previous { get; set; }
    public int Total { get; set; }
  }
}
