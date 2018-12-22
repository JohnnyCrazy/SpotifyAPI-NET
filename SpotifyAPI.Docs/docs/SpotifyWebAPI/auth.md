#Auth-Methods

Before you can use the Web API full functional, you need the user to authenticate your Application.
If you want to know more, you can read to the whole auth-process [here](https://developer.spotify.com/web-api/authorization-guide/).

Before you start, install `SpotifyAPI.Web.Auth` and create an application at Spotify: [Your Applications](https://developer.spotify.com/my-applications/#!/applications)

***

After you created your Application, you will have following important values:
>**Client_Id**: This is your client_id, you don't have to hide it
>**Client_Secret**: Never use this in one of your client-side apps!! Keep it secret!
>**Redirect URIs**: Add "http://localhost", if you want full support for this API

Now you can start with the User-authentication, Spotify provides 3 ways:

* [ImplicitGrantAuth](/SpotifyWebAPI/auth#implicitgrantauth)

* [AutorizationCodeAuth](/SpotifyWebAPI/auth#autorizationcodeauth)

* [ClientCredentialsAuth](/SpotifyWebAPI/auth#clientcredentialsauth)

## Notes

Generally, if you're developing a 100% client-side application, no auth mechanism is totally secure. `AutorizationCodeAuth` and `ClientCredentialsAuth` require your clients to know the `client_secret`, which should be kept secret. For `ImplicitGrantAuth` to work, `http://localhost` needs to be added to the redirect uris of your spotify application. Since `localhost` is not a controlled domain by you, everybody is able to generate API-Keys. However, it is still the best option of all 3.

Overview:
![Overview](http://i.imgur.com/uf3ahTl.png)

After implementing one of the provided auth-methods, you can start doing requests with the token you get from one of the auth-methods.

##ImplicitGrantAuth

With this approach, you directly get a Token object after the user authed your application.
You won't be able to refresh the token. If you want to use the internal Http server, make sure the redirect URI is in your spotify application redirects.

More info: [here](https://developer.spotify.com/documentation/general/guides/authorization-guide/#implicit-grant-flow)

```c#
static async void Main(string[] args)
{
    ImplicitGrantAuth auth =
        new ImplicitGrantAuth(_clientId, "http://localhost:4002", "http://localhost:4002", Scope.UserReadPrivate);
    auth.AuthReceived += async (sender, payload) =>
    {
        auth.Stop(); // `sender` is also the auth instance
        SpotifyWebAPI api = new SpotifyWebAPI() {TokenType = payload.TokenType, AccessToken = payload.AccessToken};
        // Do requests with API client
    };
    auth.Start(); // Starts an internal HTTP Server
    auth.OpenBrowser();
}
```

##AutorizationCodeAuth

This way is **not recommended** and requires server-side code to run securely.
With this approach, you first get a code which you need to trade against the access-token.
In this exchange you need to provide your Client-Secret and because of that it's not recommended.
A good thing about this method: You can always refresh your token, without having the user to auth it again

More info: [here](https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow)

```c#
static async void Main(string[] args)
{
    AuthorizationCodeAuth auth =
        new AuthorizationCodeAuth(_clientId, _secretId, "http://localhost:4002", "http://localhost:4002",
            Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative);
    auth.AuthReceived += async (sender, payload) =>
    {
        auth.Stop();
        Token token = await auth.ExchangeCode(payload.Code);
        SpotifyWebAPI api = new SpotifyWebAPI() {TokenType = token.TokenType, AccessToken = token.AccessToken};
        // Do requests with API client
    };
    auth.Start(); // Starts an internal HTTP Server
    auth.OpenBrowser();
}
```

##ClientCredentialsAuth

With this approach, you make a POST Request with a base64 encoded string (consists of ClientId + ClientSecret). You will directly get the token (Without a local HTTP Server), but it will expire and can't be refreshed.
If you want to use it securely, you would need to do it all server-side.
**NOTE:** You will only be able to query non-user-related information e.g search for a Track.

More info: [here](https://developer.spotify.com/documentation/general/guides/authorization-guide/#client-credentials-flow)

```c#
CredentialsAuth auth = new CredentialsAuth(_clientId, _secretId);
Token token = await auth.GetToken();
SpotifyWebAPI api = new SpotifyWebAPI() {TokenType = token.TokenType, AccessToken = token.AccessToken};
```
