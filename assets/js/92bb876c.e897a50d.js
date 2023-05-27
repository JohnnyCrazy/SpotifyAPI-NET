"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[6347],{3905:function(e,t,a){a.d(t,{Zo:function(){return c},kt:function(){return f}});var n=a(7294);function r(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}function o(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,n)}return a}function l(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?o(Object(a),!0).forEach((function(t){r(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):o(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}function i(e,t){if(null==e)return{};var a,n,r=function(e,t){if(null==e)return{};var a,n,r={},o=Object.keys(e);for(n=0;n<o.length;n++)a=o[n],t.indexOf(a)>=0||(r[a]=e[a]);return r}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(n=0;n<o.length;n++)a=o[n],t.indexOf(a)>=0||Object.prototype.propertyIsEnumerable.call(e,a)&&(r[a]=e[a])}return r}var s=n.createContext({}),u=function(e){var t=n.useContext(s),a=t;return e&&(a="function"==typeof e?e(t):l(l({},t),e)),a},c=function(e){var t=u(e.components);return n.createElement(s.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},d=n.forwardRef((function(e,t){var a=e.components,r=e.mdxType,o=e.originalType,s=e.parentName,c=i(e,["components","mdxType","originalType","parentName"]),d=u(a),f=r,m=d["".concat(s,".").concat(f)]||d[f]||p[f]||o;return a?n.createElement(m,l(l({ref:t},c),{},{components:a})):n.createElement(m,l({ref:t},c))}));function f(e,t){var a=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var o=a.length,l=new Array(o);l[0]=d;var i={};for(var s in t)hasOwnProperty.call(t,s)&&(i[s]=t[s]);i.originalType=e,i.mdxType="string"==typeof e?e:r,l[1]=i;for(var u=2;u<o;u++)l[u]=a[u];return n.createElement.apply(null,l)}return n.createElement.apply(null,a)}d.displayName="MDXCreateElement"},5896:function(e,t,a){a.d(t,{Z:function(){return b}});var n=a(814),r=a(7294),o=a(6010),l="tabItem_Ymn6";function i(e){var t=e.children,a=e.hidden,n=e.className;return r.createElement("div",{role:"tabpanel",className:(0,o.Z)(l,n),hidden:a},t)}var s=a(7462),u=a(2389),c=a(7392),p=a(7094),d=a(2466),f="tabList__CuJ",m="tabItem_LNqP";function y(e){var t,a,n=e.lazy,l=e.block,i=e.defaultValue,u=e.values,y=e.groupId,h=e.className,b=r.Children.map(e.children,(function(e){if((0,r.isValidElement)(e)&&"value"in e.props)return e;throw new Error("Docusaurus error: Bad <Tabs> child <"+("string"==typeof e.type?e.type:e.type.name)+'>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.')})),g=null!=u?u:b.map((function(e){var t=e.props;return{value:t.value,label:t.label,attributes:t.attributes}})),v=(0,c.l)(g,(function(e,t){return e.value===t.value}));if(v.length>0)throw new Error('Docusaurus error: Duplicate values "'+v.map((function(e){return e.value})).join(", ")+'" found in <Tabs>. Every value needs to be unique.');var k=null===i?i:null!=(t=null!=i?i:null==(a=b.find((function(e){return e.props.default})))?void 0:a.props.value)?t:b[0].props.value;if(null!==k&&!g.some((function(e){return e.value===k})))throw new Error('Docusaurus error: The <Tabs> has a defaultValue "'+k+'" but none of its children has the corresponding value. Available values are: '+g.map((function(e){return e.value})).join(", ")+". If you intend to show no default tab, use defaultValue={null} instead.");var I=(0,p.U)(),P=I.tabGroupChoices,A=I.setTabGroupChoices,N=(0,r.useState)(k),S=N[0],T=N[1],C=[],E=(0,d.o5)().blockElementScrollPositionUntilNextRender;if(null!=y){var w=P[y];null!=w&&w!==S&&g.some((function(e){return e.value===w}))&&T(w)}var O=function(e){var t=e.currentTarget,a=C.indexOf(t),n=g[a].value;n!==S&&(E(t),T(n),null!=y&&A(y,String(n)))},x=function(e){var t,a=null;switch(e.key){case"Enter":O(e);break;case"ArrowRight":var n,r=C.indexOf(e.currentTarget)+1;a=null!=(n=C[r])?n:C[0];break;case"ArrowLeft":var o,l=C.indexOf(e.currentTarget)-1;a=null!=(o=C[l])?o:C[C.length-1]}null==(t=a)||t.focus()};return r.createElement("div",{className:(0,o.Z)("tabs-container",f)},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,o.Z)("tabs",{"tabs--block":l},h)},g.map((function(e){var t=e.value,a=e.label,n=e.attributes;return r.createElement("li",(0,s.Z)({role:"tab",tabIndex:S===t?0:-1,"aria-selected":S===t,key:t,ref:function(e){return C.push(e)},onKeyDown:x,onClick:O},n,{className:(0,o.Z)("tabs__item",m,null==n?void 0:n.className,{"tabs__item--active":S===t})}),null!=a?a:t)}))),n?(0,r.cloneElement)(b.filter((function(e){return e.props.value===S}))[0],{className:"margin-top--md"}):r.createElement("div",{className:"margin-top--md"},b.map((function(e,t){return(0,r.cloneElement)(e,{key:t,hidden:e.props.value!==S})}))))}function h(e){var t=(0,u.Z)();return r.createElement(y,(0,s.Z)({key:String(t)},e))}var b=function(){return r.createElement("div",{style:{padding:"10px"}},r.createElement(h,{defaultValue:"cli",values:[{label:".NET CLI",value:"cli"},{label:"Package Manager",value:"nuget"},{label:"Package Reference",value:"reference"}]},r.createElement(i,{value:"cli"},r.createElement(n.Z,{language:"shell",className:"shell"},"dotnet add package SpotifyAPI.Web\n# Optional Auth module, which includes an embedded HTTP Server for OAuth2\ndotnet add package SpotifyAPI.Web.Auth\n")),r.createElement(i,{value:"nuget"},r.createElement(n.Z,{language:"shell",className:"shell"},"Install-Package SpotifyAPI.Web\n# Optional Auth module, which includes an embedded HTTP Server for OAuth2\nInstall-Package SpotifyAPI.Web.Auth\n")),r.createElement(i,{value:"reference"},r.createElement(n.Z,{language:"xml",className:"xml"},'<PackageReference Include="SpotifyAPI.Web" Version="7.0.0" />\n\x3c!-- Optional Auth module, which includes an embedded HTTP Server for OAuth2 --\x3e\n<PackageReference Include="SpotifyAPI.Web.Auth" Version="7.0.0" />\n'))))}},8230:function(e,t,a){a.r(t),a.d(t,{assets:function(){return p},contentTitle:function(){return u},default:function(){return m},frontMatter:function(){return s},metadata:function(){return c},toc:function(){return d}});var n=a(7462),r=a(3366),o=(a(7294),a(3905)),l=a(5896),i=["components"],s={id:"getting_started",title:"Getting Started"},u=void 0,c={unversionedId:"getting_started",id:"getting_started",title:"Getting Started",description:"Adding SpotifyAPI-NET to your project",source:"@site/docs/getting_started.md",sourceDirName:".",slug:"/getting_started",permalink:"/SpotifyAPI-NET/docs/getting_started",draft:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/getting_started.md",tags:[],version:"current",lastUpdatedBy:"Jonas Dellinger",lastUpdatedAt:1685216698,formattedLastUpdatedAt:"May 27, 2023",frontMatter:{id:"getting_started",title:"Getting Started"},sidebar:"docs",previous:{title:"Introduction",permalink:"/SpotifyAPI-NET/docs/introduction"},next:{title:"Error Handling",permalink:"/SpotifyAPI-NET/docs/error_handling"}},p={},d=[{value:"Adding SpotifyAPI-NET to your project",id:"adding-spotifyapi-net-to-your-project",level:2},{value:"Package Managers",id:"package-managers",level:3},{value:"Add DLL Manually",id:"add-dll-manually",level:3},{value:"Compile Yourself",id:"compile-yourself",level:3},{value:"First API Calls",id:"first-api-calls",level:2},{value:"Query/Body Parameters",id:"querybody-parameters",level:2},{value:"Guides",id:"guides",level:2}],f={toc:d};function m(e){var t=e.components,a=(0,r.Z)(e,i);return(0,o.kt)("wrapper",(0,n.Z)({},f,a,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h2",{id:"adding-spotifyapi-net-to-your-project"},"Adding SpotifyAPI-NET to your project"),(0,o.kt)("p",null,"The library can be added to your project via the following methods:"),(0,o.kt)("h3",{id:"package-managers"},"Package Managers"),(0,o.kt)(l.Z,{mdxType:"InstallInstructions"}),(0,o.kt)("h3",{id:"add-dll-manually"},"Add DLL Manually"),(0,o.kt)("p",null,"You can also grab the latest compiled DLL from our ",(0,o.kt)("a",{parentName:"p",href:"https://github.com/johnnycrazy/spotifyapi-net/releases"},"GitHub Releases Page"),". It can be added to your project via Visual Studio or directly in your ",(0,o.kt)("inlineCode",{parentName:"p"},".csproj"),":"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-xml"},'<ItemGroup>\n  <Reference Include="SpotifyAPI.Web">\n    <HintPath>..\\Dlls\\SpotifyAPI.Web.dll</HintPath>\n  </Reference>\n</ItemGroup>\n')),(0,o.kt)("h3",{id:"compile-yourself"},"Compile Yourself"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-sh"},"git clone https://github.com/JohnnyCrazy/SpotifyAPI-NET.git\ncd SpotifyAPI-NET\ndotnet restore\ndotnet build\n\nls -la SpotifyAPI.Web/bin/Debug/netstandard2.1/SpotifyAPI.Web.dll\n")),(0,o.kt)("h2",{id:"first-api-calls"},"First API Calls"),(0,o.kt)("p",null,"You're now ready to issue your first calls to the Spotify API, a small console example:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'using System;\nusing System.Threading.Tasks;\nusing SpotifyAPI.Web;\n\nclass Program\n{\n    static async Task Main()\n    {\n      var spotify = new SpotifyClient("YourAccessToken");\n\n      var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");\n      Console.WriteLine(track.Name);\n    }\n}\n')),(0,o.kt)("admonition",{type:"tip"},(0,o.kt)("p",{parentName:"admonition"},"Notice that the spotify api does not allow unauthorized API access. Wondering where you should get an access token from? For a quick test, head over to the ",(0,o.kt)("a",{parentName:"p",href:"https://developer.spotify.com/console/get-album/"},"Spotify Developer Console")," and generate an access token with the required scopes! For a permanent solution, head over to the ",(0,o.kt)("a",{parentName:"p",href:"/SpotifyAPI-NET/docs/auth_introduction"},"authentication guides"),".")),(0,o.kt)("p",null,"There is no online documentation for every available API call, but XML inline docs are available:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IUserProfileClient.cs"},"UserProfile")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IBrowseClient.cs"},"Browse")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IShowsClient.cs"},"Shows")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPlaylistsClient.cs"},"Playlists")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ISearchClient.cs"},"Search")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IFollowClient.cs"},"Follow")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ITracksClient.cs"},"Tracks")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPlayerClient.cs"},"Player")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IAlbumsClient.cs"},"Albums")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IArtistsClient.cs"},"Artists")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPersonalizationClient.cs"},"Personalization")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IEpisodesClient.cs"},"Episodes")),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("a",{parentName:"li",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/ILibraryClient.cs"},"Library"))),(0,o.kt)("p",null,"All calls have the ",(0,o.kt)("a",{parentName:"p",href:"https://developer.spotify.com/documentation/web-api/reference-beta/"},"Spotify Web API documentation reference")," attached as a remark."),(0,o.kt)("h2",{id:"querybody-parameters"},"Query/Body Parameters"),(0,o.kt)("p",null,"If an API endpoint has query or body parameters, a request model can be supplied to the method"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'// No optional or required query/body parameters\n// The track ID is part of the request path --\x3e it\'s not treated as query/body parameter\nvar track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");\n\n// Optional query/body parameter\nvar track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH", new TrackRequest{\n  Market = "DE"\n});\n\n// Sometimes, query/body parameters are also required!\nvar tracks = await spotify.Tracks.GetSeveral(new TracksRequest(new List<string> {\n  "1s6ux0lNiTziSrd7iUAADH",\n  "6YlOxoHWLjH6uVQvxUIUug"\n}));\n')),(0,o.kt)("p",null,"If a query/body parameter is required, it has to be supplied in the constructor of the request model. In the background, empty/null checks are also performed to make sure required parameters are not empty/null. If it is optional, it can be supplied as a property to the request model."),(0,o.kt)("h2",{id:"guides"},"Guides"),(0,o.kt)("p",null,'All other relevant topics are covered in the "Guides" and ',(0,o.kt)("a",{parentName:"p",href:"/SpotifyAPI-NET/docs/auth_introduction"},"Authentication Guides")," section in the sidebar!"))}m.isMDXComponent=!0}}]);