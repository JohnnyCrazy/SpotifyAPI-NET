---
sidebar: false
---

# ClientCredentialsAuth

With this approach, you make a POST Request with a base64 encoded string (consists of ClientId + ClientSecret). You will directly get the token (Without a local HTTP Server), but it will expire and can't be refreshed.
If you want to use it securely, you would need to do it all server-side.
**NOTE:** You will only be able to query non-user-related information e.g search for a Track.

More info: [here](https://developer.spotify.com/documentation/general/guides/authorization-guide/#client-credentials-flow)

```csharp
CredentialsAuth auth = new CredentialsAuth(_clientId, _secretId);
Token token = await auth.GetToken();
SpotifyWebAPI api = new SpotifyWebAPI()
{
  TokenType = token.TokenType,
  AccessToken = token.AccessToken
};
```
