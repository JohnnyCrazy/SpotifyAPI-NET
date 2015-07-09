##GetAlbumTracks
> Get Spotify catalog information about an album's tracks. Optional parameters can be used to limit the number of tracks returned.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the album. | EXAMPLE
|limit| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | EXAMPLE
|offset| The index of the first track to return. Default: 0 (the first object). | EXAMPLE
|market| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```csharp
```

---
##GetAlbum
> Get Spotify catalog information for a single album.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the album. | EXAMPLE
|market| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```csharp
```

---
##GetSeveralAlbums
> Get Spotify catalog information for multiple albums identified by their Spotify IDs.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs for the albums. Maximum: 20 IDs. | EXAMPLE
|market| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```csharp
```

---