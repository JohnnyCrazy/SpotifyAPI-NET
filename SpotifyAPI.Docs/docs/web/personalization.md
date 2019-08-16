# Personalization

## GetUsersTopTracks

> Get the current user’s top tracks based on calculated affinity.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[timeRange]| Over what time frame the affinities are compute. | `TimeRangeType.MediumTerm`
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities. | `0`

Returns a [FullTrack](https://developer.spotify.com/web-api/object-model/#track-object-full) wrapped inside a [Paging-object](https://developer.spotify.com/web-api/object-model/#paging-object)

**Usage**

```
Paging<FullTrack> tracks = _spotify.GetUsersTopTracks();
tracks.Items.ForEach(item => Console.WriteLine(item.Name)); //Display all fetched Track-Names (max 20)
Console.WriteLine(tracks.Total.ToString()) //Display total album track count
```

---
## GetUsersTopArtists
> Get the current user’s top artists based on calculated affinity.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[timeRange]| Over what time frame the affinities are compute. | `TimeRangeType.MediumTerm`
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities. | `0`

Returns a [FullArtist](https://developer.spotify.com/web-api/object-model/#artist-object-full) wrapped inside a [Paging-object](https://developer.spotify.com/web-api/object-model/#paging-object)

**Usage**
```
Paging<FullArtist> artists = _spotify.GetUsersTopArtists();
artists.Items.ForEach(item => Console.WriteLine(item.Name)); //Display all fetched Artist-Names (max 20)
```

---
## GetUsersRecentlyPlayedTracks
> Get tracks from the current user’s recent play history.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[after]|  Returns all items after (but not including) this cursor position. | `DateTime.Now.AddDays(-1)`
|[before]|  Returns all items before (but not including) this cursor position. | `DateTime.Now.AddDays(-1)`

Returns a `PlayHistory` wrapped inside a [CursorPaging-object](https://developer.spotify.com/web-api/object-model/#cursor-based-paging-object)

**Usage**
```
CursorPaging<PlayHistory> histories = _spotify.GetUsersRecentlyPlayedTracks();
histories.Items.ForEach(item => Console.WriteLine(item.Track.Name));
```

---
