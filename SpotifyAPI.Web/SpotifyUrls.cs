using System;
namespace SpotifyAPI.Web
{
  public static class SpotifyUrls
  {
    static URIParameterFormatProvider _provider = new URIParameterFormatProvider();

    public static Uri API_V1 = new Uri("https://api.spotify.com/v1/");

    public static Uri Me() => _Uri("me");

    public static Uri User(string userId) => _Uri($"users/{userId}");

    public static Uri Categories() => _Uri("browse/categories");

    public static Uri Category(string categoryId) => _Uri($"browse/categories/{categoryId}");

    public static Uri CategoryPlaylists(string categoryId) => _Uri($"browse/categories/{categoryId}/playlists");

    private static Uri _Uri(FormattableString path) => new Uri(path.ToString(_provider), UriKind.Relative);
    private static Uri _Uri(string path) => new Uri(path, UriKind.Relative);
  }
}
