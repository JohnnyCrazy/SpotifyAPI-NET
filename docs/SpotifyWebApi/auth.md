#Auth-Methods  

Before you can use the Web API full functional, you need the user to authenticate your Application.  
If you want to know more, you can read to the whole auth-process [here](https://developer.spotify.com/web-api/authorization-guide/).

Before you start, you need to create a Application at Spotify: [Your Applications](https://developer.spotify.com/my-applications/#!/applications)

***

After you created your Application, you will have following important values:  
>**Client_Id** This is your client_id, you don't have to hide it  
>**Client_Secret** Never use this in one of your client-side apps!! Keep it secret!  
>**Redirect URIs** Add "http://localhost", if you want full support for this API  

Now you can start with the User-authentication, Spotify provides 3 ways:

* [ImplicitGrantAuth](/SpotifyWebApi/#implicitgrantauth) (**Recommended**, no server-side code needed)  

* [AutorizationCodeAuth](/SpotifyWebApi/#implicitgrantauth) (Not Recommended, Server-side code needed, else it's unsecure)

* [ClientCredentialsAuth](/SpotifyWebApi/#implicitgrantauth) (Not Recommended, Server-side code needed, else it's unsecure)  

**Note:** I would recommend a little PHP Script, which will exchange the Keys using AutorizationCodeAuth. 
When using ImplicitGrantAuth, another user could abuse the "localhost" RedirectUri by creating a "fake"-app which uses your ClientId.

Overview:
![Overview](http://i.imgur.com/uf3ahTl.png)

After implementing one of the provided auth-methods, you can start doing requests with the token you get from one of the auth-methods

##ImplicitGrantAuth

This way is **recommended** and the only auth-process, which does not need a server-side exchange of keys. With this approach, you directly get a Token object after the user authed your application.
You won't be able to refresh the token. If you want to use the internal Http server, please add "http://localhost" to your application redirects.

More info: [here](https://developer.spotify.com/web-api/authorization-guide/#implicit_grant_flow)

```csharp
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
        Scope = Scope.USER_READ_PRIVATE,
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
    //stop the http server
    auth.StopHttpServer();
    
    var spotify = new SpotifyWebApiClass()
    {
        TokenType = token.TokenType,
        AccessToken = token.AccessToken
    };
    //We can now make calls with the token object
}
```

##AutorizationCodeAuth

This way is **not recommended** and requires server-side code to run securely.  
With this approach, you first get a code which you need to trade against the access-token.  
In this exchange you need to provide your Client-Secret and because of that it's not recommended.  
(But you can e.g exchange to codes via a PHP Script)  
A good thing about this method: You can always refresh your token, without having the user to auth it again

More info: [here](https://developer.spotify.com/web-api/authorization-guide/#authorization_code_flow)

```csharp
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
        Scope = Scope.USER_READ_PRIVATE,
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
    //Stop the HTTP Server, done.
    auth.StopHttpServer();
    
    //NEVER DO THIS! You would need to provide the ClientSecret.
    //You would need to do it e.g via a PHP-Script.
    Token token = auth.ExchangeAuthCode(response.Code, "XXXXXXXXXXX");
    
    var spotify = new SpotifyWebApiClass()
    {
        TokenType = token.TokenType,
        AccessToken = token.AccessToken
    };

    //With the token object, you can now make API calls
}
```

##ClientCredentialsAuth

This way is **not recommended** and requires server-side code to run securely.  
With this approach, you make a POST Request with a base64 encoded string (consists of ClientId + ClientSecret). You will directly get the token (Without a local HTTP Server), but it will expire and can't be refreshed.  
If you want to use it securely, you would need to do it all server-side.  
**NOTE:** You will only be able to query non-user-related information e.g search for a Track.

More info: [here](https://developer.spotify.com/web-api/authorization-guide/#client_credentials_flow)

```csharp
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
        Scope = Scope.USER_READ_PRIVATE,
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