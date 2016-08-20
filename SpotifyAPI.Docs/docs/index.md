# SpotifyAPI-NET Documentation

##About
This Library, written in C#/.NET, combines two independent SpotifyAPIs into one.

**Spotify's Web API** ([link](https://developer.spotify.com/web-api/))
> Based on simple REST principles, our Web API endpoints return metadata in JSON format about artists, albums, and tracks directly from the Spotify catalogue.
> The API also provides access to user-related data such as playlists and music saved in a “Your Music” library, subject to user’s authorization.

**Spotify's *unofficial* Local API**
> Do you ever wanted to control your local Spotify Client with some sort of API? Now you can! This API gives you full control over your spotify client.
> You can get infos about the currently playing song, get its Album-Art, skip/pause and much more. It also features multiple Event-Interfaces.

Both combined can be used for any kind of application.

---

##Installing
* Via NuGet Package:
```cs
Install-Package SpotifyAPI-NET
//or
Install-Package SpotifyAPI-NET -pre
```
* Download the latest binaries on the [GitHub Release Page](https://github.com/JohnnyCrazy/SpotifyAPI-NET/releases) and add it to your Project
* Clone the Repo and build the project on your local machine.

---

##Projects
###[Spofy](https://github.com/eltoncezar/Spofy) by [@eltoncezar](https://github.com/eltoncezar)

> A Spotify mini player and notifier for Windows
