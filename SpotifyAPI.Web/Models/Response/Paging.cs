using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Paging<T>
  {
    public string Href { get; private set; }
    public List<T> Items { get; private set; }
    public int Limit { get; private set; }
    public string Next { get; private set; }
    public int Offset { get; private set; }
    public string Previous { get; private set; }
    public int Total { get; private set; }
  }
}
