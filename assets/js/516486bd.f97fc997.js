"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[4742],{3905:function(t,e,a){a.d(e,{Zo:function(){return s},kt:function(){return d}});var r=a(7294);function n(t,e,a){return e in t?Object.defineProperty(t,e,{value:a,enumerable:!0,configurable:!0,writable:!0}):t[e]=a,t}function l(t,e){var a=Object.keys(t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(t);e&&(r=r.filter((function(e){return Object.getOwnPropertyDescriptor(t,e).enumerable}))),a.push.apply(a,r)}return a}function i(t){for(var e=1;e<arguments.length;e++){var a=null!=arguments[e]?arguments[e]:{};e%2?l(Object(a),!0).forEach((function(e){n(t,e,a[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(a)):l(Object(a)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(a,e))}))}return t}function o(t,e){if(null==t)return{};var a,r,n=function(t,e){if(null==t)return{};var a,r,n={},l=Object.keys(t);for(r=0;r<l.length;r++)a=l[r],e.indexOf(a)>=0||(n[a]=t[a]);return n}(t,e);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(t);for(r=0;r<l.length;r++)a=l[r],e.indexOf(a)>=0||Object.prototype.propertyIsEnumerable.call(t,a)&&(n[a]=t[a])}return n}var p=r.createContext({}),c=function(t){var e=r.useContext(p),a=e;return t&&(a="function"==typeof t?t(e):i(i({},e),t)),a},s=function(t){var e=c(t.components);return r.createElement(p.Provider,{value:e},t.children)},u={inlineCode:"code",wrapper:function(t){var e=t.children;return r.createElement(r.Fragment,{},e)}},k=r.forwardRef((function(t,e){var a=t.components,n=t.mdxType,l=t.originalType,p=t.parentName,s=o(t,["components","mdxType","originalType","parentName"]),k=c(a),d=n,m=k["".concat(p,".").concat(d)]||k[d]||u[d]||l;return a?r.createElement(m,i(i({ref:e},s),{},{components:a})):r.createElement(m,i({ref:e},s))}));function d(t,e){var a=arguments,n=e&&e.mdxType;if("string"==typeof t||n){var l=a.length,i=new Array(l);i[0]=k;var o={};for(var p in e)hasOwnProperty.call(e,p)&&(o[p]=e[p]);o.originalType=t,o.mdxType="string"==typeof t?t:n,i[1]=o;for(var c=2;c<l;c++)i[c]=a[c];return r.createElement.apply(null,i)}return r.createElement.apply(null,a)}k.displayName="MDXCreateElement"},5042:function(t,e,a){a.r(e),a.d(e,{frontMatter:function(){return i},contentTitle:function(){return o},metadata:function(){return p},toc:function(){return c},default:function(){return u}});var r=a(3117),n=a(102),l=(a(7294),a(3905)),i={id:"tracks",title:"Tracks",sidebar_label:"Tracks"},o=void 0,p={unversionedId:"web/tracks",id:"version-5.1.1/web/tracks",isDocsHomePage:!1,title:"Tracks",description:"GetSeveralTracks",source:"@site/versioned_docs/version-5.1.1/web/tracks.md",sourceDirName:"web",slug:"/web/tracks",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/tracks",editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/web/tracks.md",version:"5.1.1",lastUpdatedBy:"Alex Yeo",lastUpdatedAt:1652933184,formattedLastUpdatedAt:"5/19/2022",frontMatter:{id:"tracks",title:"Tracks",sidebar_label:"Tracks"},sidebar:"version-5.1.1/someSidebar",previous:{title:"Search",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/search"},next:{title:"Utilities",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/utilities"}},c=[{value:"GetSeveralTracks",id:"getseveraltracks",children:[]},{value:"GetTrack",id:"gettrack",children:[]},{value:"GetAudioAnalysis",id:"getaudioanalysis",children:[]}],s={toc:c};function u(t){var e=t.components,a=(0,n.Z)(t,["components"]);return(0,l.kt)("wrapper",(0,r.Z)({},s,a,{components:e,mdxType:"MDXLayout"}),(0,l.kt)("h2",{id:"getseveraltracks"},"GetSeveralTracks"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Get Spotify catalog information for multiple tracks based on their Spotify IDs.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"ids"),(0,l.kt)("td",{parentName:"tr",align:null},"A list of the Spotify IDs for the tracks. Maximum: 50 IDs."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'new List<String> {"6Y1CLPwYe7zvI8PJiWVz6T"}'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"market"),(0,l.kt)("td",{parentName:"tr",align:null},"An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"DE"'))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"SeveralTracks")," object which has one property, ",(0,l.kt)("inlineCode",{parentName:"p"},"List<FullTrack> Tracks")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'SeveralTracks severalTracks = _spotify.GetSeveralTracks(new List<String> {"6Y1CLPwYe7zvI8PJiWVz6T"});\nseveralTracks.Tracks.ForEach(track => Console.WriteLine(track.Name));\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"gettrack"},"GetTrack"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Get Spotify catalog information for a single track identified by its unique Spotify ID.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"id"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the track."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"6Y1CLPwYe7zvI8PJiWVz6T"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"market"),(0,l.kt)("td",{parentName:"tr",align:null},"An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"DE"'))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("a",{parentName:"p",href:"https://developer.spotify.com/web-api/object-model/#track-object-full"},"FullTrack")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'FullTrack track = _spotify.GetTrack("6Y1CLPwYe7zvI8PJiWVz6T");\nConsole.WriteLine(track.Name);\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"getaudioanalysis"},"GetAudioAnalysis"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Get a detailed audio analysis for a single track identified by its unique Spotify ID.")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"id"),(0,l.kt)("td",{parentName:"tr",align:null},"The Spotify ID for the track."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"6Y1CLPwYe7zvI8PJiWVz6T"'))))),(0,l.kt)("p",null,"Returns a AudioAnalysis. This object is currently lacking Spotify documentation but archived ",(0,l.kt)("a",{parentName:"p",href:"https://web.archive.org/web/20160528174915/http://developer.echonest.com/docs/v4/_static/AnalyzeDocumentation.pdf"},"EchoNest documentation")," is relevant."),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'AudioAnalysis analysis = _spotify.GetAudioAnalysis("6Y1CLPwYe7zvI8PJiWVz6T");\nConsole.WriteLine(analysis.Meta.DetailedStatus);\n')))}u.isMDXComponent=!0}}]);