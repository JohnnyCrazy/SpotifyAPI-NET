---
id: example_blazor
title: Blazor ServerSide
---

import useBaseUrl from '@docusaurus/useBaseUrl';

## Description

Very similar to the [Blazor WASM Example](example_blazor_wasm.md), but runs code on the server side and pushes view updates to the client.

<img alt="ASP Blazor Example - Home" src={useBaseUrl('img/asp_blazor_example_home.png')} />

## Run it

Before running it, make sure you created an app in your [spotify dashboard](https://developer.spotify.com/dashboard/) and `https://localhost:5543` is a redirect uri of it.

```bash
# Assumes linux and current working directory is the cloned repository
cd SpotifyAPI.Web.Examples/Example.ASPBlazor
dotnet restore

SPOTIFY_CLIENT_ID=YourClientId SPOTIFY_CLIENT_SECRET=YourClientSecret dotnet run

# Visit https://localhost:5543
```
