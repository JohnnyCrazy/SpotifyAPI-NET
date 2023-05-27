---
id: example_cli_custom_html
title: CLI - Custom HTML
---

import useBaseUrl from '@docusaurus/useBaseUrl';

## Description

An example to show how you can display your own HTML resource after the user went through the authentication process of either [Implicit Grant](implicit_grant.md), [Authorization Code](authorization_code.md) or [PKCE](pkce.md).

<img alt="CLI Custom HTML Example" src={useBaseUrl('img/cli_custom_html.jpeg')} />

## Run it

Before running it, make sure you created an app in your [spotify dashboard](https://developer.spotify.com/dashboard/) and `https://localhost:5543` is a redirect uri of it.

```bash
# Assumes linux and current working directory is the cloned repository
cd SpotifyAPI.Web.Examples/Example.CLI.CustomHTML
dotnet restore

SPOTIFY_CLIENT_ID=YourClientId SPOTIFY_CLIENT_SECRET=YourClientSecret dotnet run
# A browser window should appear
```
