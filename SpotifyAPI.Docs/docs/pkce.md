---
id: pkce
title: PKCE
---

> The authorization code flow with PKCE is the best option for mobile and desktop applications where it is unsafe to store your client secret. It provides your app with an access token that can be refreshed. For further information about this flow, see [IETF RFC-7636](https://tools.ietf.org/html/rfc7636).

## Generating Challenge & Verifier

For every authentication request, a verify code and its challenge code needs to be generated. The class `PKCEUtil` can be used to generate those, either with random generated or self supplied values:

```csharp
// Generates a secure random verifier of length 100 and its challenge
var (verifier, challenge) = PKCEUtil.GenerateCodes();

// Generates a secure random verifier of length 120 and its challenge
var (verifier, challenge) = PKCEUtil.GenerateCodes(120);

// Returns the passed string and its challenge (Make sure it's random and long enough)
var (verifier, challenge) = PKCEUtil.GenerateCodes("YourSecureRandomString");
```

## Generating Login URI

Like most auth flows, you'll need to redirect your user to Spotify's servers so they are able to grant access to your application:

```csharp
// Make sure "http://localhost:5000/callback" is in your applications redirect URIs!
var loginRequest = new LoginRequest(
  new Uri("http://localhost:5000/callback"),
  "YourClientId",
  LoginRequest.ResponseType.Code
)
{
  CodeChallengeMethod = "S256",
  CodeChallenge = challenge,
  Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
};
var uri = loginRequest.ToUri();
// Redirect user to uri via your favorite web-server or open a local browser window
```

When the user is redirected to the generated uri, they will have to login with their Spotify account and confirm that your application wants to access their user data. Once confirmed, they will be redirected to `http://localhost:5000/callback` and a `code` parameter is attached to the query. The redirect URI can also contain a custom protocol paired with UWP App Custom Protocol handler. This received `code` has to be exchanged for an `access_token` and `refresh_token`:

```csharp
// This method should be called from your web-server when the user visits "http://localhost:5000/callback"
public Task GetCallback(string code)
{
  // Note that we use the verifier calculated above!
  var initialResponse = await new OAuthClient().RequestToken(
    new PKCETokenRequest("ClientId", code, "http://localhost:5000", verifier)
  );

  var spotify = new SpotifyClient(initialResponse.AccessToken);
  // Also important for later: response.RefreshToken
}
```

With PKCE you can also refresh tokens once they're expired:

```csharp
var newResponse = await new OAuthClient().RequestToken(
  new PKCETokenRefreshRequest("ClientId", initialResponse.RefreshToken)
);

var spotify = new SpotifyClient(newResponse.AccessToken);
```

If you do not want to take care of manually refreshing tokens, you can use `PKCEAuthenticator`:

```csharp
var authenticator = new PKCEAuthenticator(clientId, initialResponse);

var config = SpotifyClientConfig.CreateDefault()
  .WithAuthenticator(authenticator);
var spotify = new SpotifyClient(config);
```
