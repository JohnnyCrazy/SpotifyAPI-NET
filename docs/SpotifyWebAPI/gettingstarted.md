#Getting started

This API provides full access to the new SpotifyWebAPI introduced [here](https://developer.spotify.com/web-api/).  
With it, you can search for Tracks/Albums/Artists and also get User-based information.  
It's also possible to create new playlists and add tracks to it.

---

##First steps

**Imports**  
So after you added the API to your project, you may want to add following imports to your files:

```cs
using SpotifyAPI.Web; //Base Namespace
using SpotifyAPI.Web.Auth; //All Authentication-related classes
using SpotifyAPI.Web.Enums; //Enums
using SpotifyAPI.Web.Models; //Models for the JSON-responses
```

**Basic-Usage**  
Now you can actually start doing calls to the SpotifyAPI, just create a new Instance of SpotifyWebAPI:
```cs
private static SpotifyWebAPI _spotify;

public static void Main(String[] args)
{
        _spotify = new SpotifyWebAPI()
        {
            UseAuth = false, //This will disable Authentication.
        }
        FullTrack track = _spotify.GetTrack("3Hvu1pq89D4R0lyPBoujSv");
        Console.WriteLine(track.Name); //Yeay! We just printed a tracks name.
        //...
}
```

---

##Authentication
If you look through the available API-Methods, you will soon notice nearly all of them require Authentication.
Further infos on how to implement Authentication can be found [here](/SpotifyWebApi/auth)

---

##Examples  
A list of small examples can be found [here](/SpotifyWebApi/examples). Do you think a specific example is missing? Feel free to open a PR/Issue!

---

##Error-Handling
Every API-Call returns a reponse-model which consists of base-error model. To check if a specific API-Call was successful, use the following approach:
```cs
PrivateProfile profile = _spotify.GetPrivateProfile();
if (profile.HasError())
{
    Console.WriteLine("Error Status: " + profile.Error.Status);
    Console.WriteLine("Error Msg: " + profile.Error.Message);
}
```

---

##API-Reference

###Albums
* [GetAlbumTracks](/SpotifyWebApi/albums#getalbumtracks)
* [GetAlbum](/SpotifyWebApi/albums#getalbum)
* [GetSeveralAlbums](/SpotifyWebApi/albums#getseveralalbums)

###Artists
* [GetArtist](/SpotifyWebApi/artists#getartist)
* [GetRelatedArtists](/SpotifyWebApi/artists#getrelatedartists)
* [GetArtistsTopTracks](/SpotifyWebApi/artists#getartiststoptracks)
* [GetArtistsAlbums](/SpotifyWebApi/artists#getartistsalbums)
* [GetSeveralArtists](/SpotifyWebApi/artists#getseveralartists)

###Browse
* [GetFeaturedPlaylists](/SpotifyWebApi/browse#getfeaturedplaylists)
* [GetNewAlbumReleases](/SpotifyWebApi/browse#getnewalbumreleases)
* [GetCategories](/SpotifyWebApi/browse#getcategories)
* [GetCategory](/SpotifyWebApi/browse#getcategory)
* [GetCategoryPlaylists](/SpotifyWebApi/browse#getcategoryplaylists)

###Follow
* [Follow](/SpotifyWebApi/follow#follow)
* [Unfollow](/SpotifyWebApi/follow#unfollow)
* [IsFollowing](/SpotifyWebApi/follow#isfollowing)
* [FollowPlaylist](/SpotifyWebApi/follow#followplaylist)
* [UnfollowPlaylist](/SpotifyWebApi/follow#unfollowplaylist)
* [IsFollowingPlaylist](/SpotifyWebApi/follow#isfollowingplaylist)

###Library
* [SaveTracks](/SpotifyWebApi/library#savetracks)
* [SaveTrack](/SpotifyWebApi/library#savetrack)
* [GetSavedTracks](/SpotifyWebApi/library#getsavedtracks)
* [RemoveSavedTracks](/SpotifyWebApi/library#removesavedtracks)
* [CheckSavedTracks](/SpotifyWebApi/library#checksavedtracks)

###Playlists
* [GetUserPlaylists](/SpotifyWebApi/playlists#getuserplaylists)
* [GetPlaylist](/SpotifyWebApi/playlists#getplaylist)
* [GetPlaylistTracks](/SpotifyWebApi/playlists#getplaylisttracks)
* [CreatePlaylist](/SpotifyWebApi/playlists#createplaylist)
* [UpdatePlaylist](/SpotifyWebApi/playlists#updateplaylist)
* [ReplacePlaylistTracks](/SpotifyWebApi/playlists#replaceplaylisttracks)
* [RemovePlaylistTracks](/SpotifyWebApi/playlists#removeplaylisttracks)
* [RemovePlaylistTrack](/SpotifyWebApi/playlists#removeplaylisttrack)
* [AddPlaylistTracks](/SpotifyWebApi/playlists#addplaylisttracks)
* [AddPlaylistTrack](/SpotifyWebApi/playlists#addplaylisttrack)
* [ReorderPlaylist](/SpotifyWebApi/playlists#reorderplaylist)

###Profiles
* [GetPublicProfile](/SpotifyWebApi/profiles#getpublicprofile)
* [GetPrivateProfile](/SpotifyWebApi/profiles#getprivateprofile)

###Search
* [SearchItems](/SpotifyWebApi/search#searchitems)

###Tracks
* [GetSeveralTracks](/SpotifyWebApi/tracks#getseveraltracks)
* [GetTrack](/SpotifyWebApi/tracks#gettrack)
