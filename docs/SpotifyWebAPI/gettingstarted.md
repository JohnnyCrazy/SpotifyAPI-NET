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
Further infos on how to implement Authentication can be found [here](/SpotifyWebAPI/auth)

---

##Examples  
A list of small examples can be found [here](/SpotifyWebAPI/examples). Do you think a specific example is missing? Feel free to open a PR/Issue!

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
* [GetAlbumTracks](/SpotifyWebAPI/albums#getalbumtracks)
* [GetAlbum](/SpotifyWebAPI/albums#getalbum)
* [GetSeveralAlbums](/SpotifyWebAPI/albums#getseveralalbums)

###Artists
* [GetArtist](/SpotifyWebAPI/artists#getartist)
* [GetRelatedArtists](/SpotifyWebAPI/artists#getrelatedartists)
* [GetArtistsTopTracks](/SpotifyWebAPI/artists#getartiststoptracks)
* [GetArtistsAlbums](/SpotifyWebAPI/artists#getartistsalbums)
* [GetSeveralArtists](/SpotifyWebAPI/artists#getseveralartists)

###Browse
* [GetFeaturedPlaylists](/SpotifyWebAPI/browse#getfeaturedplaylists)
* [GetNewAlbumReleases](/SpotifyWebAPI/browse#getnewalbumreleases)
* [GetCategories](/SpotifyWebAPI/browse#getcategories)
* [GetCategory](/SpotifyWebAPI/browse#getcategory)
* [GetCategoryPlaylists](/SpotifyWebAPI/browse#getcategoryplaylists)

###Follow
* [Follow](/SpotifyWebAPI/follow#follow)
* [Unfollow](/SpotifyWebAPI/follow#unfollow)
* [IsFollowing](/SpotifyWebAPI/follow#isfollowing)
* [FollowPlaylist](/SpotifyWebAPI/follow#followplaylist)
* [UnfollowPlaylist](/SpotifyWebAPI/follow#unfollowplaylist)
* [IsFollowingPlaylist](/SpotifyWebAPI/follow#isfollowingplaylist)

###Library
* [SaveTracks](/SpotifyWebAPI/library#savetracks)
* [SaveTrack](/SpotifyWebAPI/library#savetrack)
* [GetSavedTracks](/SpotifyWebAPI/library#getsavedtracks)
* [RemoveSavedTracks](/SpotifyWebAPI/library#removesavedtracks)
* [CheckSavedTracks](/SpotifyWebAPI/library#checksavedtracks)

###Playlists
* [GetUserPlaylists](/SpotifyWebAPI/playlists#getuserplaylists)
* [GetPlaylist](/SpotifyWebAPI/playlists#getplaylist)
* [GetPlaylistTracks](/SpotifyWebAPI/playlists#getplaylisttracks)
* [CreatePlaylist](/SpotifyWebAPI/playlists#createplaylist)
* [UpdatePlaylist](/SpotifyWebAPI/playlists#updateplaylist)
* [ReplacePlaylistTracks](/SpotifyWebAPI/playlists#replaceplaylisttracks)
* [RemovePlaylistTracks](/SpotifyWebAPI/playlists#removeplaylisttracks)
* [RemovePlaylistTrack](/SpotifyWebAPI/playlists#removeplaylisttrack)
* [AddPlaylistTracks](/SpotifyWebAPI/playlists#addplaylisttracks)
* [AddPlaylistTrack](/SpotifyWebAPI/playlists#addplaylisttrack)
* [ReorderPlaylist](/SpotifyWebAPI/playlists#reorderplaylist)

###Profiles
* [GetPublicProfile](/SpotifyWebAPI/profiles#getpublicprofile)
* [GetPrivateProfile](/SpotifyWebAPI/profiles#getprivateprofile)

###Search
* [SearchItems](/SpotifyWebAPI/search#searchitems)

###Tracks
* [GetSeveralTracks](/SpotifyWebAPI/tracks#getseveraltracks)
* [GetTrack](/SpotifyWebAPI/tracks#gettrack)
