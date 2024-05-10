"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[8740],{9116:(e,s,l)=>{l.r(s),l.d(s,{assets:()=>o,contentTitle:()=>n,default:()=>h,frontMatter:()=>t,metadata:()=>a,toc:()=>c});var i=l(2488),r=l(7052);const t={id:"getting_started",title:"Getting Started",sidebar_label:"Getting Started"},n=void 0,a={id:"web/getting_started",title:"Getting Started",description:"This API provides full access to the new SpotifyWebAPI introduced here.",source:"@site/versioned_docs/version-5.1.1/web/getting_started.md",sourceDirName:"web",slug:"/web/getting_started",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/getting_started",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/web/getting_started.md",tags:[],version:"5.1.1",lastUpdatedBy:"XY Wang",lastUpdatedAt:1715323874,formattedLastUpdatedAt:"May 10, 2024",frontMatter:{id:"getting_started",title:"Getting Started",sidebar_label:"Getting Started"},sidebar:"someSidebar",previous:{title:"Home",permalink:"/SpotifyAPI-NET/docs/5.1.1/home"},next:{title:"Albums",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/albums"}},o={},c=[{value:"First steps",id:"first-steps",level:2},{value:"Imports",id:"imports",level:3},{value:"Basic-Usage",id:"basic-usage",level:3},{value:"Error-Handling",id:"error-handling",level:2},{value:"Sync vs Asynchronous",id:"sync-vs-asynchronous",level:2},{value:"API-Reference",id:"api-reference",level:2},{value:"Albums",id:"albums",level:3},{value:"Artists",id:"artists",level:3},{value:"Browse",id:"browse",level:3},{value:"Follow",id:"follow",level:3},{value:"Library",id:"library",level:3},{value:"Personalization",id:"personalization",level:3},{value:"Player",id:"player",level:3},{value:"Playlists",id:"playlists",level:3},{value:"Profiles",id:"profiles",level:3},{value:"Search",id:"search",level:3},{value:"Tracks",id:"tracks",level:3},{value:"Util",id:"util",level:3}];function d(e){const s={a:"a",code:"code",h2:"h2",h3:"h3",li:"li",p:"p",pre:"pre",ul:"ul",...(0,r.M)(),...e.components};return(0,i.jsxs)(i.Fragment,{children:[(0,i.jsxs)(s.p,{children:["This API provides full access to the new SpotifyWebAPI introduced ",(0,i.jsx)(s.a,{href:"https://developer.spotify.com/web-api/",children:"here"}),".\nWith it, you can search for Tracks/Albums/Artists and also get User-based information.\nIt's also possible to create new playlists and add tracks to it."]}),"\n",(0,i.jsx)(s.h2,{id:"first-steps",children:"First steps"}),"\n",(0,i.jsx)(s.h3,{id:"imports",children:"Imports"}),"\n",(0,i.jsx)(s.p,{children:"So after you added the API to your project, you may want to add following imports to your files:"}),"\n",(0,i.jsx)(s.pre,{children:(0,i.jsx)(s.code,{className:"language-csharp",children:"using SpotifyAPI.Web; //Base Namespace\nusing SpotifyAPI.Web.Enums; //Enums\nusing SpotifyAPI.Web.Models; //Models for the JSON-responses\n"})}),"\n",(0,i.jsx)(s.h3,{id:"basic-usage",children:"Basic-Usage"}),"\n",(0,i.jsx)(s.p,{children:"Now you can actually start doing calls to the SpotifyAPI, just create a new Instance of SpotifyWebAPI:"}),"\n",(0,i.jsx)(s.pre,{children:(0,i.jsx)(s.code,{className:"language-csharp",children:'private static SpotifyWebAPI _spotify;\n\npublic static void Main(String[] args)\n{\n    _spotify = new SpotifyWebAPI()\n    {\n        AccessToken = "XXXXXXXXXXXX",\n        TokenType = "Bearer"\n    }\n    FullTrack track = _spotify.GetTrack("3Hvu1pq89D4R0lyPBoujSv");\n    Console.WriteLine(track.Name); //Yeay! We just printed a tracks name.\n}\n'})}),"\n",(0,i.jsxs)(s.p,{children:["You may note that we used ",(0,i.jsx)(s.code,{children:"AccessToken"})," and ",(0,i.jsx)(s.code,{children:"TokenType"}),". Spotify does not allow un-authorized access to their API. You will need to implement one of the auth flows. Luckily, ",(0,i.jsx)(s.code,{children:"SpotifyAPI.Web.Auth"})," exists for this reason. A simple way to receive a ",(0,i.jsx)(s.code,{children:"AccessToken"})," is via ",(0,i.jsx)(s.code,{children:"CredentialAuth"}),":"]}),"\n",(0,i.jsx)(s.pre,{children:(0,i.jsx)(s.code,{className:"language-csharp",children:'CredentialsAuth auth = new CredentialsAuth("YourClientID", "YourClientSecret");\nToken token = await auth.GetToken();\n_spotify = new SpotifyWebAPI()\n{\n  AccessToken = token.AccessToken,\n  TokenType = token.TokenType\n}\n'})}),"\n",(0,i.jsxs)(s.p,{children:["For more info, visit the ",(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/auth/getting_started",children:"Getting Started of SpotifyAPI.Web.Auth"})]}),"\n",(0,i.jsx)(s.h2,{id:"error-handling",children:"Error-Handling"}),"\n",(0,i.jsx)(s.p,{children:"Every API-Call returns a reponse-model which consists of base-error model. To check if a specific API-Call was successful, use the following approach:"}),"\n",(0,i.jsx)(s.pre,{children:(0,i.jsx)(s.code,{className:"language-csharp",children:'PrivateProfile profile = _spotify.GetPrivateProfile();\nif (profile.HasError())\n{\n  Console.WriteLine("Error Status: " + profile.Error.Status);\n  Console.WriteLine("Error Msg: " + profile.Error.Message);\n}\n'})}),"\n",(0,i.jsx)(s.p,{children:"In case some or all of the returned values are null, consult error status and message, they can lead to an explanation!"}),"\n",(0,i.jsx)(s.h2,{id:"sync-vs-asynchronous",children:"Sync vs Asynchronous"}),"\n",(0,i.jsxs)(s.p,{children:["Every API-Call has an ",(0,i.jsx)(s.code,{children:"asynchronous"})," and ",(0,i.jsx)(s.code,{children:"synchronous"})," method."]}),"\n",(0,i.jsx)(s.pre,{children:(0,i.jsx)(s.code,{className:"language-csharp",children:"public async void Test()\n{\n  var asyncProfile = await _spotify.GetPrivateProfileAsync();\n  var syncProfile = _spotify.GetPrivateProfile();\n}\n"})}),"\n",(0,i.jsxs)(s.p,{children:["Note that the ",(0,i.jsx)(s.code,{children:"synchronous"})," call will block the current Thread!"]}),"\n",(0,i.jsx)(s.h2,{id:"api-reference",children:"API-Reference"}),"\n",(0,i.jsx)(s.h3,{id:"albums",children:"Albums"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/albums#getalbumtracks",children:"GetAlbumTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/albums#getalbum",children:"GetAlbum"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/albums#getseveralalbums",children:"GetSeveralAlbums"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"artists",children:"Artists"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/artists#getartist",children:"GetArtist"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/artists#getrelatedartists",children:"GetRelatedArtists"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/artists#getartiststoptracks",children:"GetArtistsTopTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/artists#getartistsalbums",children:"GetArtistsAlbums"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/artists#getseveralartists",children:"GetSeveralArtists"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"browse",children:"Browse"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/browse#getfeaturedplaylists",children:"GetFeaturedPlaylists"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/browse#getnewalbumreleases",children:"GetNewAlbumReleases"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/browse#getcategories",children:"GetCategories"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/browse#getcategory",children:"GetCategory"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/browse#getcategoryplaylists",children:"GetCategoryPlaylists"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"follow",children:"Follow"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/follow#follow",children:"Follow"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/follow#unfollow",children:"Unfollow"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/follow#isfollowing",children:"IsFollowing"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/follow#followplaylist",children:"FollowPlaylist"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/follow#unfollowplaylist",children:"UnfollowPlaylist"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/follow#isfollowingplaylist",children:"IsFollowingPlaylist"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"library",children:"Library"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#savetracks",children:"SaveTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#savetrack",children:"SaveTrack"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#getsavedtracks",children:"GetSavedTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#removesavedtracks",children:"RemoveSavedTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#checksavedtracks",children:"CheckSavedTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#savealbums",children:"SaveAlbums"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#savealbum",children:"SaveAlbum"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#getsavedalbums",children:"GetSavedAlbums"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#removesavedalbums",children:"RemoveSavedAlbums"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/library#checksavedalbums",children:"CheckSavedAlbums"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"personalization",children:"Personalization"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/personalization#getuserstoptracks",children:"GetUsersTopTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/personalization#getuserstopartists",children:"GetUsersTopArtists"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/personalization#getusersrecentlyplayedtracks",children:"GetUsersRecentlyPlayedTracks"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"player",children:"Player"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#getdevices",children:"GetDevices"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#getplayback",children:"GetPlayback"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#getplayingtrack",children:"GetPlayingTrack"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#transferplayback",children:"TransferPlayback"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#resumeplayback",children:"ResumePlayback"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#pauseplayback",children:"PausePlayback"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#skipplaybacktonext",children:"SkipPlaybackToNext"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#skipplaybacktoprevious",children:"SkipPlaybackToPrevious"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#setrepeatmode",children:"SetRepeatMode"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#setvolume",children:"SetVolume"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/player#setshuffle",children:"SetShuffle"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"playlists",children:"Playlists"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#getuserplaylists",children:"GetUserPlaylists"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#getplaylist",children:"GetPlaylist"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#getplaylisttracks",children:"GetPlaylistTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#createplaylist",children:"CreatePlaylist"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#updateplaylist",children:"UpdatePlaylist"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#replaceplaylisttracks",children:"ReplacePlaylistTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#removeplaylisttracks",children:"RemovePlaylistTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#removeplaylisttrack",children:"RemovePlaylistTrack"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#addplaylisttracks",children:"AddPlaylistTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#addplaylisttrack",children:"AddPlaylistTrack"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/playlists#reorderplaylist",children:"ReorderPlaylist"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"profiles",children:"Profiles"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/profiles#getpublicprofile",children:"GetPublicProfile"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/profiles#getprivateprofile",children:"GetPrivateProfile"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"search",children:"Search"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/search#searchitems",children:"SearchItems"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/search#searchitemsescaped",children:"SearchItemsEscaped"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"tracks",children:"Tracks"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/tracks#getseveraltracks",children:"GetSeveralTracks"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/tracks#gettrack",children:"GetTrack"})}),"\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/tracks#getaudioanalysis",children:"GetAudioAnalysis"})}),"\n"]}),"\n",(0,i.jsx)(s.h3,{id:"util",children:"Util"}),"\n",(0,i.jsxs)(s.ul,{children:["\n",(0,i.jsx)(s.li,{children:(0,i.jsx)(s.a,{href:"/SpotifyAPI-NET/docs/5.1.1/web/utilities",children:"Utility-Functions"})}),"\n"]})]})}function h(e={}){const{wrapper:s}={...(0,r.M)(),...e.components};return s?(0,i.jsx)(s,{...e,children:(0,i.jsx)(d,{...e})}):d(e)}},7052:(e,s,l)=>{l.d(s,{I:()=>a,M:()=>n});var i=l(6651);const r={},t=i.createContext(r);function n(e){const s=i.useContext(t);return i.useMemo((function(){return"function"==typeof e?e(s):{...s,...e}}),[s,e])}function a(e){let s;return s=e.disableParentContext?"function"==typeof e.components?e.components(r):e.components||r:n(e.components),i.createElement(t.Provider,{value:s},e.children)}}}]);