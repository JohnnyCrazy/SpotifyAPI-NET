# TokenSwapAuth

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

## Using TokenSwapWebAPIFactory
The TokenSwapWebAPIFactory will create and configure a SpotifyWebAPI object for you.

It does this through the method GetWebApiAsync **asynchronously**, which means it will not halt execution of your program while obtaining it for you. If you would like to halt execution, which is **synchronous**, use `GetWebApiAsync().Result` without using **await**.

```csharp
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

## Using TokenSwapAuth
Since the TokenSwapWebAPIFactory not only simplifies the whole process but offers additional functionality too
(such as AutoRefresh and AuthSuccess AuthFailure events), use of this way is very verbose and is only
recommended if you are having issues with TokenSwapWebAPIFactory or need access to the tokens.

```csharp
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

## Token Swap Endpoint
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

## Remarks
It should be noted that GitHub Pages does not support hosting php scripts. Hosting php scripts through it will cause the php to render as plain HTML, potentially compromising your client secret while doing absolutely nothing.

Be sure you have whitelisted your redirect uri in the Spotify Developer Dashboard otherwise the authorization will always fail.

If you did not use the WebAPIFactory or you provided a `serverUri` different from its default, you must make sure your redirect uri's script at your endpoint will properly redirect to your `serverUri` (such as changing the areas which refer to `localhost:4002` if you had changed `serverUri` from its default), otherwise it will never reach your new `serverUri`.
