---
id: example_cli_persistent_config
title: CLI - Persistent Config
---

## Description

An example to show how an obtained access and refresh token can be stored persistently and re-used across application restarts. This results in fewer requests to spotifys authentication endpoints and a faster experience for the user. The example uses [PKCE](pkce.md) in combination with the `PKCEAuthenticator`, which automatically refreshes expired tokens.

The access and refresh token is saved in a `credentials.json` file of the current working directory.

## Run it

Before running it, make sure you created an app in your [spotify dashboard](https://developer.spotify.com/dashboard/) and `https://localhost:5543` is a redirect uri of it.

```bash
# Assumes linux and current working directory is the cloned repository
cd SpotifyAPI.Web.Examples/Example.CLI.PersistentConfig
dotnet restore

SPOTIFY_CLIENT_ID=YourClientId dotnet run
# A browser window should appear
# Restarting the process should NOT open a new authentication window
# Instead, the local `crendentials.json` file is used
SPOTIFY_CLIENT_ID=YourClientId dotnet run
```
