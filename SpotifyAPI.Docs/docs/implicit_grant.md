---
id: implicit_grant
title: Implicit Grant
---

import useBaseUrl from '@docusaurus/useBaseUrl';

> Implicit grant flow is for clients that are implemented entirely using JavaScript and running in the resource owner’s browser. You do not need any server-side code to use it. Rate limits for requests are improved but there is no refresh token provided. This flow is described in RFC-6749.

This flow is useful for getting a user access token for a short timespan

## Existing Web-Server

If you are already in control of a Web-Server (like `ASP.NET`), you can start the flow by generating a login uri

```csharp
// Make sure "http://localhost:5000" is in your applications redirect URIs!
var loginRequest = new LoginRequest(
  new Uri("http://localhost:5000"),
  "ClientId",
  LoginRequest.ResponseType.Token
)
{
  Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
};
var uri = loginRequest.ToUri();
// Redirect user to uri via your favorite web-server
```

When the user is redirected to the generated uri, he will have to login with his spotify account and confirm, that your application wants to access his user data. Once confirmed, he will be redirect to `http://localhost:5000` and the fragment identifier (`#` part of URI) will contain an access token.

:::warning
Note, this parameter is not sent to the server! You need JavaScript to access it.
:::

## Using custom Protocols

This flow can also be used with custom protocols instead of `http`/`https`. This is especially interesting for `UWP` apps, since your able to register custom protocol handlers quite easily.

<img alt="protocol handlers" src={useBaseUrl('img/auth_protocol_handlers.png')} />

The process is very similar, you generate a uri and open it for the user

```csharp
// Make sure "spotifyapi.web.oauth://token" is in your applications redirect URIs!
var loginRequest = new LoginRequest(
  new Uri("spotifyapi.web.oauth://token"),
  "ClientId",
  LoginRequest.ResponseType.Token
)
{
  Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
};
var uri = loginRequest.ToUri();

// This call requires Spotify.Web.Auth
BrowserUtil.Open(uri);
```

After the user logged in and consented your app, your `UWP` app will receive a callback:

```csharp
protected override void OnActivated(IActivatedEventArgs args)
{
  if (args.Kind == ActivationKind.Protocol)
  {
    ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;
    var publisher = Mvx.IoCProvider.Resolve<ITokenPublisherService>();

    // This Uri contains your access token in the Fragment part
    Console.WriteLine(eventArgs.Uri);
  }
}
```

For a real example, have a look at the [Example.UWP](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.UWP), [Example.ASP](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.ASP) or [Example.ASPBlazor](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.ASPBlazor)

# Using Spotify.Web.Auth

For cross-platform CLI and desktop apps (non `UWP` apps), custom protocol handlers are sometimes not an option. The fallback here is a small cross-platform embedded web server running on `http://localhost:5000` serving javascript. The javscript will parse the fragment part of the URI and sends a request to the web server in the background. The web server then notifies your appliciation via event.

```csharp
private static EmbedIOAuthServer _server;

public static async Task Main()
{
  // Make sure "http://localhost:5000/callback" is in your spotify application as redirect uri!
  _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
  await _server.Start();

  _server.ImplictGrantReceived += OnImplicitGrantReceived;

  var request = new LoginRequest(_server.BaseUri, "ClientId", LoginRequest.ResponseType.Token)
  {
    Scope = new List<string> { Scopes.UserReadEmail }
  };
  BrowserUtil.Open(request.ToUri());
}

private static async Task OnImplicitGrantReceived(object sender, ImplictGrantResponse response)
{
  await _server.Stop();
  var spotify = new SpotifyClient(response.AccessToken);
  // do calls with spotify
}
```

For real examples, have a look at [Example.CLI.PersistentConfig](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.CLI.PersistentConfig) and [Example.CLI.CustomHTML](https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.CLI.CustomHTML)
