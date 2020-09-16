---
id: error_handling
title: Error Handling
---

API calls can fail when input data is malformed or the server detects issues with the request. As an example, the following request obviously fails:

```csharp
var track = await spotify.Tracks.Get("NotExistingTrackId");
Console.WriteLine(track.Name);
```

When a request fails, an `APIException` is thrown. Specific errors may throw a child exception of `APIException`.

## APIException

A very general API error. The message is parsed from the API response's JSON body and the response is available as a public property.

```csharp
try {
  var track = await spotify.Tracks.Get("NotExistingTrackId");
} catch(APIException e) {
  // Prints: invalid id
  Console.WriteLine(e.Message);
  // Prints: BadRequest
  Console.WriteLine(e.Response?.StatusCode);
}
```

## APIUnauthorizedException

Provides the same properties as `APIException` and occurs when the access token is expired or not provided. Notice that an access token has to be included in **every** request. Spotify does not allow unauthorized API access.

## APITooManyRequestsException

Provides the same properties as `APIException` and occurs when too many requests has been sent by your application. It also provides the property `TimeSpan RetryAfter`, which maps to the received `Retry-After` header.

```csharp
try {
  // call it very often?
  var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");
} catch(APITooManyRequestsException e) {
  // Prints: seconds to wait, often 1 or 2
  Console.WriteLine(e.RetryAfter);
}
```
