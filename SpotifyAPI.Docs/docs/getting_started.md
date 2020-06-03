---
id: getting_started
title: Getting Started
---

import InstallInstructions from '../src/install_instructions'

## Adding SpotifyAPI-NET to your project

The library can be added to your project via the following methods:

### Package Managers

<InstallInstructions />

### Add DLL Manually

You can also grab the latest compiled DLL from our [GitHub Releases Page](https://github.com/johnnycrazy/spotifyapi-net/releases). It can be added to your project via Visual Studio or directly in your `.csproj`:

```xml
<ItemGroup>
  <Reference Include="SpotifyAPI.Web">
    <HintPath>..\Dlls\SpotifyAPI.Web.dll</HintPath>
  </Reference>
</ItemGroup>
```

### Compile Yourself

```sh
git clone https://github.com/JohnnyCrazy/SpotifyAPI-NET.git
cd SpotifyAPI-NET
dotnet restore
dotnet build

ls -la SpotifyAPI.Web/bin/Debug/netstandard2.1/SpotifyAPI.Web.dll
```

## First API Calls

You're now ready to issue your first calls to the Spotify API, a small console example:

```csharp
using System;
using SpotifyAPI.Web;

class Program
{
    static async Task Main()
    {
      var spotify = new SpotifyClient("YourAccessToken");

      var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");
      Console.WriteLine(track.Name);
    }
}
```

:::tip
Notice that the spotify api does not allow unauthorized API access. Wondering where you should get an access token from? For a quick test, head over to the [Spotify Developer Console](https://developer.spotify.com/console/get-album/) and generate an access token with the required scopes! For a permanent solution, head over to the [authentication guides](auth_introduction).

:::

There is no online documentation for every available API call, but XML inline docs are available:

* [UserProfile](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IUserProfileClient.cs)
* [Browse](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IBrowseClient.cs)
* [Shows](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IShowsClient.cs)
* [Playlists](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPlaylistsClient.cs)
* [Search](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ISearchClient.cs)
* [Follow](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IFollowClient.cs)
* [Tracks](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ITracksClient.cs)
* [Player](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPlayerClient.cs)
* [Albums](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IAlbumsClient.cs)
* [Artists](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IArtistsClient.cs)
* [Personalization](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPersonalizationClient.cs)
* [Episodes](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IEpisodesClient.cs)
* [Library](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ILibraryClient.cs)

All calls have the [Spotify Web API documentation reference](https://developer.spotify.com/documentation/web-api/reference-beta/) attached as a remark.


## Query/Body Parameters

If an API endpoint has query or body parameters, a request model can be supplied to the method

```csharp
// No optional or required query/body parameters
// The track ID is part of the request path --> it's not treated as query/body parameter
var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");

// Optional query/body parameter
var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH", new TrackRequest{
  Market = "DE"
});

// Sometimes, query/body parameters are also required!
var tracks = await spotify.Tracks.GetSeveral(new TracksRequest(new List<string> {
  "1s6ux0lNiTziSrd7iUAADH",
  "6YlOxoHWLjH6uVQvxUIUug"
}));
```

If a query/body parameter is required, it has to be supplied in the constructor of the request model. In the background, empty/null checks are also performed to make sure required parameters are not empty/null. If it is optional, it can be supplied as a property to the request model.

## Guides

All other relevant topics are covered in the "Guides" and [Authentication Guides](auth_introduction) section in the sidebar!
