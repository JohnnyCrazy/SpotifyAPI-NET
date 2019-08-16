# Artists

## GetArtist

> Get Spotify catalog information for a single artist identified by their unique Spotify ID.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the artist. | `"1KpCi9BOfviCVhmpI4G2sY"`

Returns a [FullArtist](https://developer.spotify.com/web-api/object-model/#artist-object-full)

**Usage**
```csharp
FullArtist artist = _spotify.GetArtist("1KpCi9BOfviCVhmpI4G2sY");
Console.WriteLine()
```

---
## GetRelatedArtists
> Get Spotify catalog information about artists similar to a given artist. Similarity is based on analysis of the Spotify community's listening history.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the artist. | `"1KpCi9BOfviCVhmpI4G2sY"`

Returns a `SeveralArtists` object which contains the property `List<FullArtist> Artists` ([FullArtist](https://developer.spotify.com/web-api/object-model/#artist-object-full))

**Usage**
```csharp
SeveralArtists artists = _spotify.GetRelatedArtists("1KpCi9BOfviCVhmpI4G2sY");
Console.WriteLine(artists.Artists[0].Name);
```

---
## GetArtistsTopTracks
> Get Spotify catalog information about an artist's top tracks by country.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the artist. | `"1KpCi9BOfviCVhmpI4G2sY"`
|country| The country: an ISO 3166-1 alpha-2 country code. | `"DE"`

Returns a `SeveralTracks` object which contains the property `List<FullTrack> Tracks` ([FullTrack](https://developer.spotify.com/web-api/object-model/#track-object-full))

**Usage**
```csharp
SeveralTracks tracks = _spotify.GetArtistsTopTracks("1KpCi9BOfviCVhmpI4G2sY", "DE");
Console.WriteLine(tracks.Tracks.Count); //How many tracks did we get?
```

---
## GetArtistsAlbums
> Get Spotify catalog information about an artist's albums. Optional parameters can be specified in the query string to filter and sort the response.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the artist. | `"1KpCi9BOfviCVhmpI4G2sY"`
|[type]| A list of keywords that will be used to filter the response. If not supplied, all album types will be returned | `AlbumType.All`
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first album to return. Default: 0 | `0`
|[market]| An ISO 3166-1 alpha-2 country code. Supply this parameter to limit the response to one particular geographical market | `"DE"`

Returns a [SimpleAlbum](https://developer.spotify.com/web-api/object-model/#album-object-simplified) wrapped inside a [Paging-object](https://developer.spotify.com/web-api/object-model/#paging-object)

**Usage**
```csharp
Paging<SimpleAlbum> albums = _spotify.GetArtistsAlbums("1KpCi9BOfviCVhmpI4G2sY", AlbumType.All);
albums.Items.ForEach(album => Console.WriteLine(album.Name));
```

---
## GetSeveralArtists
> Get Spotify catalog information for several artists based on their Spotify IDs.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs for the artists. Maximum: 50 IDs. | `new List<String>() { "1KpCi9BOfviCVhmpI4G2sY" } `

Returns a `SeveralArtists` object which contains the property `List<FullArtist> Artists` ([FullArtist](https://developer.spotify.com/web-api/object-model/#artist-object-full))

**Usage**
```csharp
SeveralArtists artists = _spotify.GetSeveralArtists(new List<String>() {"1KpCi9BOfviCVhmpI4G2sY"});
artists.Artists.ForEach(artist => Console.WriteLine(artist.Name));
```

---
