# Library

## SaveTracks

> Save one or more tracks to the current user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs | `new List<String> { "3Hvu1pq89D4R0lyPBoujSv" }`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.SaveTracks(new List<string> { "3Hvu1pq89D4R0lyPBoujSv" });
if(!response.HasError())
    Console.WriteLine("success");
```

---
## SaveTrack

> Save one track to the current user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| A Spotify ID | `"3Hvu1pq89D4R0lyPBoujSv"`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.SaveTrack("3Hvu1pq89D4R0lyPBoujSv");
if(!response.HasError())
    Console.WriteLine("success");
```

---
## GetSavedTracks

> Get a list of the songs saved in the current Spotify user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[limit]| The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first object to return. Default: 0 (i.e., the first object) | `0`
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `DE`

Returns a `Paging<SavedTrack>**, **SavedTrack` contains 2 properties, `DateTime AddedAt` and `FullTrack Track`

**Usage**
```csharp
Paging<SavedTrack> savedTracks = _spotify.GetSavedTracks();
savedTracks.Items.ForEach(track => Console.WriteLine(track.Track.Name));
```

---
## RemoveSavedTracks

> Remove one or more tracks from the current user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs. | `new List<String> { "3Hvu1pq89D4R0lyPBoujSv" }`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.RemoveSavedTracks(new List<string> { "3Hvu1pq89D4R0lyPBoujSv" });
if(!response.HasError())
    Console.WriteLine("success");
```

---
## CheckSavedTracks

> Check if one or more tracks is already saved in the current Spotify user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs. | `new List<String> { "3Hvu1pq89D4R0lyPBoujSv" }`

Returns a `ListResponse<bool>` which contains a property, `List<bool> List`

**Usage**
```csharp
ListResponse<bool> tracksSaved = _spotify.CheckSavedTracks(new List<String> { "3Hvu1pq89D4R0lyPBoujSv" });
if(tracksSaved.List[0])
    Console.WriteLine("The track is in your library!");
```

---
## SaveAlbums

> Save one or more albums to the current user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs | `new List<String> { "1cq06d0kTUnFmJHixz1RaF" }`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.SaveAlbums(new List<string> { "1cq06d0kTUnFmJHixz1RaF" });
if(!response.HasError())
    Console.WriteLine("success");
```

---
## SaveAlbum

> Save one album to the current user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| A Spotify ID | `"1cq06d0kTUnFmJHixz1RaF"`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.SaveAlbum("1cq06d0kTUnFmJHixz1RaF");
if(!response.HasError())
    Console.WriteLine("success");
```

---
## GetSavedAlbums

> Get a list of the albums saved in the current Spotify user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[limit]| The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first object to return. Default: 0 (i.e., the first object) | `0`
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `DE`

Returns a `Paging<SavedAlbum>`, **SavedAlbum** contains 2 properties, `DateTime AddedAt` and `FullAlbum Album`

**Usage**
```csharp
Paging<SavedAlbum> savedAlbums = _spotify.GetSavedAlbums();
savedAlbums.Items.ForEach(album => Console.WriteLine(album.Album.Name));
```

---
## RemoveSavedAlbums

> Remove one or more albums from the current user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs. | `new List<String> { "1cq06d0kTUnFmJHixz1RaF" }`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.RemoveSavedAlbums(new List<string> { "1cq06d0kTUnFmJHixz1RaF" });
if(!response.HasError())
    Console.WriteLine("success");
```

---
## CheckSavedAlbums

> Check if one or more albums is already saved in the current Spotify user’s “Your Music” library.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs. | `new List<String> { "1cq06d0kTUnFmJHixz1RaF" }`

Returns a `ListResponse<bool>` which contains a property, `List<bool> List`

**Usage**
```csharp
ListResponse<bool> albumsSaved = _spotify.CheckSavedAlbums(new List<String> { "1cq06d0kTUnFmJHixz1RaF" });
if(albumsSaved.List[0])
    Console.WriteLine("The album is in your library!");
```

---
