---
id: configuration
title: Configuration
---

To configure the Spotify client functionality, the `SpotifyClientConfig` class exists.

```csharp
var config = SpotifyClientConfig.CreateDefault("YourAccessToken");
var spotify = new SpotifyClient(config);

// is the same as

var spotify = new SpotifyClient("YourAccessToken");
```

We won't cover every possible configuration in this part, head over to the specific guides for that:

* ...

## HTTPClient Notes

One important part of the configuration is the used HTTPClient. By default, every time a `SpotifyClientConfig` is instantiated, a new `HTTPClient` is created in the background. For Web Applications that require a lot of different configs due to user based access tokens, it is **not** advised to create a new config from scratch with every HTTP call. Instead, a default (static) config should be used to create a new config with a new access token.

Consider the following HTTP Endpoint:

```csharp
public HttpResult Get()
{
  var config = SpotifyClientConfig.CreateDefault("YourAccessToken")
  var spotify = new SpotifyClient(config);
}
```

This creates a new `HTTPClient` every time a request is made, which can be quite bad for the performance. Instead, we should use a base config and use `WithToken`:

```csharp
// somewhere global/static
public static SpotifyClientConfig DefaultConfig = SpotifyClientConfig.CreateDefault();

public HttpResult Get()
{
  var config = DefaultConfig.WithToken("YourAccessToken");
  var spotify = new SpotifyClient(config);
}
```

This way, a single `HTTPClient` will be used. For a real example, checkout the [ASP.NET Example](example_asp.md).
