"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[4232],{6424:(e,t,s)=>{s.r(t),s.d(t,{assets:()=>d,contentTitle:()=>c,default:()=>h,frontMatter:()=>i,metadata:()=>a,toc:()=>l});var r=s(2488),n=s(7052);const i={id:"tracks",title:"Tracks",sidebar_label:"Tracks"},c=void 0,a={id:"web/tracks",title:"Tracks",description:"GetSeveralTracks",source:"@site/versioned_docs/version-5.1.1/web/tracks.md",sourceDirName:"web",slug:"/web/tracks",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/tracks",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/web/tracks.md",tags:[],version:"5.1.1",lastUpdatedBy:"XY Wang",lastUpdatedAt:1715323874,formattedLastUpdatedAt:"May 10, 2024",frontMatter:{id:"tracks",title:"Tracks",sidebar_label:"Tracks"},sidebar:"someSidebar",previous:{title:"Search",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/search"},next:{title:"Utilities",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/utilities"}},d={},l=[{value:"GetSeveralTracks",id:"getseveraltracks",level:2},{value:"GetTrack",id:"gettrack",level:2},{value:"GetAudioAnalysis",id:"getaudioanalysis",level:2}];function o(e){const t={a:"a",blockquote:"blockquote",code:"code",h2:"h2",hr:"hr",p:"p",pre:"pre",strong:"strong",table:"table",tbody:"tbody",td:"td",th:"th",thead:"thead",tr:"tr",...(0,n.M)(),...e.components};return(0,r.jsxs)(r.Fragment,{children:[(0,r.jsx)(t.h2,{id:"getseveraltracks",children:"GetSeveralTracks"}),"\n",(0,r.jsxs)(t.blockquote,{children:["\n",(0,r.jsx)(t.p,{children:"Get Spotify catalog information for multiple tracks based on their Spotify IDs."}),"\n"]}),"\n",(0,r.jsx)(t.p,{children:(0,r.jsx)(t.strong,{children:"Parameters"})}),"\n",(0,r.jsxs)(t.table,{children:[(0,r.jsx)(t.thead,{children:(0,r.jsxs)(t.tr,{children:[(0,r.jsx)(t.th,{children:"Name"}),(0,r.jsx)(t.th,{children:"Description"}),(0,r.jsx)(t.th,{children:"Example"})]})}),(0,r.jsxs)(t.tbody,{children:[(0,r.jsxs)(t.tr,{children:[(0,r.jsx)(t.td,{children:"ids"}),(0,r.jsx)(t.td,{children:"A list of the Spotify IDs for the tracks. Maximum: 50 IDs."}),(0,r.jsx)(t.td,{children:(0,r.jsx)(t.code,{children:'new List<String> {"6Y1CLPwYe7zvI8PJiWVz6T"}'})})]}),(0,r.jsxs)(t.tr,{children:[(0,r.jsx)(t.td,{children:"market"}),(0,r.jsx)(t.td,{children:"An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking."}),(0,r.jsx)(t.td,{children:(0,r.jsx)(t.code,{children:'"DE"'})})]})]})]}),"\n",(0,r.jsxs)(t.p,{children:["Returns a ",(0,r.jsx)(t.code,{children:"SeveralTracks"})," object which has one property, ",(0,r.jsx)(t.code,{children:"List<FullTrack> Tracks"})]}),"\n",(0,r.jsx)(t.p,{children:(0,r.jsx)(t.strong,{children:"Usage"})}),"\n",(0,r.jsx)(t.pre,{children:(0,r.jsx)(t.code,{className:"language-csharp",children:'SeveralTracks severalTracks = _spotify.GetSeveralTracks(new List<String> {"6Y1CLPwYe7zvI8PJiWVz6T"});\nseveralTracks.Tracks.ForEach(track => Console.WriteLine(track.Name));\n'})}),"\n",(0,r.jsx)(t.hr,{}),"\n",(0,r.jsx)(t.h2,{id:"gettrack",children:"GetTrack"}),"\n",(0,r.jsxs)(t.blockquote,{children:["\n",(0,r.jsx)(t.p,{children:"Get Spotify catalog information for a single track identified by its unique Spotify ID."}),"\n"]}),"\n",(0,r.jsx)(t.p,{children:(0,r.jsx)(t.strong,{children:"Parameters"})}),"\n",(0,r.jsxs)(t.table,{children:[(0,r.jsx)(t.thead,{children:(0,r.jsxs)(t.tr,{children:[(0,r.jsx)(t.th,{children:"Name"}),(0,r.jsx)(t.th,{children:"Description"}),(0,r.jsx)(t.th,{children:"Example"})]})}),(0,r.jsxs)(t.tbody,{children:[(0,r.jsxs)(t.tr,{children:[(0,r.jsx)(t.td,{children:"id"}),(0,r.jsx)(t.td,{children:"The Spotify ID for the track."}),(0,r.jsx)(t.td,{children:(0,r.jsx)(t.code,{children:'"6Y1CLPwYe7zvI8PJiWVz6T"'})})]}),(0,r.jsxs)(t.tr,{children:[(0,r.jsx)(t.td,{children:"market"}),(0,r.jsx)(t.td,{children:"An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking."}),(0,r.jsx)(t.td,{children:(0,r.jsx)(t.code,{children:'"DE"'})})]})]})]}),"\n",(0,r.jsxs)(t.p,{children:["Returns a ",(0,r.jsx)(t.a,{href:"https://developer.spotify.com/web-api/object-model/#track-object-full",children:"FullTrack"})]}),"\n",(0,r.jsx)(t.p,{children:(0,r.jsx)(t.strong,{children:"Usage"})}),"\n",(0,r.jsx)(t.pre,{children:(0,r.jsx)(t.code,{className:"language-csharp",children:'FullTrack track = _spotify.GetTrack("6Y1CLPwYe7zvI8PJiWVz6T");\nConsole.WriteLine(track.Name);\n'})}),"\n",(0,r.jsx)(t.hr,{}),"\n",(0,r.jsx)(t.h2,{id:"getaudioanalysis",children:"GetAudioAnalysis"}),"\n",(0,r.jsxs)(t.blockquote,{children:["\n",(0,r.jsx)(t.p,{children:"Get a detailed audio analysis for a single track identified by its unique Spotify ID."}),"\n"]}),"\n",(0,r.jsx)(t.p,{children:(0,r.jsx)(t.strong,{children:"Parameters"})}),"\n",(0,r.jsxs)(t.table,{children:[(0,r.jsx)(t.thead,{children:(0,r.jsxs)(t.tr,{children:[(0,r.jsx)(t.th,{children:"Name"}),(0,r.jsx)(t.th,{children:"Description"}),(0,r.jsx)(t.th,{children:"Example"})]})}),(0,r.jsx)(t.tbody,{children:(0,r.jsxs)(t.tr,{children:[(0,r.jsx)(t.td,{children:"id"}),(0,r.jsx)(t.td,{children:"The Spotify ID for the track."}),(0,r.jsx)(t.td,{children:(0,r.jsx)(t.code,{children:'"6Y1CLPwYe7zvI8PJiWVz6T"'})})]})})]}),"\n",(0,r.jsxs)(t.p,{children:["Returns a AudioAnalysis. This object is currently lacking Spotify documentation but archived ",(0,r.jsx)(t.a,{href:"https://web.archive.org/web/20160528174915/http://developer.echonest.com/docs/v4/_static/AnalyzeDocumentation.pdf",children:"EchoNest documentation"})," is relevant."]}),"\n",(0,r.jsx)(t.p,{children:(0,r.jsx)(t.strong,{children:"Usage"})}),"\n",(0,r.jsx)(t.pre,{children:(0,r.jsx)(t.code,{className:"language-csharp",children:'AudioAnalysis analysis = _spotify.GetAudioAnalysis("6Y1CLPwYe7zvI8PJiWVz6T");\nConsole.WriteLine(analysis.Meta.DetailedStatus);\n'})})]})}function h(e={}){const{wrapper:t}={...(0,n.M)(),...e.components};return t?(0,r.jsx)(t,{...e,children:(0,r.jsx)(o,{...e})}):o(e)}},7052:(e,t,s)=>{s.d(t,{I:()=>a,M:()=>c});var r=s(6651);const n={},i=r.createContext(n);function c(e){const t=r.useContext(i);return r.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function a(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(n):e.components||n:c(e.components),r.createElement(i.Provider,{value:t},e.children)}}}]);