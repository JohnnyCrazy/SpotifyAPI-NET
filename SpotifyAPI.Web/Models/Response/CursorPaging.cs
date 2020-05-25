using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class CursorPaging<T>
  {
    public string Href { get; set; } = default!;
    public List<T> Items { get; set; } = default!;
    public int Limit { get; set; }
    public string Next { get; set; } = default!;
    public Cursor Cursors { get; set; } = default!;
    public int Total { get; set; }
  }
}

