# Profiles

## GetPrivateProfile

> Get detailed profile information about the current user (including the current user’s username).

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|

Returns a [PrivateProfile](https://developer.spotify.com/web-api/object-model/#user-object-private)

**Usage**
```csharp
PrivateUser user = _spotify.GetPrivateProfile();
Console.WriteLine(user.DisplayName);
```

---

## GetPublicProfile

> Get public profile information about a Spotify user.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|userId| The user's Spotify user ID. | EXAMPLE

Returns a [PublicProfile](https://developer.spotify.com/web-api/object-model/#user-object-public)

**Usage**
```csharp
```

---
