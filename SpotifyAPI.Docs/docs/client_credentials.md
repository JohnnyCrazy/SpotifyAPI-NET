---
id: client_credentials
title: Client Credentials
---

> The Client Credentials flow is used in server-to-server authentication.
> Only endpoints that do not access user information can be accessed.

By supplying your `SPOTIFY_CLIENT_ID` and `SPOTIFY_CLIENT_SECRET`, you get an access token.

## Request token once

To request an access token, build a `ClientCredentialsRequest` and send it via `OAuthClient`. This access token will expire after some time and you need to repeat the process.

```csharp
public static async Task Main()
{
  var config = SpotifyClientConfig.CreateDefault();

  var request = new ClientCredentialsRequest("CLIENT_ID", "CLIENT_SECRET");
  var response = await new OAuthClient(config).RequestToken(request);

  var spotify = new SpotifyClient(config.WithToken(response.AccessToken));
}
```

## Request Token On-Demand

You can also use `CredentialsAuthenticator`, which will make sure the spotify instance will always have an up-to-date access token by automatically refreshing the token on-demand.

```csharp
public static async Task Main()
{
  var config = SpotifyClientConfig
    .CreateDefault()
    .WithAuthenticator(new ClientCredentialsAuthenticator("CLIENT_ID", "CLIENT_SECRET"));

  var spotify = new SpotifyClient(config);
}
```

:::info
There is no thread safety guaranteed when using `CredentialsAuthenticator`.
:::

