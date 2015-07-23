##GetUserPlaylists
<span class="label label-warning">AUTH REQUIRED</span>
> Get a list of the playlists owned or followed by a Spotify user.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|limit| The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50. | EXAMPLE
|offset| The index of the first playlist to return. Default: 0 (the first object) | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##GetPlaylist
<span class="label label-warning">AUTH REQUIRED</span>
> Get a playlist owned by a Spotify user.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|fields| Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are                returned. | EXAMPLE
|market| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##GetPlaylistTracks
<span class="label label-warning">AUTH REQUIRED</span>
> Get full details of the tracks of a playlist owned by a Spotify user.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|fields| Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are                returned. | EXAMPLE
|limit| The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100. | EXAMPLE
|offset| The index of the first object to return. Default: 0 (i.e., the first object) | EXAMPLE
|market| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##CreatePlaylist
<span class="label label-warning">AUTH REQUIRED</span>
> Create a playlist for a Spotify user. (The playlist will be empty until you add tracks.)

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistName| The name for the new playlist, for example "Your Coolest Playlist". This name does not need                to be unique. | EXAMPLE
|isPublic| default true. If true the playlist will be public, if false it will be private. To be able to                create private playlists, the user must have granted the playlist-modify-private scope. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##UpdatePlaylist
<span class="label label-warning">AUTH REQUIRED</span>
> Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|newName| The new name for the playlist, for example "My New Playlist Title". | EXAMPLE
|newPublic| If true the playlist will be public, if false it will be private. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##ReplacePlaylistTracks
<span class="label label-warning">AUTH REQUIRED</span>
> Replace all the tracks in a playlist, overwriting its existing tracks. This powerful request can be useful for                replacing tracks, re-ordering existing tracks, or clearing the playlist.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|uris| A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##RemovePlaylistTracks
<span class="label label-warning">AUTH REQUIRED</span>
> Remove one or more tracks from a user’s playlist.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|uris| array of objects containing Spotify URI strings (and their position in the playlist). A maximum of                100 objects can be sent at once. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##RemovePlaylistTrack
<span class="label label-warning">AUTH REQUIRED</span>
> Remove one or more tracks from a user’s playlist.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|uri| Spotify URI | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##AddPlaylistTracks
<span class="label label-warning">AUTH REQUIRED</span>
> Add one or more tracks to a user’s playlist.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|uris| A list of Spotify track URIs to add | EXAMPLE
|position| The position to insert the tracks, a zero-based index | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##AddPlaylistTrack
<span class="label label-warning">AUTH REQUIRED</span>
> Add one or more tracks to a user’s playlist.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|uri| A Spotify Track URI | EXAMPLE
|position| The position to insert the tracks, a zero-based index | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
##ReorderPlaylist
<span class="label label-warning">AUTH REQUIRED</span>
> Reorder a track or a group of tracks in a playlist.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE
|playlistId| The Spotify ID for the playlist. | EXAMPLE
|rangeStart| The position of the first track to be reordered. | EXAMPLE
|insertBefore| The position where the tracks should be inserted. | EXAMPLE
|rangeLength| The amount of tracks to be reordered. Defaults to 1 if not set. | EXAMPLE
|snapshotId| The playlist's snapshot ID against which you want to make the changes. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```cs
```

---
