using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class CursorPaging<T>
  {
    public string Href { get; set; }
    public List<T> Items { get; set; }
    public int Limit { get; set; }
    public string Next { get; set; }
    public Cursor Cursors { get; set; }
    public int Total { get; set; }
  }
}
