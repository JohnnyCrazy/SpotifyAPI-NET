# Getting started

This API provides some access to the local running Spotify-Client (Windows only).  
You can fetch details for the current track, play/pause, skip/previous track and
get notified on various events.

**NOTE:** This API is unofficial, things may brake in the future and there is no
guarantee everything works out of the box.

---

## First steps

**Imports**  
So after you added the API to your project, you may want to add following imports to your files:

```cs
using SpotifyAPI.Local; //Base Namespace
using SpotifyAPI.Local.Enums; //Enums
using SpotifyAPI.Local.Models; //Models for the JSON-responses
```

**Basic-Usage**  
Now you can actually start fetching infos from your spotify client, just create a new Instance of SpotifyLocalAPI:
```cs
private static SpotifyLocalAPI _spotify;

public static void Main(String[] args)
{
    _spotify = new SpotifyLocalAPI();
    if (!SpotifyLocalAPI.IsSpotifyRunning())
      return; //Make sure the spotify client is running
    if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
      return; //Make sure the WebHelper is running

    if(!_spotify.Connect())
      return; //We need to call Connect before fetching infos, this will handle Auth stuff

    StatusResponse status = _spotify.GetStatus(); //status contains infos
}
```

## Configuration

Different spotify versions often require different configuration. Some versions run their web-helper on port `4371`, others on `4381`. Also, some use `https`, and others use `http`. You can use `SpotifyLocalAPIConfig` to configure the API:

```cs
_spotify = new SpotifyLocalAPI(new SpotifyLocalAPIConfig
{
    Port = 4371,
    HostUrl = "https://127.0.0.1"
});
```

## Anti-Virus Blocking Response

Some Anti-Virus Software blocks the response from spotify due wrong headers.
Currently, it's confirmed for AVG's LinkScanner and Bitdefender.
Adding `http://SpotifyAPI.spotilocal.com:4380` to the URL-Exceptions seems to fix it for most users.
More infos can be found [here](https://github.com/JohnnyCrazy/SpotifyAPI-NET/issues/51)

## Client Status

Calling `_spotify.GetStatus()` after connecting returns the following `StatusResponse`:

```
public int Version { get; set; }

public string ClientVersion { get; set; }

public bool Playing { get; set; }

public bool Shuffle { get; set; }

public bool Repeat { get; set; }

public bool PlayEnabled { get; set; }

public bool PrevEnabled { get; set; }

public bool NextEnabled { get; set; }

public Track Track { get; set; }

public double PlayingPosition { get; set; }

public int ServerTime { get; set; }

public double Volume { get; set; }

public bool Online { get; set; }

public bool Running { get; set; }
```

Most of the properties are self-explanatory, some notes:

* `Shuffle` and `Repeat` currently always return `false`

## Current Track

The current Track can be fetched via `_spotify.GetStatus().Track` and contains following properties/methods:

* `TrackResource` - `SpotifyResource` which contains Track `Name` and `Uri`
* `AlbumResource` - `SpotifyResource` which contains Album `Name` and `Uri`
* `ArtistResource` - `SpotifyResource` which contains Artist `Name` and `Uri` (Only the main artist will be listed)
* `IsAd()` will check whether the current track is an AD
* Various methods for getting the album art:
  * `string GetAlbumArtUrl(AlbumArtSize size)`
  * `Task<Bitmap> GetAlbumArtAsync(AlbumArtSize size)`
  * `Bitmap GetAlbumArt(AlbumArtSize size)`
  * `Task<byte[]> GetAlbumArtAsByteArrayAsync(AlbumArtSize size)`
  * `byte[] GetAlbumArtAsByteArray(AlbumArtSize size)`

## Events

To receive events, make sure you listen for them `_spotify.ListenForEvents = true;`  
You can set a `SynchronizingObject`, then the events will be called on the specific context

Following events can be overriden:

* `OnPlayStateChange` - triggers when the player changes from `play` to `pause` and vice versa
* `OnTrackChange` - triggers when a new track will be played
* `OnTrackTimeChange` - triggers when a track is playing and track-time changes
* `OnVolumeChange` - triggeres when the internal volume of spotify changes

## Methods

Furthermore, following methods are available:

* `void Mute()` - will mute the Spotify client via WindowsAPI
* `void UnMute()` - will unmute the Spotify client via WindowsAPI
* `bool IsSpotifyMuted()` - will return wether the Spotify client is muted
* `void SetSpotifyVolume(float volume = 100)` - sets the windows volume of spotify (0 - 100)
* `float GetSpotifyVolume()` - returns the windows volume of spotify (0 - 100)
* `void Pause()` - will pause spotify's playback
* `void Play()` - will resume spotify's playback
* `void PlayURL(string uri, string context = "")` - will play a spotify URI (track/album/playlist) in the specifc context (can be a album/playlist URI)
* `void Skip()` - will skip the track via an emulated media key
* `void Previous()` - will play the previous track via an emulated media key
* `bool IsSpotifyRunning()` - returns true if a spotify client instance is running, false if not
* `bool IsSpotifyWebHelperRunning()` - returns true if a spotify web-helper instance is running, false if not
* `void RunSpotify()` - will attempt to start a Spotify instance
* `void RunSpotifyWebHelper()` - will attempt to start a Spotify web-helper instance
