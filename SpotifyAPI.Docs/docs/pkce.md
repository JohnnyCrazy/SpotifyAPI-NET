---
id: pkce
title: PKCE
---

> The authorization code flow with PKCE is the best option for mobile and desktop applications where it is unsafe to store your client secret. It provides your app with an access token that can be refreshed. For further information about this flow, see IETF RFC-7636.

## Generating Challenge & Verifier

For every authentation request, a verify code and its challenge code needs to be generated. The class `PKCEUtil` can be used to generate those, either with random generated or self supplied values:

```csharp
// Generates a secure random verifier of length 100 and its challenge
var (verifier, challenge) = PKCEUtil.GenerateCodes();

// Generates a secure random verifier of length 120 and its challenge
var (verifier, challenge) = PKCEUtil.GenerateCodes(120);

// Returns the passed string and its challenge (Make sure it's random and is long enough)
var (verifier, challenge) = PKCEUtil.GenerateCodes("YourSecureRandomString");
```

## Generating Login URI

Like most auth flows, you'll need to redirect your user to spotify's servers so he is able to grant access to your application:

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
// Redirect user to uri via your favorite web-server
```

When the user is redirected to the generated uri, he will have to login with his spotify account and confirm, that your application wants to access his user data. Once confirmed, he will be redirect to `http://localhost:5000/callback` and a `code` parameter is attached to the query. The redirect URI can also contain a custom protocol paired with UWP App Custom Protocol handler. This received `code` has to be exchanged for an `access_token` and `refresh_token`:

```csharp
// This method should be called from your web-server when the user visits "http://localhost:5000/callback"
public Task GetCallback(string code)
{
  // Note that we use the verifier calculated above!
  var response = await new OAuthClient().RequestToken(
    new PKCETokenRequest("ClientId", code, "http://localhost:5000", verifier)
  );

  var spotify = new SpotifyClient(response.AccessToken);
  // Also important for later: response.RefreshToken
}
```

With PKCE you can also refresh tokens once they're expired:

```csharp
var response = await new OAuthClient().RequestToken(
  new PKCETokenRefreshRequest("ClientId", oldResponse.RefreshToken)
);

var spotify = new SpotifyClient(response.AccessToken);
```


