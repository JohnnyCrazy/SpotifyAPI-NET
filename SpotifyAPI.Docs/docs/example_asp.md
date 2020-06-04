---
id: example_asp
title: ASP.NET
---

## Description

This example is based on ASP .NET Core. It uses `Authorization Code` under the hood with the help of [`AspNet.Security.OAuth.Spotify`](https://www.nuget.org/packages/AspNet.Security.OAuth.Spotify/). It stores the access token in the current user session (cookie-based) and allows to refresh tokens when they expire. Two pages are implemented:

* Home shows your current playlists via pagination
* Profile shows your current profile information

![ASP Example - Home](/img/asp_example_home.png)
![ASP Example - Profile](/img/asp_example_profile.png)

## Run it

Before running it, make sure you created an app in your [spotify dashboard](https://developer.spotify.com/dashboard/) and `https://localhost:5001` is a redirect uri of it.

```bash
# Assumes linux and current working directory is the cloned repository
cd SpotifyAPI.Web.Examples/Example.ASP
dotnet restore

SPOTIFY_CLIENT_ID=YourClientId SPOTIFY_CLIENT_SECRET=YourClientSecret dotnet run

# Visit https://localhost:5001
```
