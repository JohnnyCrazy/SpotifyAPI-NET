"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[5343],{3905:function(e,t,r){r.d(t,{Zo:function(){return c},kt:function(){return d}});var n=r(7294);function a(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}function l(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function i(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?l(Object(r),!0).forEach((function(t){a(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):l(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function o(e,t){if(null==e)return{};var r,n,a=function(e,t){if(null==e)return{};var r,n,a={},l=Object.keys(e);for(n=0;n<l.length;n++)r=l[n],t.indexOf(r)>=0||(a[r]=e[r]);return a}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(n=0;n<l.length;n++)r=l[n],t.indexOf(r)>=0||Object.prototype.propertyIsEnumerable.call(e,r)&&(a[r]=e[r])}return a}var s=n.createContext({}),p=function(e){var t=n.useContext(s),r=t;return e&&(r="function"==typeof e?e(t):i(i({},t),e)),r},c=function(e){var t=p(e.components);return n.createElement(s.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},m=n.forwardRef((function(e,t){var r=e.components,a=e.mdxType,l=e.originalType,s=e.parentName,c=o(e,["components","mdxType","originalType","parentName"]),m=p(r),d=a,k=m["".concat(s,".").concat(d)]||m[d]||u[d]||l;return r?n.createElement(k,i(i({ref:t},c),{},{components:r})):n.createElement(k,i({ref:t},c))}));function d(e,t){var r=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var l=r.length,i=new Array(l);i[0]=m;var o={};for(var s in t)hasOwnProperty.call(t,s)&&(o[s]=t[s]);o.originalType=e,o.mdxType="string"==typeof e?e:a,i[1]=o;for(var p=2;p<l;p++)i[p]=r[p];return n.createElement.apply(null,i)}return n.createElement.apply(null,r)}m.displayName="MDXCreateElement"},8461:function(e,t,r){r.r(t),r.d(t,{frontMatter:function(){return i},contentTitle:function(){return o},metadata:function(){return s},toc:function(){return p},default:function(){return u}});var n=r(3117),a=r(102),l=(r(7294),r(3905)),i={id:"search",title:"Search",sidebar_label:"Search"},o=void 0,s={unversionedId:"web/search",id:"version-5.1.1/web/search",isDocsHomePage:!1,title:"Search",description:"SearchItems",source:"@site/versioned_docs/version-5.1.1/web/search.md",sourceDirName:"web",slug:"/web/search",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/search",editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/web/search.md",version:"5.1.1",lastUpdatedBy:"Alex Yeo",lastUpdatedAt:1652933184,formattedLastUpdatedAt:"5/19/2022",frontMatter:{id:"search",title:"Search",sidebar_label:"Search"},sidebar:"version-5.1.1/someSidebar",previous:{title:"Proxy Settings",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/proxy"},next:{title:"Tracks",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/tracks"}},p=[{value:"SearchItems",id:"searchitems",children:[]},{value:"SearchItemsEscaped",id:"searchitemsescaped",children:[]}],c={toc:p};function u(e){var t=e.components,r=(0,a.Z)(e,["components"]);return(0,l.kt)("wrapper",(0,n.Z)({},c,r,{components:t,mdxType:"MDXLayout"}),(0,l.kt)("h2",{id:"searchitems"},"SearchItems"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.")),(0,l.kt)("p",null,"::: warning\nYou may want to use ",(0,l.kt)("inlineCode",{parentName:"p"},"SearchItemsEscaped")," if you're processing user-input without validation\n:::"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Parameters")),(0,l.kt)("table",null,(0,l.kt)("thead",{parentName:"table"},(0,l.kt)("tr",{parentName:"thead"},(0,l.kt)("th",{parentName:"tr",align:null},"Name"),(0,l.kt)("th",{parentName:"tr",align:null},"Description"),(0,l.kt)("th",{parentName:"tr",align:null},"Example"))),(0,l.kt)("tbody",{parentName:"table"},(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"q"),(0,l.kt)("td",{parentName:"tr",align:null},"The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"roadhouse+blues"'))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"type"),(0,l.kt)("td",{parentName:"tr",align:null},"A list of item types to search across."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"SearchType.Album"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[limit]"),(0,l.kt)("td",{parentName:"tr",align:null},"The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"20"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[offset]"),(0,l.kt)("td",{parentName:"tr",align:null},"The index of the first result to return. Default: 0"),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},"0"))),(0,l.kt)("tr",{parentName:"tbody"},(0,l.kt)("td",{parentName:"tr",align:null},"[market]"),(0,l.kt)("td",{parentName:"tr",align:null},"An ISO 3166-1 alpha-2 country code or the string from_token."),(0,l.kt)("td",{parentName:"tr",align:null},(0,l.kt)("inlineCode",{parentName:"td"},'"de"'))))),(0,l.kt)("p",null,"Returns a ",(0,l.kt)("inlineCode",{parentName:"p"},"SearchItem")," which contains the properties ",(0,l.kt)("inlineCode",{parentName:"p"},"Paging<FullArtist> Artists"),",",(0,l.kt)("inlineCode",{parentName:"p"},"Paging<FullTrack> Tracks"),", ",(0,l.kt)("inlineCode",{parentName:"p"},"Paging<SimpleAlbum> Albums"),", ",(0,l.kt)("inlineCode",{parentName:"p"},"Paging<SimplePlaylist> Playlists"),". They are filled based on your search-type."),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Usage")),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},'SearchItem item = _spotify.SearchItems("roadhouse+blues", SearchType.Album | SearchType.Playlist);\nConsole.WriteLine(item.Albums.Total); //How many results are there in total? NOTE: item.Tracks = item.Artists = null\n')),(0,l.kt)("hr",null),(0,l.kt)("h2",{id:"searchitemsescaped"},"SearchItemsEscaped"),(0,l.kt)("blockquote",null,(0,l.kt)("p",{parentName:"blockquote"},"Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.")),(0,l.kt)("p",null,"Works like ",(0,l.kt)("inlineCode",{parentName:"p"},"SearchItems"),", but URL escapes all characters"))}u.isMDXComponent=!0}}]);