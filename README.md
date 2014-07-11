SpotifyAPI-NET
===

An API for the Spotify-Client, written in .NET  
Look at the example provided in the Repo

Following 3 files will be needed for all features:
+ SpotifyAPI.dll
+ Newtonsoft.Json.dll (Will be merged into SpotifyAPI.dll in the official Releases using ILMerge)
+ nircmd.dll (Used to Mute & UnMute Spotify)  
  
Screenshot of the Example:
![alt text](http://i.imgur.com/R9Xsma0.png "Example Screen")

Update:
===
This API will also support the "new" Spotify Web API soon, following things will be possible:

(Ticked = implemented and ready to push,Not ticked = Work in Progress)

- [ ] Get an Album
- [ ] Get Several Albums
- [ ] Get an Album'S Tracks 
- [ ] Get an Artist
- [ ] Get Several Artists
- [ ] Get an Artist's Albums
- [ ] Get an Artist's Top Tracks
- [ ] Get an Artist'S Related Artists
- [ ] Get a Track
- [ ] Get several Tracks
- [ ] Search for an Item
- [x] Get a User's Profile
- [x] Get Current User’s Profile
- [x] Get a List of a User's Profile
- [x] Get a Playlist
- [x] Get a Playlist's Tracks
- [ ] Create a Playlist
- [ ] Add Tracks to a Playlist

With this Update, there will be 2 new/modified namespaces:
> SpotifyAPI.SpotifyLocalAPI (Old local API)

> SpotifyAPI.SpotifyWebAPI (New web API)

___

Usage:
==============  


### SpotifyAPI
#####Boolean Connect()
> Connects the SpotifyAPI to the Spotify Client (Needs to be called before making calls, Spotify has to run)   
> Returns true if it was successful

#####void Update()  
> Updates Information about Tracks etc.

#####void RunSpotify()
> Runs Spotify (Client has to run for API Calls)

#####void RunSpotifyWebHelper()
> Runs SpotifyWebHelper (Client has to run for API Calls)

#####static Boolean IsSpotifyRunning()
> Returns true, if Spotify is running

#####static Boolean IsSpotifyWebHelperRunning()
> Returns true, if SpotifyWebHelper is running

#####static Boolean IsValidSpotifyURL(String SpotifyURL)
> Returns true, if the provided Spotify URL is working (Not working yet)

#####[SpotifyMusicHandler](https://github.com/JohnnyCrazy/SpotifyAPI-NET#spotifymusichandler) GetMusicHandler()
> Returns the MusicHandler

#####[SpotifyEventHandler](https://github.com/JohnnyCrazy/SpotifyAPI-NET#spotifyeventhandler) GetEventHandler()
> Returns the EventHandler  
  

### SpotifyMusicHandler
#####void Play()  
> Play "button"

#####void Pause()
> Pause "button"

#####void Skip() 
> Skip Track

#####void Previous() 
> Previous Track

#####void PlayURL(String SpotifyURI)
> Plays the provided URI

#####double GetVolume()
> Returns the current volume (0.00 - 1.00)

#####Boolean IsAdRunning()
> Returns true, if an AD is running

#####double GetTrackPostion()
> Returns the current position of the Track

#####void Mute()
> Mutes Spotify (Requires nircmd.dll)

#####void UnMute()
> Unmutes Spotify (Requires nircmd.dll

#####Boolean IsPlaying() 
> Returns true, if Spotify is playing atm

#####[Track](https://github.com/JohnnyCrazy/SpotifyAPI-NET#track) GetCurrentTrack() 
> Returns the current Track

#####StatusResponse GetStatusResponse() 
> Returns the StatusResponse, which contains all Information gathered by the Call (Should not be used at all)


### SpotifyEventHandler
#####Event OnTrackChange 
> Triggered, when the Track gets changed

#####Event OnPlayStateChange
> Triggered, when Spotify's Play/Pause-State changes

#####Event OnVolumeChange
> Triggered, when the volume gets changed

#####Event TrackTimeChangeEventHandler
> Triggered, when the current trackposition changes

#####void ListenForEvents(Boolean listen)
> Should it listen for events?

#####void SetSynchronizingObject(ISynchronizeInvoke obj)
> Sets the synced object, so no Invoke is required (Events doesnt get called from the Main-Thread)


### Track
#####String GetTrackName()
> Returns Track-name

#####String GetArtistName()
> Returns Artist-name

#####String GetAlbumName()
> Returns Album-name

#####int GetLength()
> Returns the Track lenght

#####String GetAlbumURI()
> Returns the URI for the album

#####String GetTrackURI()
> Returns the URI for the Track

#####String GetArtistURI()
> Returns the URI for the Artist

#####String GetAlbumArtURL(AlbumArtSize size)
> Returns the URL of the Albumart based on the choosen size

#####Bitmap GetAlbumArt(AlbumArtSize size)
> Returns a Bitmap of the Albumart based on the choosen size

#####Bitmap GetAlbumArtAsync(AlbumArtSize size)
> Returns a Bitmap of the Albumart based on the choosen size asynchronously
