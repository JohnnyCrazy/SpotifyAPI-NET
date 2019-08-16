---
sidebarDepth: 2
---

# Getting Started

This API provides full access to the new SpotifyWebAPI introduced [here](https://developer.spotify.com/web-api/).
With it, you can search for Tracks/Albums/Artists and also get User-based information.
It's also possible to create new playlists and add tracks to it.

## First steps

### Imports

So after you added the API to your project, you may want to add following imports to your files:

```csharp
using SpotifyAPI.Web; //Base Namespace
using SpotifyAPI.Web.Enums; //Enums
using SpotifyAPI.Web.Models; //Models for the JSON-responses
```

### Basic-Usage

Now you can actually start doing calls to the SpotifyAPI, just create a new Instance of SpotifyWebAPI:
```csharp
private static SpotifyWebAPI _spotify;

public static void Main(String[] args)
{
    _spotify = new SpotifyWebAPI()
    {
        AccessToken = "XXXXXXXXXXXX",
        TokenType = "Bearer"
    }
    FullTrack track = _spotify.GetTrack("3Hvu1pq89D4R0lyPBoujSv");
    Console.WriteLine(track.Name); //Yeay! We just printed a tracks name.
}
```

You may note that we used `AccessToken` and `TokenType`. Spotify does not allow un-authorized access to their API. You will need to implement one of the auth flows. Luckily, `SpotifyAPI.Web.Auth` exists for this reason. A simple way to receive a `AccessToken` is via `CredentialAuth`:

```csharp
CredentialsAuth auth = new CredentialsAuth("YourClientID", "YourClientSecret");
Token token = await auth.GetToken();
_spotify = new SpotifyWebAPI()
{
  AccessToken = token.AccessToken,
  TokenType = token.TokenType
}
```

For more info, visit the [Getting Started of SpotifyAPI.Web.Auth](/auth/getting_started/)

---

## Examples
A list of small examples can be found [here](/web/examples/). Do you think a specific example is missing? Feel free to open a PR.mdIssue!

---

## Error-Handling
Every API-Call returns a reponse-model which consists of base-error model. To check if a specific API-Call was successful, use the following approach:
```csharp
PrivateProfile profile = _spotify.GetPrivateProfile();
if (profile.HasError())
{
  Console.WriteLine("Error Status: " + profile.Error.Status);
  Console.WriteLine("Error Msg: " + profile.Error.Message);
}
```

In case some or all of the returned values are null, consult error status and message, they can lead to an explanation!

## Sync vs Asynchronous
Every API-Call has an `asynchronous` and `synchronous` method.

```csharp
public async void Test()
{
  var asyncProfile = await _spotify.GetPrivateProfileAsync();
  var syncProfile = _spotify.GetPrivateProfile();
}
```

Note that the `synchronous` call will block the current Thread!

---

## API-Reference

### Albums
* [GetAlbumTracks](/web/albums.md#getalbumtracks)
* [GetAlbum](/web/albums.md#getalbum)
* [GetSeveralAlbums](/web/albums.md#getseveralalbums)

### Artists
* [GetArtist](/web/artists.md#getartist)
* [GetRelatedArtists](/web/artists.md#getrelatedartists)
* [GetArtistsTopTracks](/web/artists.md#getartiststoptracks)
* [GetArtistsAlbums](/web/artists.md#getartistsalbums)
* [GetSeveralArtists](/web/artists.md#getseveralartists)

### Browse
* [GetFeaturedPlaylists](/web/browse.md#getfeaturedplaylists)
* [GetNewAlbumReleases](/web/browse.md#getnewalbumreleases)
* [GetCategories](/web/browse.md#getcategories)
* [GetCategory](/web/browse.md#getcategory)
* [GetCategoryPlaylists](/web/browse.md#getcategoryplaylists)

### Follow
* [Follow](/web/follow.md#follow)
* [Unfollow](/web/follow.md#unfollow)
* [IsFollowing](/web/follow.md#isfollowing)
* [FollowPlaylist](/web/follow.md#followplaylist)
* [UnfollowPlaylist](/web/follow.md#unfollowplaylist)
* [IsFollowingPlaylist](/web/follow.md#isfollowingplaylist)

### Library
* [SaveTracks](/web/library.md#savetracks)
* [SaveTrack](/web/library.md#savetrack)
* [GetSavedTracks](/web/library.md#getsavedtracks)
* [RemoveSavedTracks](/web/library.md#removesavedtracks)
* [CheckSavedTracks](/web/library.md#checksavedtracks)
* [SaveAlbums](/web/library.md#savealbums)
* [SaveAlbum](/web/library.md#savealbum)
* [GetSavedAlbums](/web/library.md#getsavedalbums)
* [RemoveSavedAlbums](/web/library.md#removesavedalbums)
* [CheckSavedAlbums](/web/library.md#checksavedalbums)

### Personalization
* [GetUsersTopTracks](/web/personalization.md#getuserstoptracks)
* [GetUsersTopArtists](/web/personalization.md#getuserstopartists)
* [GetUsersRecentlyPlayedTracks](/web/personalization.md#getusersrecentlyplayedtracks)

### Player

* [GetDevices](/web/player.md#getdevices)
* [GetPlayback](/web/player.md#getplayback)
* [GetPlayingTrack](/web/player.md#getplayingtrack)
* [TransferPlayback](/web/player.md#transferplayback)
* [ResumePlayback](/web/player.md#resumeplayback)
* [PausePlayback](/web/player.md#pauseplayback)
* [SkipPlaybackToNext](/web/player.md#skipplaybacktonext)
* [SkipPlaybackToPrevious](/web/player.md#skipplaybacktoprevious)
* [SetRepeatMode](/web/player.md#setrepeatmode)
* [SetVolume](/web/player.md#setvolume)
* [SetShuffle](/web/player.md#setshuffle)

### Playlists
* [GetUserPlaylists](/web/playlists.md#getuserplaylists)
* [GetPlaylist](/web/playlists.md#getplaylist)
* [GetPlaylistTracks](/web/playlists.md#getplaylisttracks)
* [CreatePlaylist](/web/playlists.md#createplaylist)
* [UpdatePlaylist](/web/playlists.md#updateplaylist)
* [ReplacePlaylistTracks](/web/playlists.md#replaceplaylisttracks)
* [RemovePlaylistTracks](/web/playlists.md#removeplaylisttracks)
* [RemovePlaylistTrack](/web/playlists.md#removeplaylisttrack)
* [AddPlaylistTracks](/web/playlists.md#addplaylisttracks)
* [AddPlaylistTrack](/web/playlists.md#addplaylisttrack)
* [ReorderPlaylist](/web/playlists.md#reorderplaylist)

### Profiles
* [GetPublicProfile](/web/profiles.md#getpublicprofile)
* [GetPrivateProfile](/web/profiles.md#getprivateprofile)

### Search
* [SearchItems](/web/search.md#searchitems)
* [SearchItemsEscaped](/web/search.md#searchitemsescaped)

### Tracks
* [GetSeveralTracks](/web/tracks.md#getseveraltracks)
* [GetTrack](/web/tracks.md#gettrack)
* [GetAudioAnalysis](/web/tracks.md#getaudioanalysis)

### Util
* [Utility-Functions](/web/utils.md)
