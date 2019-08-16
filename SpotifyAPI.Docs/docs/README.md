# SpotifyAPI-NET Docs

## About

This project, written in C#/.NET, provides 2 libraries for an easier usage of the Spotify Web API

**Spotify's Web API** ([link](https://developer.spotify.com/web-api/))
> Based on simple REST principles, our Web API endpoints return metadata in JSON format about artists, albums, and tracks directly from the Spotify catalogue.
> The API also provides access to user-related data such as playlists and music saved in a “Your Music” library, subject to user’s authorization.

**SpotifyAPI.Web**
> A wrapper around Spotify's Web API, providing sync and async methods to query all possible endpoints. Results are returned as typed class instances, allowing property-based access.

**SpotifyAPI.Web.Auth**
> A library providing C# implementations of the 3 supported Authentication modes, including `ImplicitGrantAuth`, `AuthorizationCodeAuth` and `CredentialsAuth`

---

## Installing

* Via NuGet Package:
```bash
Install-Package SpotifyAPI.Web
Install-Package SpotifyAPI.Web.Auth
```
* Download the latest binaries on the [GitHub Release Page](https://github.com/JohnnyCrazy/SpotifyAPI-NET/releases) and add it to your Project
* Clone the Repo and build the project yourself.

---

## Getting Started

* [SpotifyAPI.Web](/web/getting_started/)
* [SpotifyAPI.Web.Auth](/auth/getting_started/)


## Projects

### [audio-band](https://github.com/dsafa/audio-band) by [@dsafa](https://github.com/dsafa)

> Display and control songs from the Windows taskbar

### [rocksmith-custom-song-toolkit](https://github.com/catara/rocksmith-custom-song-toolkit) by [@catara](https://github.com/catara)

> MASS Manipulation of Rocksmith DLC Library

### [Spofy](https://github.com/eltoncezar/Spofy) by [@eltoncezar](https://github.com/eltoncezar)

> A Spotify mini player and notifier for Windows

### [Toastify](https://github.com/aleab/toastify) by [@aleab](https://github.com/aleab)

> Toastify adds global hotkeys and toast notifications to Spotify
>
> *Forked from [nachmore/toastify](https://github.com/nachmore/toastify)*

### [Spotify Oculus](https://github.com/CaptainMorgs/spotify-oculus-release) by [@CaptainMorgs](https://github.com/CaptainMorgs)

> Unity project for interacting with Spotify in virtual reality for the Oculus Rift.
