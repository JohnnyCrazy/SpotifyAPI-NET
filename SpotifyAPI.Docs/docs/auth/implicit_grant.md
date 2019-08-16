---
sidebar: false
---

# ImplicitGrantAuth

This way is **recommended** and the only auth-process which does not need a server-side exchange of keys. With this approach, you directly get a Token object after the user authed your application.
You won't be able to refresh the token. If you want to use the internal Http server, please add "http://localhost:YOURPORT" to your application redirect URIs.

More info: [here](https://developer.spotify.com/documentation/general/guides/authorization-guide/#implicit-grant-flow)

```csharp
static async void Main(string[] args)
{
  ImplicitGrantAuth auth = new ImplicitGrantAuth(
    _clientId,
    "http://localhost:4002",
    "http://localhost:4002",
    Scope.UserReadPrivate
  );
  auth.AuthReceived += async (sender, payload) =>
  {
    auth.Stop(); // `sender` is also the auth instance
    SpotifyWebAPI api = new SpotifyWebAPI()
    {
      TokenType = payload.TokenType,
      AccessToken = payload.AccessToken
    };
    // Do requests with API client
  };
  auth.Start(); // Starts an internal HTTP Server
  auth.OpenBrowser();
}
```
