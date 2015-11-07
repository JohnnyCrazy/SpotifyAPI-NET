##Paging-Methods
The `SpotifyWebAPI` features two paging-helper Methods, `GetNextPage()` and `GetPreviousPage()`.
Both are an easy way to receive the next/previous page of a Paging-Object.

Sample:
````csharp
var playlistTracks = _spotify.GetPlaylistTracks("1122095781", "4EcNf2l8rXInbJOf3tQdgU", "", 50);
while (true)
{
    Console.WriteLine(playlistTracks.Items.Count);
    if (!playlistTracks.HasNextPage())
        break;
    playlistTracks = _spotify.GetNextPage(playlistTracks);
}
````
