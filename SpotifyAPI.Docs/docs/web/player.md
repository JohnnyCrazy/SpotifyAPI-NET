# Player

## GetDevices
> Get information about a user’s available devices.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|

**Usage**

```csharp
AvailabeDevices devices = _spotify.GetDevices();
devices.Devices.ForEach(device => Console.WriteLine(device.Name));
```

---

## GetPlayback
> Get information about the user’s current playback state, including track, track progress, and active device.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `"DE"`

**Usage**

```csharp
PlaybackContext context = _spotify.GetPlayback();
if(contex.Item != null)
  Console.WriteLine(context.Item.Name)); //Print the current song
```

---

## GetPlayingTrack
> Get the object currently being played on the user’s Spotify account.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `"DE"`

This is a simpler (less data) version of `GetPlayback`

**Usage**

```csharp
PlaybackContext context = _spotify.GetPlayingTrack();
if(contex.Item != null)
  Console.WriteLine(context.Item.Name)); //Print the current song
```

---

## TransferPlayback
> Transfer playback to a new device and determine if it should start playing.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|deviceIds or deviceId| A JSON array containing the ID of the device on which playback should be started/transferred | `"XXXX-XXXX-XXXX-XXXX"`
| play | true: ensure playback happens on new device, false: keep current playback state | `true`

**Usage**

```csharp
ErrorResponse error = _spotify.TransferPlayback("XXXX-XXXX-XXXX-XXXX");
```

---

## ResumePlayback
> Start a new context or resume current playback on the user’s active device.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[deviceId]| The id of the device this command is targeting. If not supplied, the user's currently active device is the target. | `"XXXX-XXXX-XXXX-XXXX"`
| contextUri | Spotify URI of the context to play | `"spotify:album:1Je1IMUlBXcx1Fz0WE7oPT"`
| uris | An array of the Spotify track URIs to play. | `new List<string> { "spotify:track:4iV5W9uYEdYUVa79Axb7Rh" }`
| offset | Indicates from where in the context playback should start. Only available when context_uri corresponds to an album or playlist object, or when the uris parameter is used. | `0`

**Usage**

```csharp
ErrorResponse error = _spotify.ResumePlayback(uris: new List<string> { "spotify:track:4iV5W9uYEdYUVa79Axb7Rh" });
```

---

## PausePlayback
> Pause playback on the user’s account.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[deviceId]| The id of the device this command is targeting. If not supplied, the user's currently active device is the target. | `"XXXX-XXXX-XXXX-XXXX"`

**Usage**

```csharp
ErrorResponse error = _spotify.PausePlayback();
```

---

## SkipPlaybackToNext
> Skips to next track in the user’s queue.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[deviceId]| The id of the device this command is targeting. If not supplied, the user's currently active device is the target. | `"XXXX-XXXX-XXXX-XXXX"`

**Usage**

```csharp
ErrorResponse error = _spotify.SkipPlaybackToNext();
```

---

## SkipPlaybackToPrevious
> Skips to previous track in the user’s queue.
Note that this will ALWAYS skip to the previous track, regardless of the current track’s progress.
Returning to the start of the current track should be performed using the https://api.spotify.com/v1/me/player/seek endpoint.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[deviceId]| The id of the device this command is targeting. If not supplied, the user's currently active device is the target. | `"XXXX-XXXX-XXXX-XXXX"`

**Usage**

```csharp
ErrorResponse error = _spotify.SkipPlaybackToPrevious();
```

---

## SeekPlayback
> Seeks to the given position in the user’s currently playing track.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|positionMs|The position in milliseconds to seek to. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.| `50`
|[deviceId]| The id of the device this command is targeting. If not supplied, the user's currently active device is the target. | `"XXXX-XXXX-XXXX-XXXX"`

**Usage**

```csharp
ErrorResponse error = _spotify.SeekPlayback(50);
```

---

## SetRepeatMode
> Set the repeat mode for the user’s playback. Options are repeat-track, repeat-context, and off.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|state|track, context or off.| `RepeatState.Track`
|[deviceId]| The id of the device this command is targeting. If not supplied, the user's currently active device is the target. | `"XXXX-XXXX-XXXX-XXXX"`

**Usage**

```csharp
ErrorResponse error = _spotify.SetRepeatMode(RepeatState.Track);
```

---

## SetVolume
> Set the volume for the user’s current playback device.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|volumePercent|Integer. The volume to set. Must be a value from 0 to 100 inclusive.| `50`
|[deviceId]| The id of the device this command is targeting. If not supplied, the user's currently active device is the target. | `"XXXX-XXXX-XXXX-XXXX"`

**Usage**

```csharp
ErrorResponse error = _spotify.SetVolume(50);
```

---

## SetShuffle
> Toggle shuffle on or off for user’s playback.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|shuffle|True or False| `false`
|[deviceId]| The id of the device this command is targeting. If not supplied, the user's currently active device is the target. | `"XXXX-XXXX-XXXX-XXXX"`

**Usage**

```csharp
ErrorResponse error = _spotify.SetShuffle(false);
```
