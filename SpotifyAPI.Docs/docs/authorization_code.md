---
id: authorization_code
title: Authorization Code
---

> This flow is suitable for long-running applications in which the user grants permission only once. It provides an access token that can be refreshed. Since the token exchange involves sending your secret key, perform this on a secure location, like a backend service, and not from a client such as a browser or from a mobile app.

## Existing Web-Server

If you are already in control of a Web-Server (like `ASP.NET`), you can start the flow by generating a login uri:

```csharp
// Make sure "http://localhost:5000" is in your applications redirect URIs!
var loginRequest = new LoginRequest(
  new Uri("http://localhost:5000"),
  "ClientId",
  LoginRequest.ResponseType.Code
)
{
  Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
};
var uri = loginRequest.ToUri();
// Redirect user to uri via your favorite web-server
```

When the user is redirected to the generated uri, they will have to login with their Spotify account and confirm that your application wants to access their user data. Once confirmed, they will be redirected to `http://localhost:5000` and a `code` parameter is attached to the query. This `code` has to be exchanged for an `access_token` and `refresh_token`:

```csharp
// This method should be called from your web-server when the user visits "http://localhost:5000"
public Task GetCallback(string code)
{
  var response = await new OAuthClient().RequestToken(
    new AuthorizationCodeTokenRequest("ClientId", "ClientSecret", code, "http://localhost:5000")
  );

  var spotify = new SpotifyClient(response.AccessToken);
  // Also important for later: response.RefreshToken
}
```

If the token expires at some point (check via `response.IsExpired`), you can refresh it:

```csharp
var newResponse = await new OAuthClient().RequestToken(
  new AuthorizationCodeRefreshRequest("ClientId", "ClientSecret", response.RefreshToken)
);

var spotify = new SpotifyClient(newResponse.AccessToken);
```

You can also let the `AuthorizationCodeAuthenticator` take care of the refresh part:

```csharp
var response = await new OAuthClient().RequestToken(
  new AuthorizationCodeTokenRequest("ClientId", "ClientSecret", code, "http://localhost:5000")
);
var config = SpotifyClientConfig
  .CreateDefault()
  .WithAuthenticator(new AuthorizationCodeAuthenticator("ClientId", "ClientSecret", response));

var spotify = new SpotifyClient(config);
```

For a real example, have a look at [Example.ASP](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.ASP). This also uses the great package `AspNet.Security.OAuth.Spotify` which takes care of the OAuth flow inside of `ASP.NET`.

## Using Spotify.Web.Auth

For cross-platform CLI and desktop apps (non `UWP` apps), `Spotify.Web.Auth` can be used to supply a small embedded Web Server for the code retrieval.

:::warning
Your client secret will be exposed when embedded in a desktop/CLI app. This can be abused and is not prefered. If possible, let the user create an application in the Spotify dashboard or let a server handle the Spotify communication.
:::

```csharp
private static EmbedIOAuthServer _server;

public static async Task Main()
{
  // Make sure "http://localhost:5000/callback" is in your spotify application as redirect uri!
  _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
  await _server.Start();

  _server.AuthorizationCodeReceived += OnAuthorizationCodeReceived;

  var request = new LoginRequest(_server.BaseUri, "ClientId", LoginRequest.ResponseType.Code)
  {
    Scope = new List<string> { Scopes.UserReadEmail }
  };
  BrowserUtil.Open(uri);
}

private static async Task OnAuthorizationCodeReceived(object sender, AuthorizationCodeResponse response)
{
  await _server.Stop();

  var config = SpotifyClientConfig.CreateDefault();
  var tokenResponse = await new OAuthClient(config).RequestToken(
    new AuthorizationCodeTokenRequest(
      "ClientId", "ClientSecret", response.Code, "http://localhost:5000/callback"
    )
  );

  var spotify = new SpotifyClient(tokenResponse.AccessToken);
  // do calls with Spotify and save token?
}
```

For real examples, have a look at [Example.CLI.PersistentConfig](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.CLI.PersistentConfig) and [Example.CLI.CustomHTML](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.CLI.CustomHTML)
