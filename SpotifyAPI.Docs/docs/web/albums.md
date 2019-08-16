# Albums

## GetAlbumTracks
> Get Spotify catalog information about an album's tracks. Optional parameters can be used to limit the number of tracks returned.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the album. | `"5O7V8l4SeXTymVp3IesT9C"`
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first track to return. Default: 0 (the first object). | `0`
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `"DE"`

Returns a [SimpleTrack](https://developer.spotify.com/web-api/object-model/#track-object-simplified) wrapped inside a [Paging-object](https://developer.spotify.com/web-api/object-model/#paging-object)

**Usage**

```csharp
Paging<SimpleTrack> tracks = _spotify.GetAlbumTracks("5O7V8l4SeXTymVp3IesT9C");
tracks.Items.ForEach(item => Console.WriteLine(item.Name)); //Display all fetched Track-Names (max 20)
Console.WriteLine(tracks.Total.ToString()) //Display total album track count
```

---
## GetAlbum
> Get Spotify catalog information for a single album.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the album. | `5O7V8l4SeXTymVp3IesT9C`
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `"DE"`

Returns a [FullAlbum](https://developer.spotify.com/web-api/object-model/#album-object-full)

**Usage**
```csharp
FullAlbum album = _spotify.GetAlbum("5O7V8l4SeXTymVp3IesT9C");
Console.WriteLine(album.Name + "| Popularity: " + album.Popularity); //Display name and Popularity
```

---
## GetSeveralAlbums
> Get Spotify catalog information for multiple albums identified by their Spotify IDs.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs for the albums. Maximum: 20 IDs. | `new List<String>() { "5O7V8l4SeXTymVp3IesT9C" }`
|[market]| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `"DE"`

Returns a `SeveralAlbums` which Property "Albums" contains a list of [FullAlbum](https://developer.spotify.com/web-api/object-model/#album-object-full)

**Usage**
```csharp
SeveralAlbums albums = _spotify.GetSeveralAlbums(new List<String>() { "5O7V8l4SeXTymVp3IesT9C" });
Console.WriteLine(albums.Albums[0].Name);
```

---
