---
id: iplayableitem
title: IPlayableItem
---

When working with playlists or the current playing context, you will encounter a type `IPlayableItem`, which only contains a `Type` property. Spotify recently introduced shows/episodes to the API, and thus had to adapt API endpoints which previously just returned track objects. Now, playlists and the current playing context can include two types, tracks and episodes. To reflect this in our models, we introduced `IPlayableItem`.

```csharp
var spotify = new SpotifyClient("YourAccessToken");

var playlist = await spotify.Playlists.Get("37i9dQZEVXbMDoHDwVN2tF");
foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
{
  // When was it added
  Console.WriteLine(item.AddedAt);
  // The only propety on item is item.Type, it's a IPlayableItem
  Console.WriteLine(item.Track.Type);
}
```

Now, this type per se is probably useless to you. You're interested in the name, uri or artist of the episode/track. To get that info, you have to type cast the `IPlayableItem` to the respective type:

```csharp
foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
{
  if (item.Track is FullTrack track)
  {
    // All FullTrack properties are available
    Console.WriteLine(track.Name);
  }
  if (item.Track is FullEpisode episode)
  {
    // All FullTrack properties are available
    Console.WriteLine(episode.Name);
  }
}
```

To this day, `IPlayableItem` can only be `FullTrack` or `FullEpisode`.
