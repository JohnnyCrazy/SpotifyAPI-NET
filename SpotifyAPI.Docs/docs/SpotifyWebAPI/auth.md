#Auth-Methods  

Before you can use the Web API full functional, you need the user to authenticate your Application.  
If you want to know more, you can read to the whole auth-process [here](https://developer.spotify.com/web-api/authorization-guide/).

Before you start, you need to create a Application at Spotify: [Your Applications](https://developer.spotify.com/my-applications/#!/applications)

***

After you created your Application, you will have following important values:  
>**Client_Id** This is your client_id, you don't have to hide it  
>**Client_Secret** Never use this in one of your client-side apps!! Keep it secret!  
>**Redirect URIs** Add "http://localhost", if you want full support for this API  

Now you can start with the user-authentication, Spotify provides 3 ways (4 if you consider different implementations):

* [ImplicitGrantAuth](/SpotifyWebAPI/auth#implicitgrantauth) (**Recommended**, no server-side code needed)  

* [TokenSwapAuth](/SpotifyWebAPI/auth#tokenswapauth) (**Recommended**, server-side code mandatory, most secure method. The necessary code is shown here so you do not have to code it yourself.)

* [AutorizationCodeAuth](/SpotifyWebAPI/auth#autorizationcodeauth) (Not recommended, server-side code needed, else it's unsecure)

* [ClientCredentialsAuth](/SpotifyWebAPI/auth#clientcredentialsauth) (Not recommended, server-side code needed, else it's unsecure)

**Note:** I would recommend a little PHP Script, which will exchange the Keys using AutorizationCodeAuth.
When using ImplicitGrantAuth, another user could abuse the "localhost" RedirectUri by creating a "fake"-app which uses your ClientId.

Overview:
![Overview](http://i.imgur.com/uf3ahTl.png)

After implementing one of the provided auth-methods, you can start doing requests with the token you get from one of the auth-methods

## ImplicitGrantAuth

This way is **recommended** and the only auth-process which does not need a server-side exchange of keys. With this approach, you directly get a Token object after the user authed your application.
You won't be able to refresh the token. If you want to use the internal Http server, please add "http://localhost" to your application redirects.

More info: [here](https://developer.spotify.com/web-api/authorization-guide/#implicit_grant_flow)

For this kind of authentication, there is also a `WebAPIFactory`, it's easier to use and uses an async method:
```
static async void Main(string[] args)
{
  WebAPIFactory webApiFactory = new WebAPIFactory(
       "http://localhost",
       8000,
       "XXXXXXXXXXXXXXXX",
       Scope.UserReadPrivate,
       TimeSpan.FromSeconds(20)
  );

  try
  {
    //This will open the user's browser and returns once
    //the user is authorized.
    _spotify = await webApiFactory.GetWebApi();
  }
  catch (Exception ex)
  {
     MessageBox.Show(ex.Message);
  }

  if (_spotify == null)
     return;
}
```

The old way:
```
static ImplicitGrantAuth auth;
static void Main(string[] args)
{
    //Create the auth object
    auth = new ImplicitGrantAuth()
    {
        //Your client Id
        ClientId = "XXXXXXXXXXXXXXXX",
        //Set this to localhost if you want to use the built-in HTTP Server
        RedirectUri = "http://localhost",
        //How many permissions we need?
        Scope = Scope.UserReadPrivate,
    };
    //Start the internal http server
    auth.StartHttpServer();
    //When we got our response
    auth.OnResponseReceivedEvent += auth_OnResponseReceivedEvent;
    //Start
    auth.DoAuth();
}

static void auth_OnResponseReceivedEvent(Token token, string state, string error)
{
    var spotify = new SpotifyWebApiClass()
    {
        TokenType = token.TokenType,
        AccessToken = token.AccessToken
    };
    //We can now make calls with the token object
    
    //stop the http server
    auth.StopHttpServer();
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
    Scope = Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead | Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistReadCollaborative | Scope.UserReadRecentlyPlayed | Scope.UserReadPlaybackState | Scope.UserModifyPlaybackState | Scope.PlaylistModifyPublic,
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
    scope: Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead | Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistReadCollaborative | Scope.UserReadRecentlyPlayed | Scope.UserReadPlaybackState | Scope.UserModifyPlaybackState | Scope.PlaylistModifyPublic
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

To use this method, an external HTTP Server that you will need to create needs to be able to supply the following HTTP Endpoints to your application:

`/swap` - Swaps out an `authorization_code` with an `access_token` and `refresh_token` - The following parameters are required in the JSON POST Body:
- `grant_type` (set to `"authorization_code"`)
- `code` (the `authorization_code`)
- `redirect_uri`

`/refresh` - Refreshes an `access_token` - The following parameters are required in the JSON POST Body:
- `grant_type` (set to `"refresh_token"`)
- `refresh_token`

The following open-source token swap endpoint code can be used for your website:
- [rollersteaam/spotify-token-swap-php](https://github.com/rollersteaam/spotify-token-swap-php)
- [simontaen/SpotifyTokenSwap]()

#### Remarks
It should be noted that GitHub Pages does not support hosting php scripts. Hosting php scripts through it will cause the php to render as plain HTML, potentially compromising your client secret while doing absolutely nothing.

Be sure you have whitelisted your redirect uri in the Spotify Developer Dashboard otherwise the authorization will always fail.

If you did not use the WebAPIFactory or you provided a `serverUri` different from its default, you must make sure your redirect uri's script at your endpoint will properly redirect to your `serverUri` (such as changing the areas which refer to `localhost:4002` if you had changed `serverUri` from its default), otherwise it will never reach your new `serverUri`.

## AutorizationCodeAuth

This way is **not recommended** and requires server-side code to run securely.  
With this approach, you first get a code which you need to trade against the access-token.  
In this exchange you need to provide your Client-Secret and because of that it's not recommended.  
(But you can e.g exchange to codes via a PHP Script)  
A good thing about this method: You can always refresh your token, without having the user to auth it again

More info: [here](https://developer.spotify.com/web-api/authorization-guide/#authorization_code_flow)

```
static AutorizationCodeAuth auth;
static void Main(string[] args)
{
    //Create the auth object
    auth = new AutorizationCodeAuth()
    {
        //Your client Id
        ClientId = "XXXXXXXXXXXXXXX",
        //Set this to localhost if you want to use the built-in HTTP Server
        RedirectUri = "http://localhost",
        //How many permissions we need?
        Scope = Scope.UserReadPrivate,
    };
    //This will be called, if the user cancled/accept the auth-request
    auth.OnResponseReceivedEvent += auth_OnResponseReceivedEvent;
    //a local HTTP Server will be started (Needed for the response)
    auth.StartHttpServer();
    //This will open the spotify auth-page. The user can decline/accept the request
    auth.DoAuth();

    Thread.Sleep(60000);
    auth.StopHttpServer();
    Console.WriteLine("Too long, didnt respond, exiting now...");
}

private static void auth_OnResponseReceivedEvent(AutorizationCodeAuthResponse response)
{

    //NEVER DO THIS! You would need to provide the ClientSecret.
    //You would need to do it e.g via a PHP-Script.
    Token token = auth.ExchangeAuthCode(response.Code, "XXXXXXXXXXX");

    var spotify = new SpotifyWebApiClass()
    {
        TokenType = token.TokenType,
        AccessToken = token.AccessToken
    };

    //With the token object, you can now make API calls
    
    //Stop the HTTP Server, done.
    auth.StopHttpServer();
}
```

## ClientCredentialsAuth

This way is **not recommended** and requires server-side code to run securely.  
With this approach, you make a POST Request with a base64 encoded string (consists of ClientId + ClientSecret). You will directly get the token (Without a local HTTP Server), but it will expire and can't be refreshed.  
If you want to use it securely, you would need to do it all server-side.  
**NOTE:** You will only be able to query non-user-related information e.g search for a Track.

More info: [here](https://developer.spotify.com/web-api/authorization-guide/#client_credentials_flow)

```
static ClientCredentialsAuth auth;
static void Main(string[] args)
{
    //Create the auth object
    auth = new ClientCredentialsAuth()
    {
        //Your client Id
        ClientId = "XXXXXXXXXXXXXXX",
        //Your client secret UNSECURE!!
        ClientSecret = "XXXXXXXXXXXX",
        //How many permissions we need?
        Scope = Scope.UserReadPrivate,
    };
    //With this token object, we now can make calls
    Token token = auth.DoAuth();
    var spotify = new SpotifyWebApiClass()
    {
        TokenType = token.TokenType,
        AccessToken = token.AccessToken,
        UseAuth = false
    };
}
```

#Scopes
