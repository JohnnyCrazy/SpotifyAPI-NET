"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[2996],{3905:function(e,t,n){n.d(t,{Zo:function(){return s},kt:function(){return d}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function c(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var u=r.createContext({}),l=function(e){var t=r.useContext(u),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},s=function(e){var t=l(e.components);return r.createElement(u.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},f=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,i=e.originalType,u=e.parentName,s=c(e,["components","mdxType","originalType","parentName"]),f=l(n),d=o,h=f["".concat(u,".").concat(d)]||f[d]||p[d]||i;return n?r.createElement(h,a(a({ref:t},s),{},{components:n})):r.createElement(h,a({ref:t},s))}));function d(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var i=n.length,a=new Array(i);a[0]=f;var c={};for(var u in t)hasOwnProperty.call(t,u)&&(c[u]=t[u]);c.originalType=e,c.mdxType="string"==typeof e?e:o,a[1]=c;for(var l=2;l<i;l++)a[l]=n[l];return r.createElement.apply(null,a)}return r.createElement.apply(null,n)}f.displayName="MDXCreateElement"},3919:function(e,t,n){function r(e){return!0===/^(\w*:|\/\/)/.test(e)}function o(e){return void 0!==e&&!r(e)}n.d(t,{b:function(){return r},Z:function(){return o}})},4996:function(e,t,n){n.d(t,{C:function(){return i},Z:function(){return a}});var r=n(2263),o=n(3919);function i(){var e=(0,r.Z)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,i=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,r){var i=void 0===r?{}:r,a=i.forcePrependBaseUrl,c=void 0!==a&&a,u=i.absolute,l=void 0!==u&&u;if(!n)return n;if(n.startsWith("#"))return n;if((0,o.b)(n))return n;if(c)return t+n;var s=n.startsWith(t)?n:t+n.replace(/^\//,"");return l?e+s:s}(i,n,e,t)}}}function a(e,t){return void 0===t&&(t={}),(0,i().withBaseUrl)(e,t)}},5912:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return c},contentTitle:function(){return u},metadata:function(){return l},toc:function(){return s},default:function(){return f}});var r=n(3117),o=n(102),i=(n(7294),n(3905)),a=n(4996),c={id:"auth_introduction",title:"Introduction"},u=void 0,l={unversionedId:"auth_introduction",id:"auth_introduction",isDocsHomePage:!1,title:"Introduction",description:"Spotify does not allow unauthorized access to the API. Thus, you need an access token to make requests. This access token can be gathered via multiple schemes, all following the OAuth2 spec. Since it's important to choose the correct scheme for your usecase, make sure you have a grasp of the following terminology/docs:",source:"@site/docs/auth_introduction.md",sourceDirName:".",slug:"/auth_introduction",permalink:"/SpotifyAPI-NET/docs/auth_introduction",editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/auth_introduction.md",version:"current",lastUpdatedBy:"Alex Yeo",lastUpdatedAt:1652933184,formattedLastUpdatedAt:"5/19/2022",frontMatter:{id:"auth_introduction",title:"Introduction"},sidebar:"docs",previous:{title:"Unit Testing",permalink:"/SpotifyAPI-NET/docs/unit_testing"},next:{title:"Client Credentials",permalink:"/SpotifyAPI-NET/docs/client_credentials"}},s=[],p={toc:s};function f(e){var t=e.components,n=(0,o.Z)(e,["components"]);return(0,i.kt)("wrapper",(0,r.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("p",null,"Spotify does not allow unauthorized access to the API. Thus, you need an access token to make requests. This access token can be gathered via multiple schemes, all following the OAuth2 spec. Since it's important to choose the correct scheme for your usecase, make sure you have a grasp of the following terminology/docs:"),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},"OAuth2"),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("a",{parentName:"li",href:"https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow"},"Spotify Authorization Flows"))),(0,i.kt)("p",null,"Since every auth flow also needs an application in the ",(0,i.kt)("a",{parentName:"p",href:"https://developer.spotify.com/dashboard/"},"Spotify dashboard"),", make sure you have the necessary values (like ",(0,i.kt)("inlineCode",{parentName:"p"},"Client Id")," and ",(0,i.kt)("inlineCode",{parentName:"p"},"Client Secret"),")."),(0,i.kt)("p",null,"Then, continue with the docs of the specific auth flows:"),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("a",{parentName:"li",href:"/SpotifyAPI-NET/docs/client_credentials"},"Client Credentials")),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("a",{parentName:"li",href:"/SpotifyAPI-NET/docs/implicit_grant"},"Implicit Grant")),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("a",{parentName:"li",href:"/SpotifyAPI-NET/docs/authorization_code"},"Authorization Code")),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("a",{parentName:"li",href:"/SpotifyAPI-NET/docs/pkce"},"PKCE")),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("a",{parentName:"li",href:"/SpotifyAPI-NET/docs/token_swap"},"(Token Swap)"))),(0,i.kt)("img",{alt:"auth comparison",src:(0,a.Z)("img/auth_comparison.png")}))}f.isMDXComponent=!0}}]);