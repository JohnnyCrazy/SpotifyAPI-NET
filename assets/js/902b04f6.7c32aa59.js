"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[1256],{9308:(e,n,s)=>{s.r(n),s.d(n,{assets:()=>c,contentTitle:()=>i,default:()=>p,frontMatter:()=>r,metadata:()=>a,toc:()=>d});var o=s(2488),t=s(7052);const r={id:"token_swap",title:"Token Swap"},i=void 0,a={id:"token_swap",title:"Token Swap",description:"Token Swap provides an authenticatiow flow where client-side apps (like CLI/desktop/mobile apps) are still able to use long-living tokens and the opportunity to refresh them without exposing your application's secret. This however requires a server-side part to work.",source:"@site/docs/token_swap.md",sourceDirName:".",slug:"/token_swap",permalink:"/SpotifyAPI-NET/docs/token_swap",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/token_swap.md",tags:[],version:"current",lastUpdatedBy:"4or5trees",lastUpdatedAt:1721513023,formattedLastUpdatedAt:"Jul 20, 2024",frontMatter:{id:"token_swap",title:"Token Swap"},sidebar:"docs",previous:{title:"PKCE",permalink:"/SpotifyAPI-NET/docs/pkce"},next:{title:"Showcase",permalink:"/SpotifyAPI-NET/docs/showcase"}},c={},d=[{value:"Flow",id:"flow",level:2},{value:"Server Implementation",id:"server-implementation",level:2},{value:"Swap",id:"swap",level:3},{value:"Refresh",id:"refresh",level:3},{value:"Example",id:"example",level:2}];function l(e){const n={a:"a",code:"code",h2:"h2",h3:"h3",p:"p",pre:"pre",...(0,t.M)(),...e.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsx)(n.p,{children:"Token Swap provides an authenticatiow flow where client-side apps (like CLI/desktop/mobile apps) are still able to use long-living tokens and the opportunity to refresh them without exposing your application's secret. This however requires a server-side part to work."}),"\n",(0,o.jsxs)(n.p,{children:["It is based on the ",(0,o.jsx)(n.a,{href:"/SpotifyAPI-NET/docs/authorization_code",children:"Authorization Code"})," flow and is also documented by Spotify: ",(0,o.jsx)(n.a,{href:"https://developer.spotify.com/documentation/ios/guides/token-swap-and-refresh/",children:"Token Swap and Refresh "}),"."]}),"\n",(0,o.jsx)(n.h2,{id:"flow",children:"Flow"}),"\n",(0,o.jsxs)(n.p,{children:["The client uses the first part of the ",(0,o.jsx)(n.code,{children:"Authorization Code"})," flow and redirects the user to Spotify's login page. In this part, only the client id is required. Once the user logged in and confirmed the usage of your app, they will be redirect to a ",(0,o.jsx)(n.code,{children:"http://localhost"})," server which grabs the ",(0,o.jsx)(n.code,{children:"code"})," from the query parameters."]}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-csharp",children:'var request = new LoginRequest("http://localhost", "ClientId", LoginRequest.ResponseType.Code)\n{\n  Scope = new List<string> { Scopes.UserReadEmail }\n};\nBrowserUtil.Open(uri);\n'})}),"\n",(0,o.jsxs)(n.p,{children:["Now, swapping out this ",(0,o.jsx)(n.code,{children:"code"})," for an ",(0,o.jsx)(n.code,{children:"access_token"})," would require the app's client secret. We don't have this on the client-side. Instead, we send a request to our server, which takes care of the code swap:"]}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-csharp",children:'public Task GetCallback(string code)\n{\n  var response = await new OAuthClient().RequestToken(\n    new TokenSwapTokenRequest("https://your-swap-server.com/swap", code)\n  );\n\n  var spotify = new SpotifyClient(response.AccessToken);\n  // Also important for later: response.RefreshToken\n}\n'})}),"\n",(0,o.jsxs)(n.p,{children:["The server swapped out the ",(0,o.jsx)(n.code,{children:"code"})," for an ",(0,o.jsx)(n.code,{children:"access_token"})," and ",(0,o.jsx)(n.code,{children:"refresh_token"}),". Once we realize the ",(0,o.jsx)(n.code,{children:"access_token"})," expired, we can also ask the server to refresh it:"]}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-csharp",children:'// if response.IsExpired is true\nvar newResponse = await new OAuthClient().RequestToken(\n  new TokenSwapTokenRequest("https://your-swap-server.com/refresh", response.RefreshToken)\n);\n\nvar spotify = new SpotifyClient(newResponse.AccessToken);\n'})}),"\n",(0,o.jsx)(n.h2,{id:"server-implementation",children:"Server Implementation"}),"\n",(0,o.jsxs)(n.p,{children:["The server needs to support two endpoints, ",(0,o.jsx)(n.code,{children:"/swap"})," and ",(0,o.jsx)(n.code,{children:"/refresh"})," (endpoints can be named differently of course)."]}),"\n",(0,o.jsx)(n.h3,{id:"swap",children:"Swap"}),"\n",(0,o.jsxs)(n.p,{children:["The client sends a body via ",(0,o.jsx)(n.code,{children:"application/x-www-form-urlencoded"})," where the received ",(0,o.jsx)(n.code,{children:"code"})," is included. In cURL:"]}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-bash",children:'curl -X POST "https://example.com/v1/swap"\\\n  -H "Content-Type: application/x-www-form-urlencoded"\\\n  --data "code=AQDy8...xMhKNA"\n'})}),"\n",(0,o.jsxs)(n.p,{children:["The server needs to respond with content-type ",(0,o.jsx)(n.code,{children:"application/json"})," and the following body:"]}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-json",children:'{\n "access_token" : "NgAagA...Um_SHo",\n "expires_in" : "3600",\n "refresh_token" : "NgCXRK...MzYjw"\n}\n'})}),"\n",(0,o.jsx)(n.h3,{id:"refresh",children:"Refresh"}),"\n",(0,o.jsxs)(n.p,{children:["The client sends a body via ",(0,o.jsx)(n.code,{children:"application/x-www-form-urlencoded"})," where the received ",(0,o.jsx)(n.code,{children:"refresh_token"})," is included. In cURL:"]}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-bash",children:'curl -X POST "https://example.com/v1/refresh"\\\n  -H "Content-Type: application/x-www-form-urlencoded"\\\n  --data "refresh_token=NgCXRK...MzYjw"\n'})}),"\n",(0,o.jsxs)(n.p,{children:["The server needs to respond with content-type ",(0,o.jsx)(n.code,{children:"application/json"})," and the following body:"]}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-json",children:'{\n "access_token" : "NgAagA...Um_SHo",\n "expires_in" : "3600"\n}\n'})}),"\n",(0,o.jsx)(n.h2,{id:"example",children:"Example"}),"\n",(0,o.jsxs)(n.p,{children:["An example server has been implemented in Node.JS with a .NET CLI client, located at ",(0,o.jsx)(n.a,{href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.TokenSwap",children:"Example.TokenSwap"}),"."]})]})}function p(e={}){const{wrapper:n}={...(0,t.M)(),...e.components};return n?(0,o.jsx)(n,{...e,children:(0,o.jsx)(l,{...e})}):l(e)}},7052:(e,n,s)=>{s.d(n,{I:()=>a,M:()=>i});var o=s(6651);const t={},r=o.createContext(t);function i(e){const n=o.useContext(r);return o.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function a(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(t):e.components||t:i(e.components),o.createElement(r.Provider,{value:n},e.children)}}}]);