"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[2892],{3905:function(t,e,a){a.d(e,{Zo:function(){return m},kt:function(){return u}});var n=a(7294);function r(t,e,a){return e in t?Object.defineProperty(t,e,{value:a,enumerable:!0,configurable:!0,writable:!0}):t[e]=a,t}function l(t,e){var a=Object.keys(t);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(t);e&&(n=n.filter((function(e){return Object.getOwnPropertyDescriptor(t,e).enumerable}))),a.push.apply(a,n)}return a}function i(t){for(var e=1;e<arguments.length;e++){var a=null!=arguments[e]?arguments[e]:{};e%2?l(Object(a),!0).forEach((function(e){r(t,e,a[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(a)):l(Object(a)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(a,e))}))}return t}function p(t,e){if(null==t)return{};var a,n,r=function(t,e){if(null==t)return{};var a,n,r={},l=Object.keys(t);for(n=0;n<l.length;n++)a=l[n],e.indexOf(a)>=0||(r[a]=t[a]);return r}(t,e);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(t);for(n=0;n<l.length;n++)a=l[n],e.indexOf(a)>=0||Object.prototype.propertyIsEnumerable.call(t,a)&&(r[a]=t[a])}return r}var s=n.createContext({}),o=function(t){var e=n.useContext(s),a=e;return t&&(a="function"==typeof t?t(e):i(i({},e),t)),a},m=function(t){var e=o(t.components);return n.createElement(s.Provider,{value:e},t.children)},k={inlineCode:"code",wrapper:function(t){var e=t.children;return n.createElement(n.Fragment,{},e)}},d=n.forwardRef((function(t,e){var a=t.components,r=t.mdxType,l=t.originalType,s=t.parentName,m=p(t,["components","mdxType","originalType","parentName"]),d=o(a),u=r,N=d["".concat(s,".").concat(u)]||d[u]||k[u]||l;return a?n.createElement(N,i(i({ref:e},m),{},{components:a})):n.createElement(N,i({ref:e},m))}));function u(t,e){var a=arguments,r=e&&e.mdxType;if("string"==typeof t||r){var l=a.length,i=new Array(l);i[0]=d;var p={};for(var s in e)hasOwnProperty.call(e,s)&&(p[s]=e[s]);p.originalType=t,p.mdxType="string"==typeof t?t:r,i[1]=p;for(var o=2;o<l;o++)i[o]=a[o];return n.createElement.apply(null,i)}return n.createElement.apply(null,a)}d.displayName="MDXCreateElement"},2354:function(t,e,a){a.r(e),a.d(e,{assets:function(){return m},contentTitle:function(){return s},default:function(){return u},frontMatter:function(){return p},metadata:function(){return o},toc:function(){return k}});var n=a(7462),r=a(3366),l=(a(7294),a(3905)),i=["components"],p={id:"playlists",title:"Playlists",sidebar_label:"Playlists"},s=void 0,o={unversionedId:"web/playlists",id:"version-5.1.1/web/playlists",title:"Playlists",description:"GetUserPlaylists",source:"@site/versioned_docs/version-5.1.1/web/playlists.md",sourceDirName:"web",slug:"/web/playlists",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/playlists",draft:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/web/playlists.md",tags:[],version:"5.1.1",lastUpdatedBy:"Sascha Kiefer",lastUpdatedAt:1660200849,formattedLastUpdatedAt:"8/11/2022",frontMatter:{id:"playlists",title:"Playlists",sidebar_label:"Playlists"},sidebar:"version-5.1.1/someSidebar",previous:{title:"Player",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/player"},next:{title:"Profiles",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/profiles"}},m={},k=[{value:"GetUserPlaylists",id:"getuserplaylists",level:2},{value:"GetPlaylist",id:"getplaylist",level:2},{value:"GetPlaylistTracks",id:"getplaylisttracks",level:2},{value:"CreatePlaylist",id:"createplaylist",level:2},{value:"UpdatePlaylist",id:"updateplaylist",level:2},{value:"ReplacePlaylistTracks",id:"replaceplaylisttracks",level:2},{value:"RemovePlaylistTracks",id:"removeplaylisttracks",level:2},{value:"RemovePlaylistTrack",id:"removeplaylisttrack",level:2},{value:"AddPlaylistTracks",id:"addplaylisttracks",level:2},{value:"AddPlaylistTrack",id:"addplaylisttrack",level:2},{value:"ReorderPlaylist",id:"reorderplaylist",level:2}],d={toc:k};function u(t){var e=t.components,a=(0,r.Z)(t,i);return(0,l.kt)("wrapper",(0,n.Z)({},d,a,{components:e,mdxType:"MDXLayout"}),(0,l.kt)("h2",{id:"getuserplaylists"},"GetUserPlaylists"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Get a list of the playlists owned or followed by a Spotify user.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[limit]"),(0,l.kt)("td",{parentName:"tr",align:null},"The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"20"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[offset]"),(0,l.kt)("td",{parentName:"tr",align:null},"The index of the first playlist to return. Default: 0 (the first object)"),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"0"))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("a",{parentName:"p",href:"https://developer.spotify.com/web-api/object-model/#playlist-object-simplified"},"SimplePlaylist")," wrapped inside a ",(0,l.kt)("a",{parentName:"p",href:"https://developer.spotify.com/web-api/object-model/#paging-object"},"Paging Object")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'Paging<SimplePlaylist> userPlaylists = _spotify.GetUserPlaylists("1122095781");\nuserPlaylists.Items.ForEach(playlist => playlist.Owner.DisplayName) //Who is the owner of the playlist?\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"getplaylist"},"GetPlaylist"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Get a playlist owned by a Spotify user.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[fields]"),(0,l.kt)("td",{parentName:"tr",align:null},"Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"description,uri"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[market]"),(0,l.kt)("td",{parentName:"tr",align:null},"An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking."),(0,l.kt)("td",{parentName:"tr",align:null},'"DE"')))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("a",{parentName:"p",href:"https://developer.spotify.com/web-api/object-model/#track-object-full"},"FullTrack")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'FullPlaylist playlist = _spotify.GetPlaylist("1122095781", "1TtEejT1y4D1WmcOnLfha2");\nplaylist.Tracks.Items.ForEach(track => Console.WriteLine(track.Track.Name));\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"getplaylisttracks"},"GetPlaylistTracks"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Get full details of the tracks of a playlist owned by a Spotify user.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[fields]"),(0,l.kt)("td",{parentName:"tr",align:null},"Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"description,uri"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[limit]"),(0,l.kt)("td",{parentName:"tr",align:null},"The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"100"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[offset]"),(0,l.kt)("td",{parentName:"tr",align:null},"The index of the first object to return. Default: 0 (i.e., the first object)"),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"0"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[market]"),(0,l.kt)("td",{parentName:"tr",align:null},"An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"DE"))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("a",{parentName:"p",href:"https://developer.spotify.com/web-api/object-model/#playlist-object-simplified"},"PlaylistTrack")," wrapped inside a ",(0,l.kt)("a",{parentName:"p",href:"https://developer.spotify.com/web-api/object-model/#paging-object"},"Paging Object")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'Paging<PlaylistTrack> playlist = _spotify.GetPlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2");\nplaylist.Items.ForEach(track => Console.WriteLine(track.Track.Name));\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"createplaylist"},"CreatePlaylist"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Create a playlist for a Spotify user. (The playlist will be empty until you add tracks.)")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistName"),(0,l.kt)("td",{parentName:"tr",align:null},'The name for the new playlist, for example "Your Coolest Playlist". This name does not need to be unique.'),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"This is my new Playlist"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[isPublic]"),(0,l.kt)("td",{parentName:"tr",align:null},"default true. If true the playlist will be public, if false it will be private. To be able to create private playlists, the user must have granted the playlist-modify-private scope."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"true"))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("a",{parentName:"p",href:"https://developer.spotify.com/web-api/object-model/#playlist-object-full"},"FullPlaylist")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'FullPlaylist playlist = _spotify.CreatePlaylist("1122095781", "This is my new Playlist");\nif(!playlist.HasError())\n    Console.WriteLine("Playlist-URI: " + playlist.Uri);\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"updateplaylist"},"UpdatePlaylist"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Change a playlist\u2019s name and public/private state. (The user must, of course, own the playlist.)")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[newName]"),(0,l.kt)("td",{parentName:"tr",align:null},'The new name for the playlist, for example "My New Playlist Title".'),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"New Playlistname"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[newPublic]"),(0,l.kt)("td",{parentName:"tr",align:null},"If true the playlist will be public, if false it will be private."),(0,l.kt)("td",{parentName:"tr",align:null},"EXAMPLE")))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"ErrorResponse")," which just contains a possible error. (",(0,l.kt)("inlineCode",{parentName:"p"},"response.HasError()")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"response.Error"),")"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'ErrorResponse response = _spotify.UpdatePlaylist("1122095781", "1TtEejT1y4D1WmcOnLfha2", "New Name", true);\nif(!response.HasError())\n    Console.WriteLine("success");\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"replaceplaylisttracks"},"ReplacePlaylistTracks"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Replace all the tracks in a playlist, overwriting its existing tracks. This powerful request can be useful for replacing tracks, re-ordering existing tracks, or clearing the playlist.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"uris"),(0,l.kt)("td",{parentName:"tr",align:null},"A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'new List<string> { "1ri6UZpjPLmTCswIXZ6Uq1" }'))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"ErrorResponse")," which just contains a possible error. (",(0,l.kt)("inlineCode",{parentName:"p"},"response.HasError()")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"response.Error"),")"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'ErrorResponse response = _spotify.ReplacePlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2", new List<string> { "1ri6UZpjPLmTCswIXZ6Uq1" });\nif(!response.HasError())\n    Console.WriteLine("success");\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"removeplaylisttracks"},"RemovePlaylistTracks"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Remove one or more tracks from a user\u2019s playlist.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"uris"),(0,l.kt)("td",{parentName:"tr",align:null},"array of objects containing Spotify URI strings (and their position in the playlist). A maximum of 100 objects can be sent at once."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"(example below)"))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"ErrorResponse")," which just contains a possible error. (",(0,l.kt)("inlineCode",{parentName:"p"},"response.HasError()")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"response.Error"),")"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'//Remove multiple tracks\nErrorResponse playlist = _spotify.RemovePlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2", new List<DeleteTrackUri>()\n{\n    new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1"),\n    new DeleteTrackUri("47xtGU3vht7mXLHqnbaau5")\n});\n//Remove multiple tracks at their specified positions\nErrorResponse playlist = _spotify.RemovePlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2", new List<DeleteTrackUri>()\n{\n    new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1", 2),\n    new DeleteTrackUri("47xtGU3vht7mXLHqnbaau5", 0, 50)\n});\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"removeplaylisttrack"},"RemovePlaylistTrack"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Remove one or more tracks from a user\u2019s playlist.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"uri"),(0,l.kt)("td",{parentName:"tr",align:null},"Spotify URI"),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1")'))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"ErrorResponse")," which just contains a possible error. (",(0,l.kt)("inlineCode",{parentName:"p"},"response.HasError()")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"response.Error"),")"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'//Remove all tracks with the specified URI\nErrorResponse response = _spotify.RemovePlaylistTrack("1122095781", "1TtEejT1y4D1WmcOnLfha2", new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1"));\n//Remove all tracks with the specified URI and the specified positions\nErrorResponse response = _spotify.RemovePlaylistTrack("1122095781", "1TtEejT1y4D1WmcOnLfha2", new DeleteTrackUri("1ri6UZpjPLmTCswIXZ6Uq1", 0, 10, 20));\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"addplaylisttracks"},"AddPlaylistTracks"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Add one or more tracks to a user\u2019s playlist.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"uris"),(0,l.kt)("td",{parentName:"tr",align:null},"A list of Spotify track URIs to add"),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'new List<string> { "1ri6UZpjPLmTCswIXZ6Uq1" }'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[position]"),(0,l.kt)("td",{parentName:"tr",align:null},"The position to insert the tracks, a zero-based index"),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"10"))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"ErrorResponse")," which just contains a possible error. (",(0,l.kt)("inlineCode",{parentName:"p"},"response.HasError()")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"response.Error"),")"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'ErrorResponse response = _spotify.AddPlaylistTracks("1122095781", "1TtEejT1y4D1WmcOnLfha2", new List<string> { "1ri6UZpjPLmTCswIXZ6Uq1" });\nif(!response.HasError())\n    Console.WriteLine("Success");\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"addplaylisttrack"},"AddPlaylistTrack"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Add one or more tracks to a user\u2019s playlist.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"uri"),(0,l.kt)("td",{parentName:"tr",align:null},"A Spotify Track URI"),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1ri6UZpjPLmTCswIXZ6Uq1"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"position"),(0,l.kt)("td",{parentName:"tr",align:null},"The position to insert the tracks, a zero-based index"),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"10"))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"ErrorResponse")," which just contains a possible error. (",(0,l.kt)("inlineCode",{parentName:"p"},"response.HasError()")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"response.Error"),")"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'ErrorResponse response = _spotify.AddPlaylistTrack("1122095781", "1TtEejT1y4D1WmcOnLfha2", "1ri6UZpjPLmTCswIXZ6Uq1");\nif(!response.HasError())\n    Console.WriteLine("Success");\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"reorderplaylist"},"ReorderPlaylist"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Reorder a track or a group of tracks in a playlist.\nMore Info: ",(0,l.kt)("a",{parentName:"p",href:"https://developer.spotify.com/web-api/reorder-playlists-tracks/"},"Reorder-Playlist"))),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"userId"),(0,l.kt)("td",{parentName:"tr",align:null},"The user's Spotify user ID."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1122095781"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"playlistId"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the playlist."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"1TtEejT1y4D1WmcOnLfha2"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"rangeStart"),(0,l.kt)("td",{parentName:"tr",align:null},"The position of the first track to be reordered."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"2"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"insertBefore"),(0,l.kt)("td",{parentName:"tr",align:null},"The position where the tracks should be inserted."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"0"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[rangeLength]"),(0,l.kt)("td",{parentName:"tr",align:null},"The amount of tracks to be reordered. Defaults to 1 if not set."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"2"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[snapshotId]"),(0,l.kt)("td",{parentName:"tr",align:null},"The playlist's snapshot ID against which you want to make the changes."),(0,l.kt)("td",{parentName:"tr",align:null},"``")))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"Snapshot"),"-Object which contains the property ",(0,l.kt)("inlineCode",{parentName:"p"},"String SnapshotId")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'Snapshot snapshot = _spotify.ReorderPlaylist("1122095781", "1TtEejT1y4D1WmcOnLfha2", 2, 0, 2);\nConsole.WriteLine("New SnapshotId: " + snapshot.SnapshotId);\n')),(0,l.kt)("hr",null))}u.isMDXComponent=!0}}]);