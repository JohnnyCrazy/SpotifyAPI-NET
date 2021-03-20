/*! For license information please see 92bb876c.9e63d801.js.LICENSE.txt */
(window.webpackJsonp=window.webpackJsonp||[]).push([[35],{167:function(e,t,a){"use strict";a.r(t),a.d(t,"frontMatter",(function(){return c})),a.d(t,"metadata",(function(){return l})),a.d(t,"rightToc",(function(){return s})),a.d(t,"default",(function(){return b}));var n=a(2),r=a(9),i=(a(0),a(188)),o=a(212),c={id:"getting_started",title:"Getting Started"},l={id:"getting_started",title:"Getting Started",description:"Adding SpotifyAPI-NET to your project",source:"@site/docs/getting_started.md",permalink:"/SpotifyAPI-NET/docs/next/getting_started",editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/getting_started.md",version:"next",lastUpdatedBy:"Tomasz Fija\u0142kowski",lastUpdatedAt:1616259853,sidebar:"docs",previous:{title:"Introduction",permalink:"/SpotifyAPI-NET/docs/next/introduction"},next:{title:"Error Handling",permalink:"/SpotifyAPI-NET/docs/next/error_handling"}},s=[{value:"Adding SpotifyAPI-NET to your project",id:"adding-spotifyapi-net-to-your-project",children:[{value:"Package Managers",id:"package-managers",children:[]},{value:"Add DLL Manually",id:"add-dll-manually",children:[]},{value:"Compile Yourself",id:"compile-yourself",children:[]}]},{value:"First API Calls",id:"first-api-calls",children:[]},{value:"Query/Body Parameters",id:"querybody-parameters",children:[]},{value:"Guides",id:"guides",children:[]}],u={rightToc:s};function b(e){var t=e.components,a=Object(r.a)(e,["components"]);return Object(i.b)("wrapper",Object(n.a)({},u,a,{components:t,mdxType:"MDXLayout"}),Object(i.b)("h2",{id:"adding-spotifyapi-net-to-your-project"},"Adding SpotifyAPI-NET to your project"),Object(i.b)("p",null,"The library can be added to your project via the following methods:"),Object(i.b)("h3",{id:"package-managers"},"Package Managers"),Object(i.b)(o.a,{mdxType:"InstallInstructions"}),Object(i.b)("h3",{id:"add-dll-manually"},"Add DLL Manually"),Object(i.b)("p",null,"You can also grab the latest compiled DLL from our ",Object(i.b)("a",Object(n.a)({parentName:"p"},{href:"https://github.com/johnnycrazy/spotifyapi-net/releases"}),"GitHub Releases Page"),". It can be added to your project via Visual Studio or directly in your ",Object(i.b)("inlineCode",{parentName:"p"},".csproj"),":"),Object(i.b)("pre",null,Object(i.b)("code",Object(n.a)({parentName:"pre"},{className:"language-xml"}),'<ItemGroup>\n  <Reference Include="SpotifyAPI.Web">\n    <HintPath>..\\Dlls\\SpotifyAPI.Web.dll</HintPath>\n  </Reference>\n</ItemGroup>\n')),Object(i.b)("h3",{id:"compile-yourself"},"Compile Yourself"),Object(i.b)("pre",null,Object(i.b)("code",Object(n.a)({parentName:"pre"},{className:"language-sh"}),"git clone https://github.com/JohnnyCrazy/SpotifyAPI-NET.git\ncd SpotifyAPI-NET\ndotnet restore\ndotnet build\n\nls -la SpotifyAPI.Web/bin/Debug/netstandard2.1/SpotifyAPI.Web.dll\n")),Object(i.b)("h2",{id:"first-api-calls"},"First API Calls"),Object(i.b)("p",null,"You're now ready to issue your first calls to the Spotify API, a small console example:"),Object(i.b)("pre",null,Object(i.b)("code",Object(n.a)({parentName:"pre"},{className:"language-csharp"}),'using System;\nusing System.Threading.Tasks;\nusing SpotifyAPI.Web;\n\nclass Program\n{\n    static async Task Main()\n    {\n      var spotify = new SpotifyClient("YourAccessToken");\n\n      var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");\n      Console.WriteLine(track.Name);\n    }\n}\n')),Object(i.b)("div",{className:"admonition admonition-tip alert alert--success"},Object(i.b)("div",Object(n.a)({parentName:"div"},{className:"admonition-heading"}),Object(i.b)("h5",{parentName:"div"},Object(i.b)("span",Object(n.a)({parentName:"h5"},{className:"admonition-icon"}),Object(i.b)("svg",Object(n.a)({parentName:"span"},{xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"}),Object(i.b)("path",Object(n.a)({parentName:"svg"},{fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"})))),"tip")),Object(i.b)("div",Object(n.a)({parentName:"div"},{className:"admonition-content"}),Object(i.b)("p",{parentName:"div"},"Notice that the spotify api does not allow unauthorized API access. Wondering where you should get an access token from? For a quick test, head over to the ",Object(i.b)("a",Object(n.a)({parentName:"p"},{href:"https://developer.spotify.com/console/get-album/"}),"Spotify Developer Console")," and generate an access token with the required scopes! For a permanent solution, head over to the ",Object(i.b)("a",Object(n.a)({parentName:"p"},{href:"/SpotifyAPI-NET/docs/next/auth_introduction"}),"authentication guides"),"."))),Object(i.b)("p",null,"There is no online documentation for every available API call, but XML inline docs are available:"),Object(i.b)("ul",null,Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IUserProfileClient.cs"}),"UserProfile")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IBrowseClient.cs"}),"Browse")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IShowsClient.cs"}),"Shows")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPlaylistsClient.cs"}),"Playlists")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ISearchClient.cs"}),"Search")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IFollowClient.cs"}),"Follow")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ITracksClient.cs"}),"Tracks")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPlayerClient.cs"}),"Player")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IAlbumsClient.cs"}),"Albums")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IArtistsClient.cs"}),"Artists")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPersonalizationClient.cs"}),"Personalization")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IEpisodesClient.cs"}),"Episodes")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(n.a)({parentName:"li"},{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ILibraryClient.cs"}),"Library"))),Object(i.b)("p",null,"All calls have the ",Object(i.b)("a",Object(n.a)({parentName:"p"},{href:"https://developer.spotify.com/documentation/web-api/reference-beta/"}),"Spotify Web API documentation reference")," attached as a remark."),Object(i.b)("h2",{id:"querybody-parameters"},"Query/Body Parameters"),Object(i.b)("p",null,"If an API endpoint has query or body parameters, a request model can be supplied to the method"),Object(i.b)("pre",null,Object(i.b)("code",Object(n.a)({parentName:"pre"},{className:"language-csharp"}),'// No optional or required query/body parameters\n// The track ID is part of the request path --\x3e it\'s not treated as query/body parameter\nvar track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");\n\n// Optional query/body parameter\nvar track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH", new TrackRequest{\n  Market = "DE"\n});\n\n// Sometimes, query/body parameters are also required!\nvar tracks = await spotify.Tracks.GetSeveral(new TracksRequest(new List<string> {\n  "1s6ux0lNiTziSrd7iUAADH",\n  "6YlOxoHWLjH6uVQvxUIUug"\n}));\n')),Object(i.b)("p",null,"If a query/body parameter is required, it has to be supplied in the constructor of the request model. In the background, empty/null checks are also performed to make sure required parameters are not empty/null. If it is optional, it can be supplied as a property to the request model."),Object(i.b)("h2",{id:"guides"},"Guides"),Object(i.b)("p",null,'All other relevant topics are covered in the "Guides" and ',Object(i.b)("a",Object(n.a)({parentName:"p"},{href:"/SpotifyAPI-NET/docs/next/auth_introduction"}),"Authentication Guides")," section in the sidebar!"))}b.isMDXComponent=!0},188:function(e,t,a){"use strict";a.d(t,"a",(function(){return b})),a.d(t,"b",(function(){return f}));var n=a(0),r=a.n(n);function i(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}function o(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,n)}return a}function c(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?o(Object(a),!0).forEach((function(t){i(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):o(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}function l(e,t){if(null==e)return{};var a,n,r=function(e,t){if(null==e)return{};var a,n,r={},i=Object.keys(e);for(n=0;n<i.length;n++)a=i[n],t.indexOf(a)>=0||(r[a]=e[a]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(n=0;n<i.length;n++)a=i[n],t.indexOf(a)>=0||Object.prototype.propertyIsEnumerable.call(e,a)&&(r[a]=e[a])}return r}var s=r.a.createContext({}),u=function(e){var t=r.a.useContext(s),a=t;return e&&(a="function"==typeof e?e(t):c({},t,{},e)),a},b=function(e){var t=u(e.components);return r.a.createElement(s.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return r.a.createElement(r.a.Fragment,{},t)}},d=Object(n.forwardRef)((function(e,t){var a=e.components,n=e.mdxType,i=e.originalType,o=e.parentName,s=l(e,["components","mdxType","originalType","parentName"]),b=u(a),d=n,f=b["".concat(o,".").concat(d)]||b[d]||p[d]||i;return a?r.a.createElement(f,c({ref:t},s,{components:a})):r.a.createElement(f,c({ref:t},s))}));function f(e,t){var a=arguments,n=t&&t.mdxType;if("string"==typeof e||n){var i=a.length,o=new Array(i);o[0]=d;var c={};for(var l in t)hasOwnProperty.call(t,l)&&(c[l]=t[l]);c.originalType=e,c.mdxType="string"==typeof e?e:n,o[1]=c;for(var s=2;s<i;s++)o[s]=a[s];return r.a.createElement.apply(null,o)}return r.a.createElement.apply(null,a)}d.displayName="MDXCreateElement"},189:function(e,t,a){"use strict";var n=a(0),r=a(49);t.a=function(){return Object(n.useContext)(r.a)}},192:function(e,t,a){var n=a(69),r=a(23);e.exports=function(e,t,a){if(n(t))throw TypeError("String#"+a+" doesn't accept regex!");return String(r(e))}},193:function(e,t,a){var n=a(3)("match");e.exports=function(e){var t=/./;try{"/./"[e](t)}catch(a){try{return t[n]=!1,!"/./"[e](t)}catch(r){}}return!0}},194:function(e,t,a){var n;!function(){"use strict";var a={}.hasOwnProperty;function r(){for(var e=[],t=0;t<arguments.length;t++){var n=arguments[t];if(n){var i=typeof n;if("string"===i||"number"===i)e.push(n);else if(Array.isArray(n)&&n.length){var o=r.apply(null,n);o&&e.push(o)}else if("object"===i)for(var c in n)a.call(n,c)&&n[c]&&e.push(c)}}return e.join(" ")}e.exports?(r.default=r,e.exports=r):void 0===(n=function(){return r}.apply(t,[]))||(e.exports=n)}()},197:function(e,t,a){var n=a(79),r=a(52).concat("length","prototype");t.f=Object.getOwnPropertyNames||function(e){return n(e,r)}},200:function(e,t,a){var n=a(70),r=a(51),i=a(26),o=a(71),c=a(25),l=a(76),s=Object.getOwnPropertyDescriptor;t.f=a(12)?s:function(e,t){if(e=i(e),t=o(t,!0),l)try{return s(e,t)}catch(a){}if(c(e,t))return r(!n.f.call(e,t),e[t])}},202:function(e,t,a){"use strict";var n=a(0),r=a.n(n);t.a=function(e){return r.a.createElement("div",null,e.children)}},205:function(e,t,a){"use strict";a(28),a(19),a(20);var n=a(0),r=a.n(n),i=a(199);var o=function(){return Object(n.useContext)(i.a)},c=a(194),l=a.n(c),s=a(126),u=a.n(s),b=37,p=39;t.a=function(e){var t=e.block,a=e.children,i=e.defaultValue,c=e.values,s=e.groupId,d=o(),f=d.tabGroupChoices,m=d.setTabGroupChoices,y=Object(n.useState)(i),h=y[0],O=y[1];if(null!=s){var j=f[s];null!=j&&j!==h&&O(j)}var g=function(e){O(e),null!=s&&m(s,e)},v=[];return r.a.createElement("div",null,r.a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:l()("tabs",{"tabs--block":t})},c.map((function(e){var t=e.value,a=e.label;return r.a.createElement("li",{role:"tab",tabIndex:"0","aria-selected":h===t,className:l()("tabs__item",u.a.tabItem,{"tabs__item--active":h===t}),key:t,ref:function(e){return v.push(e)},onKeyDown:function(e){return function(e,t,a){switch(a.keyCode){case p:!function(e,t){var a=e.indexOf(t)+1;e[a]?e[a].focus():e[0].focus()}(e,t);break;case b:!function(e,t){var a=e.indexOf(t)-1;e[a]?e[a].focus():e[e.length-1].focus()}(e,t)}}(v,e.target,e)},onFocus:function(){return g(t)},onClick:function(){return g(t)}},a)}))),r.a.createElement("div",{role:"tabpanel",className:"margin-vert--md"},n.Children.toArray(a).filter((function(e){return e.props.value===h}))[0]))}},212:function(e,t,a){"use strict";var n=a(204),r=a(202),i=a(205),o=a(0),c=a.n(o);t.a=function(){return c.a.createElement("div",{style:{padding:"10px"}},c.a.createElement(i.a,{defaultValue:"cli",values:[{label:".NET CLI",value:"cli"},{label:"Package Manager",value:"nuget"},{label:"Package Reference",value:"reference"}]},c.a.createElement(r.a,{value:"cli"},c.a.createElement(n.a,{metastring:"shell",className:"shell"},"dotnet add package SpotifyAPI.Web\n# Optional Auth module, which includes an embedded HTTP Server for OAuth2\ndotnet add package SpotifyAPI.Web.Auth\n")),c.a.createElement(r.a,{value:"nuget"},c.a.createElement(n.a,{metastring:"shell",className:"shell"},"Install-Package SpotifyAPI.Web\n# Optional Auth module, which includes an embedded HTTP Server for OAuth2\nInstall-Package SpotifyAPI.Web.Auth\n")),c.a.createElement(r.a,{value:"reference"},c.a.createElement(n.a,{metastring:"xml",className:"xml"},'<PackageReference Include="SpotifyAPI.Web" Version="6.0.0" />\n\x3c!-- Optional Auth module, which includes an embedded HTTP Server for OAuth2 --\x3e\n<PackageReference Include="SpotifyAPI.Web.Auth" Version="6.0.0" />\n'))))}}}]);