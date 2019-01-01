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
#### Way 1 - Asynchronous
If placed inside a function marked as 'async', this will complete in the background when you call it but will not be
immediately ready after the function has been called (because it will attempt to do other code in the mean time).

```c#
TokenSwapWebAPIFactory webApiFactory;
SpotifyWebAPI spotify;

// You should store a reference to WebAPIFactory if you are using AutoRefresh or want to manually
// refresh it later on. New WebAPIFactory objects cannot refresh a SpotifyWebAPI that they did not
// give to you.
webApiFactory = new TokenSwapWebAPIFactory("INSERT LINK TO YOUR index.php HERE")
{
    Scope = Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead | Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistReadCollaborative | Scope.UserReadRecentlyPlayed | Scope.UserReadPlaybackState | Scope.UserModifyPlaybackState | Scope.PlaylistModifyPublic,
    AutoRefresh = true
};
webApiFactory.OnAuthSuccess += (sender, e) => authorized = true;

try
{
    spotify = await webApiFactory.GetWebApiAsync();
}
catch (Exception ex)
{
    UpdateStatus($"Spotify failed to load: {ex.Message}");
}
```

#### Way 2 - Synchronous
This will halt the program until your SpotifyWebAPI is available.

```c#
TokenSwapWebAPIFactory webApiFactory;
SpotifyWebAPI spotify;

bool requestComplete = false;

Task.Factory.StartNew(async () =>
{
    // You should store a reference to WebAPIFactory if you are using AutoRefresh or want to manually
    // refresh it later on. New WebAPIFactory objects cannot refresh a SpotifyWebAPI that they did not
    // give to you.
    webApiFactory = new TokenSwapWebAPIFactory("INSERT LINK TO YOUR index.php HERE")
    {
        Scope = Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead | Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistReadCollaborative | Scope.UserReadRecentlyPlayed | Scope.UserReadPlaybackState | Scope.UserModifyPlaybackState | Scope.PlaylistModifyPublic,
        AutoRefresh = true
    };
    webApiFactory.OnAuthSuccess += (sender, e) => authorized = true;

    try
    {
        spotify = await webApiFactory.GetWebApiAsync();
    }
    catch (Exception ex)
    {
        UpdateStatus($"Spotify failed to load: {ex.Message}");
    }

    requestComplete = true;
});

while (!requestComplete) ;
```

### Verbose way - using the TokenSwapAuth class
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

### Creating the Exchange Server
To keep your client ID and redirect URI secure to an extent, and client secret secure in every circumstance,
use of a php server and php code (server-side only code) is required.

It should be noted that GitHub Pages does not support hosting php scripts. Hosting php scripts through it
will cause the php to render as plain html, potentially compromising your client secret while doing
absolutely nothing.

This code should go inside your 'index.php' file on your php website server.

```php
<?php
    define("CLIENT_ID", "INSERT YOUR CLIENT ID HERE");
    define("SECRET", "INSERT YOUR CLIENT SECRET HERE");
    define("REDIRECT_URI", "INSERT YOUR REDIRECT URL HERE");

    function clean_request_input($data)
    {
        $data = trim($data);
        $data = stripslashes($data);
        $data = htmlspecialchars($data);
        return $data;
    }

    // # Request Variables
    // ## Get Access and Refresh Tokens
    $grant_type = clean_request_input($_POST["grant_type"]);
    $auth_code = clean_request_input($_POST["code"]);
    // ### Get Refreshed Access Token
    $refresh_token = clean_request_input($_POST["refresh_token"]);
    // ## Get Authorization Code
    $scope = clean_request_input($_GET["scope"]);
    $state = clean_request_input($_GET["state"]);
    $show_dialog = clean_request_input($_GET["show_dialog"]);

    // Gets the token response JSON, which contains the access and refresh tokens.
    //
    // Documentation: https://developer.spotify.com/documentation/general/guides/authorization-guide/#2-have-your-application-request-refresh-and-access-tokens-spotify-returns-access-and-refresh-tokens
    // Example response:
    // {
    //    "access_token": "NgCXRK...MzYjw",
    //    "token_type": "Bearer",
    //    "scope": "user-read-private user-read-email",
    //    "expires_in": 3600,
    //    "refresh_token": "NgAagA...Um_SHo"
    // }
    function get_token($auth_code)
    {
        $request = curl_init("https://accounts.spotify.com/api/token");
        curl_setopt($request, CURLOPT_HTTPHEADER,
        [
            "Authorization: Basic ".base64_encode(CLIENT_ID.":".SECRET)
        ]);
        curl_setopt($request, CURLOPT_POST, true);
        curl_setopt($request, CURLOPT_RETURNTRANSFER, true);
        // It should be noted here that 'http_build_query' COULD be replaced with an array, but it will change the content type
        // of the request to another one that it does not support.
        curl_setopt($request, CURLOPT_POSTFIELDS, http_build_query([
            "grant_type" => "authorization_code",
            "code" => $auth_code,
            "redirect_uri" => REDIRECT_URI
        ]));
        $result = curl_exec($request);
        // Spotify usually returns a neutral boilerplate message however, so this is very unlikely...
        if (!$result)
        {
            trigger_error(curl_error($request));
        }
        curl_close($request);
        return $result;
    }

    // Gets the token response JSON, which contains a refreshed access token, but no refresh token (as it would be unnecessary).
    //
    // Documentation: https://developer.spotify.com/documentation/general/guides/authorization-guide/#4-requesting-a-refreshed-access-token-spotify-returns-a-new-access-token-to-your-app
    // Example response:
    // {
    //     "access_token": "NgA6ZcYI...ixn8bUQ",
    //     "token_type": "Bearer",
    //     "scope": "user-read-private user-read-email",
    //     "expires_in": 3600
    // }
    function refresh_token($refresh_token)
    {
        $request = curl_init("https://accounts.spotify.com/api/token");
        curl_setopt($request, CURLOPT_HTTPHEADER,
        [
            "Authorization: Basic ".base64_encode(CLIENT_ID.":".SECRET)
        ]);
        curl_setopt($request, CURLOPT_POST, true);
        curl_setopt($request, CURLOPT_RETURNTRANSFER, true);
        // It should be noted here that 'http_build_query' COULD be replaced with an array, but it will change the content type
        // of the request to another one that it does not support.
        curl_setopt($request, CURLOPT_POSTFIELDS, http_build_query([
            "grant_type" => "refresh_token",
            "refresh_token" => $refresh_token
        ]));
        $result = curl_exec($request);
        // Spotify usually returns a neutral boilerplate message however, so this is very unlikely...
        if (!$result)
        {
            trigger_error(curl_error($request));
        }
        curl_close($request);
        return $result;
    }

    // Redirects the browser to perform a GET request to Spotify, obtaining the auth code.
    function goto_auth_code($scope, $state, $show_dialog) {
        header("Location: "."https://accounts.spotify.com/authorize/?".http_build_query(
        [
            "client_id" => CLIENT_ID,
            "response_type" => "code",
            "redirect_uri" => REDIRECT_URI,
            "scope" => $scope,
            "state" => $state,
            "show_dialog" => $show_dialog
        ]), true, 303);
        die();
    }

    // By checking the grant type, we can choose to print out the context relevant json.
    if ($grant_type === "authorization_code")
    {
        // This line prints out the JSON response to the page, allowing HttpClient to take the whole page as a response
        // and begin parsing its JSON, to then go on to deserialize and so and so fourth...
        echo get_token($auth_code);
    }
    else if ($grant_type === "refresh_token")
    {
        echo refresh_token($refresh_token);
    }
    else
    {
        goto_auth_code($scope, $state, $show_dialog);
    }
?>
```

Additionally, the code for the page where your redirect uri for Spotify goes should be this. Be sure
you have whitelisted your redirect uri in the Spotify Developer Dashboard.

```php
<?php
    header("Location: http://localhost:4002/?".http_build_query([
        "code" => $_GET["code"],
        "state" => $_GET["state"]
    ]), true, 303);
    die()
?>
```

It should be noted that if you did not use the WebAPIFactory or you defined your own serverUri,
you must change the areas in the php which refer to localhost:4002 as it will never reach
your serverUri otherwise.

##AutorizationCodeAuth

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

##ClientCredentialsAuth

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
