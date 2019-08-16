# Search

## SearchItems

> Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.

::: warning
You may want to use `SearchItemsEscaped` if you're processing user-input without validation
:::

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|q| The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues. | `"roadhouse+blues"`
|type| A list of item types to search across. | `SearchType.Album`
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first result to return. Default: 0 | `0`
|[market]| An ISO 3166-1 alpha-2 country code or the string from_token. | `"de"`

Returns a `SearchItem` which contains the properties `Paging<FullArtist> Artists`,`Paging<FullTrack> Tracks`, `Paging<SimpleAlbum> Albums`, `Paging<SimplePlaylist> Playlists`. They are filled based on your search-type.

**Usage**
```csharp
SearchItem item = _spotify.SearchItems("roadhouse+blues", SearchType.Album | SearchType.Playlist);
Console.WriteLine(item.Albums.Total); //How many results are there in total? NOTE: item.Tracks = item.Artists = null
```

---

## SearchItemsEscaped

> Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.

Works like `SearchItems`, but URL escapes all characters
