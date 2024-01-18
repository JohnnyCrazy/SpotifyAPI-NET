using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class UsersTopTracksResponse
  {
    public string Href {get; set;} = default!;
    public int Limit {get; set;} 
    public string Next {get; set;} = default!;
    public int Offset {get; set;}
    public string Previous {get; set;} = default!;
    public int Total {get; set;} = default!;
    public List<FullTrack> Items { get; set; } = default!;
  }
}

