using System;
namespace SpotifyAPI.Web
{
  public static class SpotifyUrls
  {
    static private readonly URIParameterFormatProvider _provider = new URIParameterFormatProvider();

    public static Uri API_V1 = new Uri("https://api.spotify.com/v1/");

    public static Uri Me() => EUri($"me");

    public static Uri User(string userId) => EUri($"users/{userId}");

    public static Uri Categories() => EUri($"browse/categories");

    public static Uri Category(string categoryId) => EUri($"browse/categories/{categoryId}");

    public static Uri CategoryPlaylists(string categoryId) => EUri($"browse/categories/{categoryId}/playlists");

    public static Uri Recommendations() => EUri($"recommendations");

    private static Uri EUri(FormattableString path) => new Uri(path.ToString(_provider), UriKind.Relative);
  }
}
