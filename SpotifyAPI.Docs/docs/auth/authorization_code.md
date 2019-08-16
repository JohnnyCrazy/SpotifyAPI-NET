---
sidebar: false
---

# AutorizationCodeAuth

This way is **not recommended** for client-side apps and requires server-side code to run securely.
With this approach, you first get a code which you need to trade against the access-token.
In this exchange you need to provide your Client-Secret and because of that it's not recommended.
A good thing about this method: You can always refresh your token, without having the user to auth it again.

More info: [here](https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow)

```csharp
static async void Main(string[] args)
{
    AuthorizationCodeAuth auth = new AuthorizationCodeAuth(
      _clientId,
      _secretId,
      "http://localhost:4002",
      "http://localhost:4002",
      Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative
    );

    auth.AuthReceived += async (sender, payload) =>
    {
        auth.Stop();
        Token token = await auth.ExchangeCode(payload.Code);
        SpotifyWebAPI api = new SpotifyWebAPI()
        {
          TokenType = token.TokenType,
          AccessToken = token.AccessToken
        };
        // Do requests with API client
    };
    auth.Start(); // Starts an internal HTTP Server
    auth.OpenBrowser();
}
```
