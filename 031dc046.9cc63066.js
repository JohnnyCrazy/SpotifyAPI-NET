(window.webpackJsonp=window.webpackJsonp||[]).push([[4],{132:function(e,t,r){"use strict";r.r(t),r.d(t,"frontMatter",(function(){return c})),r.d(t,"metadata",(function(){return s})),r.d(t,"rightToc",(function(){return l})),r.d(t,"default",(function(){return u}));var n=r(2),o=r(9),a=(r(0),r(188)),i=r(190),c={id:"example_blazor_wasm",title:"Blazor WASM"},s={id:"example_blazor_wasm",title:"Blazor WASM",description:"Description",source:"@site/docs/example_blazor_wasm.md",permalink:"/SpotifyAPI-NET/docs/next/example_blazor_wasm",editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/example_blazor_wasm.md",version:"next",lastUpdatedBy:"L0um15",lastUpdatedAt:1607089956,sidebar:"docs",previous:{title:"ASP.NET",permalink:"/SpotifyAPI-NET/docs/next/example_asp"},next:{title:"Blazor ServerSide",permalink:"/SpotifyAPI-NET/docs/next/example_blazor"}},l=[{value:"Description",id:"description",children:[]},{value:"Run it",id:"run-it",children:[]}],p={rightToc:l};function u(e){var t=e.components,r=Object(o.a)(e,["components"]);return Object(a.b)("wrapper",Object(n.a)({},p,r,{components:t,mdxType:"MDXLayout"}),Object(a.b)("h2",{id:"description"},"Description"),Object(a.b)("p",null,"This small cross-platform web app runs on ",Object(a.b)("inlineCode",{parentName:"p"},"Blazor WebAssembly"),", which was released on 19. May 2020. It allows to run C# code in any browser which supports WebAssembly. This allows to create .NET full-stack web projects without writing any JavaScript. Find more about ",Object(a.b)("a",Object(n.a)({parentName:"p"},{href:"https://devblogs.microsoft.com/aspnet/blazor-webassembly-3-2-0-now-available/"}),"Blazor WebAssembly here")),Object(a.b)("p",null,"Since this library is compatible with ",Object(a.b)("inlineCode",{parentName:"p"},".NET Standard 2.1"),", you can use all features of ",Object(a.b)("inlineCode",{parentName:"p"},"SpotifyAPI.Web")," in your blazor wasm app. The example logs the user in via ",Object(a.b)("inlineCode",{parentName:"p"},"Implicit Grant")," and does 2 user-related API requests from the browser. You can observe the requests from your browsers network tools."),Object(a.b)("img",{alt:"BlazorWASM Spotify Example",src:Object(i.a)("img/blazorwasm_homepage.png")}),Object(a.b)("img",{alt:"BlazorWASM Spotify Example - network tools",src:Object(i.a)("img/blazorwasm_network_tools.png")}),Object(a.b)("h2",{id:"run-it"},"Run it"),Object(a.b)("p",null,"Before running it, make sure you created an app in your ",Object(a.b)("a",Object(n.a)({parentName:"p"},{href:"https://developer.spotify.com/dashboard/"}),"spotify dashboard")," and ",Object(a.b)("inlineCode",{parentName:"p"},"https://localhost:5001")," is a redirect uri of it."),Object(a.b)("pre",null,Object(a.b)("code",Object(n.a)({parentName:"pre"},{className:"language-bash"}),'# Assumes linux and current working directory is the cloned repository\ncd SpotifyAPI.Web.Examples/Example.BlazorWASM\ndotnet restore\n\necho "{ \\"SPOTIFY_CLIENT_ID\\": \\"YourSpotifyClientId\\" }" > wwwroot/appsettings.json\ndotnet run\n\n# Visit https://localhost:5001\n')))}u.isMDXComponent=!0},188:function(e,t,r){"use strict";r.d(t,"a",(function(){return u})),r.d(t,"b",(function(){return d}));var n=r(0),o=r.n(n);function a(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}function i(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function c(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?i(Object(r),!0).forEach((function(t){a(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):i(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function s(e,t){if(null==e)return{};var r,n,o=function(e,t){if(null==e)return{};var r,n,o={},a=Object.keys(e);for(n=0;n<a.length;n++)r=a[n],t.indexOf(r)>=0||(o[r]=e[r]);return o}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(n=0;n<a.length;n++)r=a[n],t.indexOf(r)>=0||Object.prototype.propertyIsEnumerable.call(e,r)&&(o[r]=e[r])}return o}var l=o.a.createContext({}),p=function(e){var t=o.a.useContext(l),r=t;return e&&(r="function"==typeof e?e(t):c({},t,{},e)),r},u=function(e){var t=p(e.components);return o.a.createElement(l.Provider,{value:t},e.children)},b={inlineCode:"code",wrapper:function(e){var t=e.children;return o.a.createElement(o.a.Fragment,{},t)}},m=Object(n.forwardRef)((function(e,t){var r=e.components,n=e.mdxType,a=e.originalType,i=e.parentName,l=s(e,["components","mdxType","originalType","parentName"]),u=p(r),m=n,d=u["".concat(i,".").concat(m)]||u[m]||b[m]||a;return r?o.a.createElement(d,c({ref:t},l,{components:r})):o.a.createElement(d,c({ref:t},l))}));function d(e,t){var r=arguments,n=t&&t.mdxType;if("string"==typeof e||n){var a=r.length,i=new Array(a);i[0]=m;var c={};for(var s in t)hasOwnProperty.call(t,s)&&(c[s]=t[s]);c.originalType=e,c.mdxType="string"==typeof e?e:n,i[1]=c;for(var l=2;l<a;l++)i[l]=r[l];return o.a.createElement.apply(null,i)}return o.a.createElement.apply(null,r)}m.displayName="MDXCreateElement"},189:function(e,t,r){"use strict";var n=r(0),o=r(49);t.a=function(){return Object(n.useContext)(o.a)}},190:function(e,t,r){"use strict";r.d(t,"a",(function(){return o}));r(191);var n=r(189);function o(e){var t=(Object(n.a)().siteConfig||{}).baseUrl,r=void 0===t?"/":t;if(!e)return e;return/^(https?:|\/\/)/.test(e)?e:e.startsWith("/")?r+e.slice(1):r+e}},191:function(e,t,r){"use strict";var n=r(17),o=r(35),a=r(192),i="".startsWith;n(n.P+n.F*r(193)("startsWith"),"String",{startsWith:function(e){var t=a(this,e,"startsWith"),r=o(Math.min(arguments.length>1?arguments[1]:void 0,t.length)),n=String(e);return i?i.call(t,n,r):t.slice(r,r+n.length)===n}})},192:function(e,t,r){var n=r(69),o=r(23);e.exports=function(e,t,r){if(n(t))throw TypeError("String#"+r+" doesn't accept regex!");return String(o(e))}},193:function(e,t,r){var n=r(3)("match");e.exports=function(e){var t=/./;try{"/./"[e](t)}catch(r){try{return t[n]=!1,!"/./"[e](t)}catch(o){}}return!0}}}]);