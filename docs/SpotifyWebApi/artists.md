##GetArtist
> Get Spotify catalog information for a single artist identified by their unique Spotify ID.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the artist. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```csharp
```

---
##GetRelatedArtists
> Get Spotify catalog information about artists similar to a given artist. Similarity is based on analysis of the Spotify community's listening history.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the artist. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```csharp
```

---
##GetArtistsTopTracks
> Get Spotify catalog information about an artist's top tracks by country.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the artist. | EXAMPLE
|country| The country: an ISO 3166-1 alpha-2 country code. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```csharp
```

---
##GetArtistsAlbums
> Get Spotify catalog information about an artist's albums. Optional parameters can be specified in the query string to filter and sort the response.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the artist. | EXAMPLE
|type| A list of keywords that will be used to filter the response. If not supplied, all album types will be returned | EXAMPLE
|limit| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | EXAMPLE
|offset| The index of the first album to return. Default: 0 | EXAMPLE
|market| An ISO 3166-1 alpha-2 country code. Supply this parameter to limit the response to one particular geographical market | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```csharp
```

---
##GetSeveralArtists
> Get Spotify catalog information for several artists based on their Spotify IDs.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs for the artists. Maximum: 50 IDs. | EXAMPLE

Returns a [Public User Model](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**  
```csharp
```

---