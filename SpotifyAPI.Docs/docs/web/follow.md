# Follow

## Follow

> Add the current user as a follower of one or more artists or other Spotify users.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|followType| The ID type: either artist or user. | `FollowType.Artist`
|ids or id| A list of the artist or the user Spotify IDs or just a Spotify ID | `new List<String> { "1KpCi9BOfviCVhmpI4G2sY" }` or `"1KpCi9BOfviCVhmpI4G2sY"`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.Follow(FollowType.Artist, "1KpCi9BOfviCVhmpI4G2sY");
//or if it's a User
ErrorResponse response = _spotify.Follow(FollowType.User, "1122095781");
```

---
## Unfollow

> Remove the current user as a follower of one or more artists or other Spotify users.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|followType| The ID type: either artist or user. | `FollowType.Artist`
|ids or id| A list of the artist or the user Spotify IDs or just a Spotify ID | `new List<String> { "1KpCi9BOfviCVhmpI4G2sY" }` or `"1KpCi9BOfviCVhmpI4G2sY"`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.Unfollow(FollowType.Artist, "1KpCi9BOfviCVhmpI4G2sY");
//or if it's a User
ErrorResponse response = _spotify.Unfollow(FollowType.User, "1122095781");
```

---
## IsFollowing

> Check to see if the current user is following one or more artists or other Spotify users.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|followType| The ID type: either artist or user. | `FollowType.Artist`
|ids or id| A list of the artist or the user Spotify IDs or just a Spotify ID | `new List<String> { "1KpCi9BOfviCVhmpI4G2sY" }` or `"1KpCi9BOfviCVhmpI4G2sY"`

Returns a `ListResponse<Boolean>` which contains the property `List<Boolean> List`

**Usage**
```csharp
//Are you one of my Followers? :P
ListResponse<Boolean> response = _spotify.IsFollowing(FollowType.User, "1122095781");
Console.WriteLine(response.List[0] ? "Yis!" : "No :(");
```

---
## FollowPlaylist

> Add the current user as a follower of a playlist.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ownerId| The Spotify user ID of the person who owns the playlist. | `"maxloermans"`
|playlistId| The Spotify ID of the playlist. Any playlist can be followed, regardless of its public/private status, as long as you know its playlist ID. | `"3SIp2VAsKI03mReF0dFBmI"`
|[showPublic]| If true the playlist will be included in user's public playlists, if false it will remain  private. | `true`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.FollowPlaylist("maxloermans", "3SIp2VAsKI03mReF0dFBmI");
if(!response.HasError())
    Console.WriteLine("success");
```

---
## UnfollowPlaylist

> Remove the current user as a follower of a playlist.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ownerId| The Spotify user ID of the person who owns the playlist. | `"maxloermans"`
|playlistId| The Spotify ID of the playlist that is to be no longer followed. | `"3SIp2VAsKI03mReF0dFBmI"`

Returns a `ErrorResponse` which just contains a possible error. (`response.HasError()` and `response.Error`)

**Usage**
```csharp
ErrorResponse response = _spotify.UnfollowPlaylist("maxloermans", "3SIp2VAsKI03mReF0dFBmI");
if(!response.HasError())
    Console.WriteLine("success");
```

---
## IsFollowingPlaylist

> Check to see if one or more Spotify users are following a specified playlist.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ownerId| The Spotify user ID of the person who owns the playlist. | `"maxloermans"`
|playlistId| The Spotify ID of the playlist. | `"3SIp2VAsKI03mReF0dFBmI"`
|ids or id| A list of the artist or the user Spotify IDs or just a Spotify ID | `new List<String> { "1KpCi9BOfviCVhmpI4G2sY" }` or `"1KpCi9BOfviCVhmpI4G2sY"`

Returns a `ListResponse<Boolean>` which contains the property `List<Boolean> List`

**Usage**
```csharp
//Am I following the playlist?
ListResponse<Boolean> response = _spotify.IsFollowing("maxloermans", "3SIp2VAsKI03mReF0dFBmI", "1122095781");
Console.WriteLine(response.List[0] ? "Yis!" : "No :(");
```

---
