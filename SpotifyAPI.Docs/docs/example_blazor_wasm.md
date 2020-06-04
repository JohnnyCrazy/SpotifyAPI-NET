---
id: example_blazor_wasm
title: Blazor WASM
---

## Description

This small cross-platform web app runs on `Blazor WebAssembly`, which was released on 19. May 2020. It allows to run C# code in any browser which supports WebAssembly. This allows to create .NET full-stack web projects without writing any JavaScript. Find more about [Blazor WebAssembly here](https://devblogs.microsoft.com/aspnet/blazor-webassembly-3-2-0-now-available/)

Since this library is compatible with `.NET Standard 2.1`, you can use all features of `SpotifyAPI.Web` in your blazor wasm app. The example logs the user in via `Implicit Grant` and does 2 user-related API requests from the browser. You can observe the requests from your browsers network tools.

![BlazorWASM Spotify Example](/img/blazorwasm_homepage.png)

![BlazorWASM Spotify Example - network tools](/img/blazorwasm_network_tools.png)

## Run it

Before running it, make sure you created an app in your [spotify dashboard](https://developer.spotify.com/dashboard/) and `https://localhost:5001` is a redirect uri of it.

```bash
# Assumes linux and current working directory is the cloned repository
cd SpotifyAPI.Web.Examples/Example.BlazorWASM
dotnet restore

echo "{ \"SPOTIFY_CLIENT_ID\": \"YourSpotifyClientId\" }" > wwwroot/appsettings.json
dotnet run

# Visit https://localhost:5001
```
