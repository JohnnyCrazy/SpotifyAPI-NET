"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[5792],{1648:(e,s,r)=>{r.r(s),r.d(s,{assets:()=>t,contentTitle:()=>c,default:()=>h,frontMatter:()=>d,metadata:()=>l,toc:()=>o});var n=r(2488),i=r(7052);const d={id:"library",title:"Library",sidebar_label:"Library"},c=void 0,l={id:"web/library",title:"Library",description:"SaveTracks",source:"@site/versioned_docs/version-5.1.1/web/library.md",sourceDirName:"web",slug:"/web/library",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/library",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/web/library.md",tags:[],version:"5.1.1",lastUpdatedBy:"Sam",lastUpdatedAt:1715116722,formattedLastUpdatedAt:"May 7, 2024",frontMatter:{id:"library",title:"Library",sidebar_label:"Library"},sidebar:"someSidebar",previous:{title:"Follow",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/follow"},next:{title:"Personalization",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/personalization"}},t={},o=[{value:"SaveTracks",id:"savetracks",level:2},{value:"SaveTrack",id:"savetrack",level:2},{value:"GetSavedTracks",id:"getsavedtracks",level:2},{value:"RemoveSavedTracks",id:"removesavedtracks",level:2},{value:"CheckSavedTracks",id:"checksavedtracks",level:2},{value:"SaveAlbums",id:"savealbums",level:2},{value:"SaveAlbum",id:"savealbum",level:2},{value:"GetSavedAlbums",id:"getsavedalbums",level:2},{value:"RemoveSavedAlbums",id:"removesavedalbums",level:2},{value:"CheckSavedAlbums",id:"checksavedalbums",level:2}];function a(e){const s={blockquote:"blockquote",code:"code",h2:"h2",hr:"hr",p:"p",pre:"pre",strong:"strong",table:"table",tbody:"tbody",td:"td",th:"th",thead:"thead",tr:"tr",...(0,i.M)(),...e.components};return(0,n.jsxs)(n.Fragment,{children:[(0,n.jsx)(s.h2,{id:"savetracks",children:"SaveTracks"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Save one or more tracks to the current user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsx)(s.tbody,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"ids"}),(0,n.jsx)(s.td,{children:"A list of the Spotify IDs"}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:'new List<String> { "3Hvu1pq89D4R0lyPBoujSv" }'})})]})})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"ErrorResponse"})," which just contains a possible error. (",(0,n.jsx)(s.code,{children:"response.HasError()"})," and ",(0,n.jsx)(s.code,{children:"response.Error"}),")"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:'ErrorResponse response = _spotify.SaveTracks(new List<string> { "3Hvu1pq89D4R0lyPBoujSv" });\nif(!response.HasError())\n    Console.WriteLine("success");\n'})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"savetrack",children:"SaveTrack"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Save one track to the current user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsx)(s.tbody,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"id"}),(0,n.jsx)(s.td,{children:"A Spotify ID"}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:'"3Hvu1pq89D4R0lyPBoujSv"'})})]})})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"ErrorResponse"})," which just contains a possible error. (",(0,n.jsx)(s.code,{children:"response.HasError()"})," and ",(0,n.jsx)(s.code,{children:"response.Error"}),")"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:'ErrorResponse response = _spotify.SaveTrack("3Hvu1pq89D4R0lyPBoujSv");\nif(!response.HasError())\n    Console.WriteLine("success");\n'})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"getsavedtracks",children:"GetSavedTracks"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Get a list of the songs saved in the current Spotify user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsxs)(s.tbody,{children:[(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"[limit]"}),(0,n.jsx)(s.td,{children:"The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50."}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:"20"})})]}),(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"[offset]"}),(0,n.jsx)(s.td,{children:"The index of the first object to return. Default: 0 (i.e., the first object)"}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:"0"})})]}),(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"[market]"}),(0,n.jsx)(s.td,{children:"An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking."}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:"DE"})})]})]})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"Paging<SavedTrack>**, **SavedTrack"})," contains 2 properties, ",(0,n.jsx)(s.code,{children:"DateTime AddedAt"})," and ",(0,n.jsx)(s.code,{children:"FullTrack Track"})]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:"Paging<SavedTrack> savedTracks = _spotify.GetSavedTracks();\nsavedTracks.Items.ForEach(track => Console.WriteLine(track.Track.Name));\n"})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"removesavedtracks",children:"RemoveSavedTracks"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Remove one or more tracks from the current user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsx)(s.tbody,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"ids"}),(0,n.jsx)(s.td,{children:"A list of the Spotify IDs."}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:'new List<String> { "3Hvu1pq89D4R0lyPBoujSv" }'})})]})})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"ErrorResponse"})," which just contains a possible error. (",(0,n.jsx)(s.code,{children:"response.HasError()"})," and ",(0,n.jsx)(s.code,{children:"response.Error"}),")"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:'ErrorResponse response = _spotify.RemoveSavedTracks(new List<string> { "3Hvu1pq89D4R0lyPBoujSv" });\nif(!response.HasError())\n    Console.WriteLine("success");\n'})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"checksavedtracks",children:"CheckSavedTracks"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Check if one or more tracks is already saved in the current Spotify user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsx)(s.tbody,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"ids"}),(0,n.jsx)(s.td,{children:"A list of the Spotify IDs."}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:'new List<String> { "3Hvu1pq89D4R0lyPBoujSv" }'})})]})})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"ListResponse<bool>"})," which contains a property, ",(0,n.jsx)(s.code,{children:"List<bool> List"})]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:'ListResponse<bool> tracksSaved = _spotify.CheckSavedTracks(new List<String> { "3Hvu1pq89D4R0lyPBoujSv" });\nif(tracksSaved.List[0])\n    Console.WriteLine("The track is in your library!");\n'})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"savealbums",children:"SaveAlbums"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Save one or more albums to the current user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsx)(s.tbody,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"ids"}),(0,n.jsx)(s.td,{children:"A list of the Spotify IDs"}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:'new List<String> { "1cq06d0kTUnFmJHixz1RaF" }'})})]})})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"ErrorResponse"})," which just contains a possible error. (",(0,n.jsx)(s.code,{children:"response.HasError()"})," and ",(0,n.jsx)(s.code,{children:"response.Error"}),")"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:'ErrorResponse response = _spotify.SaveAlbums(new List<string> { "1cq06d0kTUnFmJHixz1RaF" });\nif(!response.HasError())\n    Console.WriteLine("success");\n'})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"savealbum",children:"SaveAlbum"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Save one album to the current user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsx)(s.tbody,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"id"}),(0,n.jsx)(s.td,{children:"A Spotify ID"}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:'"1cq06d0kTUnFmJHixz1RaF"'})})]})})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"ErrorResponse"})," which just contains a possible error. (",(0,n.jsx)(s.code,{children:"response.HasError()"})," and ",(0,n.jsx)(s.code,{children:"response.Error"}),")"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:'ErrorResponse response = _spotify.SaveAlbum("1cq06d0kTUnFmJHixz1RaF");\nif(!response.HasError())\n    Console.WriteLine("success");\n'})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"getsavedalbums",children:"GetSavedAlbums"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Get a list of the albums saved in the current Spotify user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsxs)(s.tbody,{children:[(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"[limit]"}),(0,n.jsx)(s.td,{children:"The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50."}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:"20"})})]}),(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"[offset]"}),(0,n.jsx)(s.td,{children:"The index of the first object to return. Default: 0 (i.e., the first object)"}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:"0"})})]}),(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"[market]"}),(0,n.jsx)(s.td,{children:"An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking."}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:"DE"})})]})]})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"Paging<SavedAlbum>"}),", ",(0,n.jsx)(s.strong,{children:"SavedAlbum"})," contains 2 properties, ",(0,n.jsx)(s.code,{children:"DateTime AddedAt"})," and ",(0,n.jsx)(s.code,{children:"FullAlbum Album"})]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:"Paging<SavedAlbum> savedAlbums = _spotify.GetSavedAlbums();\nsavedAlbums.Items.ForEach(album => Console.WriteLine(album.Album.Name));\n"})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"removesavedalbums",children:"RemoveSavedAlbums"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Remove one or more albums from the current user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsx)(s.tbody,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"ids"}),(0,n.jsx)(s.td,{children:"A list of the Spotify IDs."}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:'new List<String> { "1cq06d0kTUnFmJHixz1RaF" }'})})]})})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"ErrorResponse"})," which just contains a possible error. (",(0,n.jsx)(s.code,{children:"response.HasError()"})," and ",(0,n.jsx)(s.code,{children:"response.Error"}),")"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:'ErrorResponse response = _spotify.RemoveSavedAlbums(new List<string> { "1cq06d0kTUnFmJHixz1RaF" });\nif(!response.HasError())\n    Console.WriteLine("success");\n'})}),"\n",(0,n.jsx)(s.hr,{}),"\n",(0,n.jsx)(s.h2,{id:"checksavedalbums",children:"CheckSavedAlbums"}),"\n",(0,n.jsxs)(s.blockquote,{children:["\n",(0,n.jsx)(s.p,{children:"Check if one or more albums is already saved in the current Spotify user\u2019s \u201cYour Music\u201d library."}),"\n"]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Parameters"})}),"\n",(0,n.jsxs)(s.table,{children:[(0,n.jsx)(s.thead,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.th,{children:"Name"}),(0,n.jsx)(s.th,{children:"Description"}),(0,n.jsx)(s.th,{children:"Example"})]})}),(0,n.jsx)(s.tbody,{children:(0,n.jsxs)(s.tr,{children:[(0,n.jsx)(s.td,{children:"ids"}),(0,n.jsx)(s.td,{children:"A list of the Spotify IDs."}),(0,n.jsx)(s.td,{children:(0,n.jsx)(s.code,{children:'new List<String> { "1cq06d0kTUnFmJHixz1RaF" }'})})]})})]}),"\n",(0,n.jsxs)(s.p,{children:["Returns a ",(0,n.jsx)(s.code,{children:"ListResponse<bool>"})," which contains a property, ",(0,n.jsx)(s.code,{children:"List<bool> List"})]}),"\n",(0,n.jsx)(s.p,{children:(0,n.jsx)(s.strong,{children:"Usage"})}),"\n",(0,n.jsx)(s.pre,{children:(0,n.jsx)(s.code,{className:"language-csharp",children:'ListResponse<bool> albumsSaved = _spotify.CheckSavedAlbums(new List<String> { "1cq06d0kTUnFmJHixz1RaF" });\nif(albumsSaved.List[0])\n    Console.WriteLine("The album is in your library!");\n'})}),"\n",(0,n.jsx)(s.hr,{})]})}function h(e={}){const{wrapper:s}={...(0,i.M)(),...e.components};return s?(0,n.jsx)(s,{...e,children:(0,n.jsx)(a,{...e})}):a(e)}},7052:(e,s,r)=>{r.d(s,{I:()=>l,M:()=>c});var n=r(6651);const i={},d=n.createContext(i);function c(e){const s=n.useContext(d);return n.useMemo((function(){return"function"==typeof e?e(s):{...s,...e}}),[s,e])}function l(e){let s;return s=e.disableParentContext?"function"==typeof e.components?e.components(i):e.components||i:c(e.components),n.createElement(d.Provider,{value:s},e.children)}}}]);