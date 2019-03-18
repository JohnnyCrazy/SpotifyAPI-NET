#Auth-Methods

Before you can use the Web API full functional, you need the user to authenticate your Application.
If you want to know more, you can read to the whole auth-process [here](https://developer.spotify.com/web-api/authorization-guide/).

Before you start, install `SpotifyAPI.Web.Auth` and create an application at Spotify: [Your Applications](https://developer.spotify.com/my-applications/#!/applications)

***

After you created your Application, you will have following important values:
>**Client_Id**: This is your client_id, you don't have to hide it
>**Client_Secret**: Never use this in one of your client-side apps!! Keep it secret!
>**Redirect URIs**: Add "http://localhost", if you want full support for this API

Now you can start with the user-authentication, Spotify provides 3 ways (4 if you consider different implementations):

* [ImplicitGrantAuth](/SpotifyWebAPI/auth#implicitgrantauth)

* [TokenSwapAuth](/SpotifyWebAPI/auth#tokenswapauth) (**Recommended**, server-side code mandatory, most secure method. The necessary code is shown here so you do not have to code it yourself.)

* [AutorizationCodeAuth](/SpotifyWebAPI/auth#autorizationcodeauth) (Not recommended, server-side code needed, else it's unsecure)

* [ClientCredentialsAuth](/SpotifyWebAPI/auth#clientcredentialsauth) (Not recommended, server-side code needed, else it's unsecure)

## Notes

Generally, if you're developing a 100% client-side application, no auth mechanism is totally secure. `AutorizationCodeAuth` and `ClientCredentialsAuth` require your clients to know the `client_secret`, which should be kept secret. For `ImplicitGrantAuth` to work, `http://localhost` needs to be added to the redirect uris of your spotify application. Since `localhost` is not a controlled domain by you, everybody is able to generate API-Keys. However, it is still the best option of all 3.

Overview:
![Overview](http://i.imgur.com/uf3ahTl.png)

After implementing one of the provided auth-methods, you can start doing requests with the token you get from one of the auth-methods.

## ImplicitGrantAuth

This way is **recommended** and the only auth-process which does not need a server-side exchange of keys. With this approach, you directly get a Token object after the user authed your application.
You won't be able to refresh the token. If you want to use the internal Http server, please add "http://localhost" to your application redirects.

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

## TokenSwapAuth

This way uses server-side code or at least access to an exchange server, otherwise, compared to other
methods, it is impossible to use.

With this approach, you provide the URI/URL to your desired exchange server to perform all necessary
requests to Spotify, as well as requests that return back to the "server URI".

The exchange server **must** be able to:

* Return the authorization code from Spotify API authenticate page via GET request to the "server URI".
* Request the token response object via POST to the Spotify API token page.
* Request a refreshed token response object via POST to the Spotify API token page.

**The good news is that you do not need to code it yourself.**

The advantages of this method are that the client ID and redirect URI are very well hidden and almost unexposed, but more importantly, your client secret is **never** exposed and is completely hidden compared to other methods (excluding [ImplicitGrantAuth](/SpotifyWebAPI/auth#implicitgrantauth)
as it does not deal with a client secret). This means
your Spotify app **cannot** be spoofed by a malicious third party.

### Using TokenSwapWebAPIFactory
The TokenSwapWebAPIFactory will create and configure a SpotifyWebAPI object for you.

It does this through the method GetWebApiAsync **asynchronously**, which means it will not halt execution of your program while obtaining it for you. If you would like to halt execution, which is **synchronous**, use `GetWebApiAsync().Result` without using **await**.

```c#
TokenSwapWebAPIFactory webApiFactory;
SpotifyWebAPI spotify;

// You should store a reference to WebAPIFactory if you are using AutoRefresh or want to manually refresh it later on. New WebAPIFactory objects cannot refresh SpotifyWebAPI object that they did not give to you.
webApiFactory = new TokenSwapWebAPIFactory("INSERT LINK TO YOUR index.php HERE")
{
    Scope = Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate,
    AutoRefresh = true
};
// You may want to react to being able to use the Spotify service.
// webApiFactory.OnAuthSuccess += (sender, e) => authorized = true;
// You may want to react to your user's access expiring.
// webApiFactory.OnAccessTokenExpired += (sender, e) => authorized = false;

try
{
    spotify = await webApiFactory.GetWebApiAsync();
    // Synchronous way:
    // spotify = webApiFactory.GetWebApiAsync().Result;
}
catch (Exception ex)
{
    // Example way to handle error reporting gracefully with your SpotifyWebAPI wrapper
    // UpdateStatus($"Spotify failed to load: {ex.Message}");
}
```

### Using TokenSwapAuth
Since the TokenSwapWebAPIFactory not only simplifies the whole process but offers additional functionality too
(such as AutoRefresh and AuthSuccess AuthFailure events), use of this way is very verbose and is only
recommended if you are having issues with TokenSwapWebAPIFactory or need access to the tokens.

```c#
TokenSwapAuth auth = new TokenSwapAuth(
    exchangeServerUri: "INSERT LINK TO YOUR index.php HERE",
    serverUri: "http://localhost:4002",
    scope: Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate
);
auth.AuthReceived += async (sender, response) =>
{
    lastToken = await auth.ExchangeCodeAsync(response.Code);

    spotify = new SpotifyWebAPI()
    {
        TokenType = lastToken.TokenType,
        AccessToken = lastToken.AccessToken
    };

    authenticated = true;
    auth.Stop();
};
auth.OnAccessTokenExpired += async (sender, e) => spotify.AccessToken = (await auth.RefreshAuthAsync(lastToken.RefreshToken)).AccessToken;
auth.Start();
auth.OpenBrowser();
```

### Token Swap Endpoint
To keep your client secret completely secure and your client ID and redirect URI as secure as possible, use of a web server (such as a php website) is required.

To use this method, an external HTTP Server (that you may need to create) needs to be able to supply the following HTTP Endpoints to your application:

`/swap` - Swaps out an `authorization_code` with an `access_token` and `refresh_token` - The following parameters are required in the JSON POST Body:
- `grant_type` (set to `"authorization_code"`)
- `code` (the `authorization_code`)
- `redirect_uri`
- - **Important** The page that the redirect URI links to must return the authorization code json to your `serverUri` (default is 'http://localhost:4002') but to the folder 'auth', like this: 'http://localhost:4002/auth'.

`/refresh` - Refreshes an `access_token` - The following parameters are required in the JSON POST Body:
- `grant_type` (set to `"refresh_token"`)
- `refresh_token`

The following open-source token swap endpoint code can be used for your website:
- [rollersteaam/spotify-token-swap-php](https://github.com/rollersteaam/spotify-token-swap-php)
- [simontaen/SpotifyTokenSwap](https://github.com/simontaen/SpotifyTokenSwap)

#### Remarks
It should be noted that GitHub Pages does not support hosting php scripts. Hosting php scripts through it will cause the php to render as plain HTML, potentially compromising your client secret while doing absolutely nothing.

Be sure you have whitelisted your redirect uri in the Spotify Developer Dashboard otherwise the authorization will always fail.

If you did not use the WebAPIFactory or you provided a `serverUri` different from its default, you must make sure your redirect uri's script at your endpoint will properly redirect to your `serverUri` (such as changing the areas which refer to `localhost:4002` if you had changed `serverUri` from its default), otherwise it will never reach your new `serverUri`.

## AutorizationCodeAuth

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

## ClientCredentialsAuth

With this approach, you make a POST Request with a base64 encoded string (consists of ClientId + ClientSecret). You will directly get the token (Without a local HTTP Server), but it will expire and can't be refreshed.
If you want to use it securely, you would need to do it all server-side.
**NOTE:** You will only be able to query non-user-related information e.g search for a Track.

More info: [here](https://developer.spotify.com/documentation/general/guides/authorization-guide/#client-credentials-flow)

```c#
CredentialsAuth auth = new CredentialsAuth(_clientId, _secretId);
Token token = await auth.GetToken();
SpotifyWebAPI api = new SpotifyWebAPI() {TokenType = token.TokenType, AccessToken = token.AccessToken};
```
