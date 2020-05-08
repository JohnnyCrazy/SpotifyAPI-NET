using System;
namespace SpotifyAPI.Web
{
  public static class SpotifyUrls
  {
    static private readonly URIParameterFormatProvider _provider = new URIParameterFormatProvider();

    public static readonly Uri APIV1 = new Uri("https://api.spotify.com/v1/");

    public static Uri Me() => EUri($"me");

    public static Uri User(string userId) => EUri($"users/{userId}");

    public static Uri Categories() => EUri($"browse/categories");

    public static Uri Category(string categoryId) => EUri($"browse/categories/{categoryId}");

    public static Uri CategoryPlaylists(string categoryId) => EUri($"browse/categories/{categoryId}/playlists");

    public static Uri Recommendations() => EUri($"recommendations");

    public static Uri RecommendationGenres() => EUri($"recommendations/available-genre-seeds");

    public static Uri NewReleases() => EUri($"browse/new-releases");

    public static Uri FeaturedPlaylists() => EUri($"browse/featured-playlists");

    public static Uri Show(string showId) => EUri($"shows/{showId}");

    public static Uri Shows() => EUri($"shows");

    public static Uri ShowEpisodes(string showId) => EUri($"shows/{showId}/episodes");

    public static Uri PlaylistTracks(string playlistId) => EUri($"playlists/{playlistId}/tracks");

    public static Uri UserPlaylists(string userId) => EUri($"users/{userId}/playlists");

    public static Uri PlaylistImages(string playlistId) => EUri($"playlists/{playlistId}/images");

    public static Uri Playlist(string playlistId) => EUri($"playlists/{playlistId}");

    public static Uri CurrentUserPlaylists() => EUri($"me/playlists");

    public static Uri Search() => EUri($"search");

    public static Uri CurrentUserFollowerContains() => EUri($"me/following/contains");

    public static Uri PlaylistFollowersContains(string playlistId) => EUri($"playlists/{playlistId}/followers/contains");

    public static Uri CurrentUserFollower() => EUri($"me/following");

    public static Uri PlaylistFollowers(string playlistId) => EUri($"playlists/{playlistId}/followers");

    public static Uri Tracks() => EUri($"tracks");

    public static Uri Track(string trackId) => EUri($"tracks/{trackId}");

    public static Uri AudioAnalysis(string trackId) => EUri($"audio-analysis/{trackId}");

    public static Uri AudioFeatures(string trackId) => EUri($"audio-features/{trackId}");

    public static Uri AudioFeatures() => EUri($"audio-features");

    public static Uri Player() => EUri($"me/player");

    public static Uri PlayerQueue() => EUri($"me/player/queue");

    public static Uri PlayerDevices() => EUri($"me/player/devices");

    public static Uri PlayerCurrentlyPlaying() => EUri($"me/player/currently-playing");

    public static Uri PlayerRecentlyPlayed() => EUri($"me/player/recently-played");

    public static Uri PlayerPause() => EUri($"me/player/pause");

    public static Uri PlayerResume() => EUri($"me/player/play");

    public static Uri PlayerSeek() => EUri($"me/player/seek");

    public static Uri PlayerRepeat() => EUri($"me/player/repeat");

    public static Uri PlayerShuffle() => EUri($"me/player/shuffle");

    public static Uri PlayerVolume() => EUri($"me/player/volume");

    public static Uri PlayerNext() => EUri($"me/player/next");

    public static Uri PlayerPrevious() => EUri($"me/player/previous");

    public static Uri Albums() => EUri($"albums");

    public static Uri Album(string albumId) => EUri($"albums/{albumId}");

    public static Uri AlbumTracks(string albumId) => EUri($"albums/{albumId}/tracks");

    public static Uri Artists() => EUri($"artists");

    public static Uri Artist(string artistId) => EUri($"artists/{artistId}");

    public static Uri ArtistAlbums(string artistId) => EUri($"artists/{artistId}/albums");

    public static Uri ArtistTopTracks(string artistId) => EUri($"artists/{artistId}/top-tracks");

    public static Uri ArtistRelatedArtists(string artistId) => EUri($"artists/{artistId}/related-artists");

    public static Uri PersonalizationTop(string type) => EUri($"me/top/{type}");

    private static Uri EUri(FormattableString path) => new Uri(path.ToString(_provider), UriKind.Relative);
  }
}
