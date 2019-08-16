# Playlists

## GetUserPlaylists

> Get a list of the playlists owned or followed by a Spotify user.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|[limit]| The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first playlist to return. Default: 0 (the first object) | `0`

Returns a [SimplePlaylist](https://developer.spotify.com/web-api/object-model/#playlist-object-simplified) wrapped inside a [Paging Object](https://developer.spotify.com/web-api/object-model/#paging-object)

**Usage**
```csharp
Paging<SimplePlaylist> userPlaylists = _spotify.GetUserPlaylists("1122095781");
userPlaylists.Items.ForEach(playlist => playlist.Owner.DisplayName) //Who is the owner of the playlist?
```

---
## GetPlaylist

> Get a playlist owned by a Spotify user.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|[fields]| Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned. | `"description,uri"`
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | "DE"

Returns a [FullTrack](https://developer.spotify.com/web-api/object-model/#track-object-full)

**Usage**
```csharp
FullPlaylist playlist = _spotify.GetPlaylist("1122095781", "1TtEejT1y4D1WmcOnLfha2");
playlist.Tracks.Items.ForEach(track => Console.WriteLine(track.Track.Name));
```

---
## GetPlaylistTracks

> Get full details of the tracks of a playlist owned by a Spotify user.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|[fields]| Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned. | `"description,uri"`
|[limit]| The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100. | `100`
|[offset]| The index of the first object to return. Default: 0 (i.e., the first object) | `0`
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `DE`

Returns a [PlaylistTrack](https://developer.spotify.com/web-api/object-model/#playlist-object-simplified) wrapped inside a [Paging Object](https://developer.spotify.com/web-api/object-model/#paging-object)

**Usage**
```csharp
Paging<PlaylistTrack> playlist = _spotify.GetPlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2");
playlist.Items.ForEach(track => Console.WriteLine(track.Track.Name));
```

---
## CreatePlaylist

> Create a playlist for a Spotify user. (The playlist will be empty until you add tracks.)

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistName| The name for the new playlist, for example "Your Coolest Playlist". This name does not need to be unique. | `"This is my new Playlist"`
|[isPublic]| default true. If true the playlist will be public, if false it will be private. To be able to create private playlists, the user must have granted the playlist-modify-private scope. | `true`

Returns a [FullPlaylist](https://developer.spotify.com/web-api/object-model/#playlist-object-full)

**Usage**
```csharp
FullPlaylist playlist = _spotify.CreatePlaylist("1122095781", "This is my new Playlist");
if(!playlist.HasError())
    Console.WriteLine("Playlist-URI: " + playlist.Uri);
```

---
## UpdatePlaylist

> Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|[newName]| The new name for the playlist, for example "My New Playlist Title". | `"New Playlistname"`
|[newPublic]| If true the playlist will be public, if false it will be private. | EXAMPLE

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.UpdatePlaylist("1122095781", "1TtEejT1y4D1WmcOnLfha2", "New Name", true);
if(!response.HasError())
    Console.WriteLine("success");
```

---
## ReplacePlaylistTracks

> Replace all the tracks in a playlist, overwriting its existing tracks. This powerful request can be useful for replacing tracks, re-ordering existing tracks, or clearing the playlist.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|uris| A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request. | `new List<string> { "1ri6UZpjPLmTCswIXZ6Uq1" }`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.ReplacePlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2", new List<string> { "1ri6UZpjPLmTCswIXZ6Uq1" });
if(!response.HasError())
    Console.WriteLine("success");
```

---
## RemovePlaylistTracks

> Remove one or more tracks from a user’s playlist.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|uris| array of objects containing Spotify URI strings (and their position in the playlist). A maximum of 100 objects can be sent at once. | `(example below)`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
//Remove multiple tracks
ErrorResponse playlist = _spotify.RemovePlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2", new List<DeleteTrackUri>()
{
    new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1"),
    new DeleteTrackUri("47xtGU3vht7mXLHqnbaau5")
});
//Remove multiple tracks at their specified positions
ErrorResponse playlist = _spotify.RemovePlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2", new List<DeleteTrackUri>()
{
    new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1", 2),
    new DeleteTrackUri("47xtGU3vht7mXLHqnbaau5", 0, 50)
});
```

---
## RemovePlaylistTrack

> Remove one or more tracks from a user’s playlist.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|uri| Spotify URI | `new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1")`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)


**Usage**
```csharp
//Remove all tracks with the specified URI
ErrorResponse response = _spotify.RemovePlaylistTrack("1122095781", "1TtEejT1y4D1WmcOnLfha2", new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1"));
//Remove all tracks with the specified URI and the specified positions
ErrorResponse response = _spotify.RemovePlaylistTrack("1122095781", "1TtEejT1y4D1WmcOnLfha2", new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1", 0, 10, 20));
```

---
## AddPlaylistTracks

> Add one or more tracks to a user’s playlist.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|uris| A list of Spotify track URIs to add | `new List<string> { "1ri6UZpjPLmTCswIXZ6Uq1" }`
|[position]| The position to insert the tracks, a zero-based index | `10`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.AddPlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2", new List<string> { "1ri6UZpjPLmTCswIXZ6Uq1" });
if(!response.HasError())
    Console.WriteLine("Success");
```

---
## AddPlaylistTrack

> Add one or more tracks to a user’s playlist.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|uri| A Spotify Track URI | `"1ri6UZpjPLmTCswIXZ6Uq1"`
|position| The position to insert the tracks, a zero-based index | `10`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.AddPlaylistTrack("1122095781", "1TtEejT1y4D1WmcOnLfha2", "1ri6UZpjPLmTCswIXZ6Uq1");
if(!response.HasError())
    Console.WriteLine("Success");
```

---
## ReorderPlaylist

> Reorder a track or a group of tracks in a playlist.
> More Info: [Reorder-Playlist](https://developer.spotify.com/web-api/reorder-playlists-tracks/)

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | `"1122095781"`
|playlistId| The Spotify ID for the playlist. | `"1TtEejT1y4D1WmcOnLfha2"`
|rangeStart| The position of the first track to be reordered. | `2`
|insertBefore| The position where the tracks should be inserted. | `0`
|[rangeLength]| The amount of tracks to be reordered. Defaults to 1 if not set. | `2`
|[snapshotId]| The playlist's snapshot ID against which you want to make the changes. | ``

Returns a `Snapshot`-Object which contains the property `String SnapshotId`

**Usage**
```csharp
Snapshot snapshot = _spotify.ReorderPlaylist("1122095781", "1TtEejT1y4D1WmcOnLfha2", 2, 0, 2);
Console.WriteLine("New SnapshotId: " + snapshot.SnapshotId);
```

---
