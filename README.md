
<h1 align="center">
  <p align="center">SpotifyAPI-NET</p>
  <a href="https://johnnycrazy.github.io/SpotifyAPI-NET/">
    <img
      height="128"
      width="128"
      src="SpotifyAPI.Docs/static/img/logo.svg"
      alt="SpotifyAPI-NET">
  </a>
</h1>

![Build SpotifyAPI-NET](https://github.com/JohnnyCrazy/SpotifyAPI-NET/workflows/Build/Test/Release%20SpotifyAPI-NET/badge.svg)
[![License](https://img.shields.io/github/license/JohnnyCrazy/SpotifyAPI-NET?style=flat-square)](./LICENSE)
[![SpotifyAPI.Web NuGET](https://img.shields.io/nuget/vpre/SpotifyAPI.Web?label=SpotifyAPI.Web&style=flat-square)](https://www.nuget.org/packages/SpotifyAPI.Web/)
[![SpotifyAPI.Web.Auth NuGET](https://img.shields.io/nuget/vpre/SpotifyAPI.Web.Auth?label=SpotifyAPI.Web.Auth&style=flat-square)](https://www.nuget.org/packages/SpotifyAPI.Web.Auth/)

This open source library for the Spotify Web API provides an easy to use interface for .NET based languages, like C# and VisualBasic .NET. By using it you can query general spotify catalog information (tracks, albums and playlists), manage user-related content ("My Library", create and edit playlists) and control the users music players (play, stop, transfer playback, play specific track).

### Features


* ✅ Typed responses and requests to over 74 endpoints. Complete and always up to date.
* ✅ Supports `.NET Standard 2.X`, which includes all major platforms, including mobile:
  * `.NET Framework`
  * `UWP`
  * `.NET Core`
  * `Xamarin.Forms`
* ✅ Included `HTTPClient`, but feel free to bring your own!
* ✅ Logging supported
* ✅ Retry Handlers supported
* ✅ Proxy support
* ✅ Pagination support
* ✅ All OAuth2 Authentications supported for use in `ASP .NET` **and** `CLI` apps
* ✅ Modular structure, for easy unit testing

### Example

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

More examples can be found on [the website](https://johnnycrazy.github.io/SpotifyAPI-NET/docs/next/introduction) and in the `SpotifyAPI.Web.Examples` directory.


### Docs and Usage

More Information, Installation-Instructions, Examples, Guides can be found at [johnnycrazy.github.io/SpotifyAPI-NET/](http://johnnycrazy.github.io/SpotifyAPI-NET/)

### Installation

Installation Instructions can be found in the [Getting Started Guide](https://johnnycrazy.github.io/SpotifyAPI-NET/docs/next/getting_started)

### Donations

If you want to support this project or my work in general, you can donate a buck or two via the link below. However, this will be always optional!

[![Donate Link](./donate.svg)](https://paypal.me/JohnnyCrazy)
