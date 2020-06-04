---
id: token_swap
title: Token Swap
---

Token Swap provides an authenticatiow flow where client-side apps (like cli/desktop/mobile apps) are still able to use long-living tokens and the oppurtunity to refresh them without exposing your application's secret. This however requires a server-side part to work.

It is based on the [Authorization Code](authorization_code) flow and is also documented by spotify: [Token Swap and Refresh ](https://developer.spotify.com/documentation/ios/guides/token-swap-and-refresh/).

## Flow

The client uses the first part of the `Authorization Code` flow and redirects the user to spotify's login page. In this part, only the client id is required. Once the user logged in and confirmed the usage of your app, he will be redirect to a `http://localhost` server which grabs the `code` from the query parameters.

```csharp
var request = new LoginRequest("http://localhost", "ClientId", LoginRequest.ResponseType.Code)
{
  Scope = new List<string> { Scopes.UserReadEmail }
};
BrowserUtil.Open(uri);
```

Now, swapping out this `code` for an `access_token` would require the app's client secret. We don't have this on the client-side. Instead, we send a request to our server, which takes care of the code swap:

```csharp
public Task GetCallback(string code)
{
  var response = await new OAuthClient().RequestToken(
    new TokenSwapTokenRequest("https://your-swap-server.com/swap", code)
  );

  var spotify = new SpotifyClient(response.AccessToken);
  // Also important for later: response.RefreshToken
}
```

The server swapped out the `code` for an `access_token` and `refresh_token`. Once we realize the `access_token` expired, we can also ask the server to refresh it:

```csharp
// if response.IsExpired is true
var newResponse = await new OAuthClient().RequestToken(
  new TokenSwapTokenRequest("https://your-swap-server.com/refresh", response.RefreshToken)
);

var spotify = new SpotifyClient(newResponse.AccessToken);
```

## Server Implementation

The server needs to support two endpoints, `/swap` and `/refresh` (endpoints can be named differently of course)

### Swap

The client sends a body via `application/x-www-form-urlencoded` where the received `code` is included. In cURL:

```bash
curl -X POST "https://example.com/v1/swap"\
  -H "Content-Type: application/x-www-form-urlencoded"\
  --data "code=AQDy8...xMhKNA"
```

The server needs to respond with content-type `application/json` and the at least the following body:

```json
{
 "access_token" : "NgAagA...Um_SHo",
 "expires_in" : "3600",
 "refresh_token" : "NgCXRK...MzYjw"
}
```

### Refresh

The client sends a body via `application/x-www-form-urlencoded` where the received `refresh_token` is included. In cURL:

```bash
curl -X POST "https://example.com/v1/refresh"\
  -H "Content-Type: application/x-www-form-urlencoded"\
  --data "refresh_token=NgCXRK...MzYjw"
```

The server needs to respond with content-type `application/json` and the at least the following body:

```json
{
 "access_token" : "NgAagA...Um_SHo",
 "expires_in" : "3600"
}
```


## Example

An example server has been implemented in NodeJS with a .NET CLI client, located at [Example.TokenSwap](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.TokenSwap)
