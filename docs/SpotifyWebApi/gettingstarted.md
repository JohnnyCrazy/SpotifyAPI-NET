#SpotifyWebAPI

This API provides full access to the new SpotifyWebAPI introduced [here](https://developer.spotify.com/web-api/).  
With it, you can search for Tracks/Albums/Artists and also get User-based information.  
It's also possible to create new playlists and add tracks to it.

---

#Getting started

The API features all currently available features and also provides some examples to get things rolling!  
Full-Method Reference:  

* [Albums](test)

[Examples](/SpotifyWebApi/examples)

---

#Properties

##UseAuth
Wether auth should be used or not. User-stuff can only be fetched with auth.  
**NOTE:** If you use auth, you need to provide both, `TokenType` and `AccessToken`  
```
_spotify.UseAuth = false;
```

##TokenType
The token-type. Normally "Bearer" or "Basic".  
```
_spotify.TokenType = "XXXXXXXXXXXXXXXX";
```

##AccessToken
The access-token received by your auth-type.  
```
_spotify.AccessToken = "XXXXXXXXXXXXXXXX";
```
