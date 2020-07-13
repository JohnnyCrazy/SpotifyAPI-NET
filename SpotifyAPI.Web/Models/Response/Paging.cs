using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class Paging<T> : IPaginatable<T>
  {
    public string? Href { get; set; } = default!;
    public List<T>? Items { get; set; } = default!;
    public int? Limit { get; set; } = default!;
    public string? Next { get; set; } = default!;
    public int? Offset { get; set; } = default!;
    public string? Previous { get; set; } = default!;
    public int? Total { get; set; } = default!;
  }

  public class Paging<T, TNext> : IPaginatable<T, TNext>
  {
    public string? Href { get; set; } = default!;
    public List<T>? Items { get; set; } = default!;
    public int? Limit { get; set; } = default!;
    public string? Next { get; set; } = default!;
    public int? Offset { get; set; } = default!;
    public string? Previous { get; set; } = default!;
    public int? Total { get; set; } = default!;
  }
}

