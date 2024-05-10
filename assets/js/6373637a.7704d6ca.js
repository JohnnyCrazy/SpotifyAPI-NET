"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[1420],{3160:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>r,contentTitle:()=>a,default:()=>u,frontMatter:()=>o,metadata:()=>c,toc:()=>l});var i=t(2488),s=t(7052);const o={id:"client_credentials",title:"Client Credentials"},a=void 0,c={id:"client_credentials",title:"Client Credentials",description:"The Client Credentials flow is used in server-to-server authentication.",source:"@site/docs/client_credentials.md",sourceDirName:".",slug:"/client_credentials",permalink:"/SpotifyAPI-NET/docs/client_credentials",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/client_credentials.md",tags:[],version:"current",lastUpdatedBy:"XY Wang",lastUpdatedAt:1715323874,formattedLastUpdatedAt:"May 10, 2024",frontMatter:{id:"client_credentials",title:"Client Credentials"},sidebar:"docs",previous:{title:"Introduction",permalink:"/SpotifyAPI-NET/docs/auth_introduction"},next:{title:"Implicit Grant",permalink:"/SpotifyAPI-NET/docs/implicit_grant"}},r={},l=[{value:"Request token once",id:"request-token-once",level:2},{value:"Request Token On-Demand",id:"request-token-on-demand",level:2}];function d(e){const n={admonition:"admonition",blockquote:"blockquote",code:"code",h2:"h2",p:"p",pre:"pre",...(0,s.M)(),...e.components};return(0,i.jsxs)(i.Fragment,{children:[(0,i.jsxs)(n.blockquote,{children:["\n",(0,i.jsx)(n.p,{children:"The Client Credentials flow is used in server-to-server authentication.\nOnly endpoints that do not access user information can be accessed."}),"\n"]}),"\n",(0,i.jsxs)(n.p,{children:["By supplying your ",(0,i.jsx)(n.code,{children:"SPOTIFY_CLIENT_ID"})," and ",(0,i.jsx)(n.code,{children:"SPOTIFY_CLIENT_SECRET"}),", you get an access token."]}),"\n",(0,i.jsx)(n.h2,{id:"request-token-once",children:"Request token once"}),"\n",(0,i.jsxs)(n.p,{children:["To request an access token, build a ",(0,i.jsx)(n.code,{children:"ClientCredentialsRequest"})," and send it via ",(0,i.jsx)(n.code,{children:"OAuthClient"}),". This access token will expire after some time and you need to repeat the process."]}),"\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{className:"language-csharp",children:'public static async Task Main()\n{\n  var config = SpotifyClientConfig.CreateDefault();\n\n  var request = new ClientCredentialsRequest("CLIENT_ID", "CLIENT_SECRET");\n  var response = await new OAuthClient(config).RequestToken(request);\n\n  var spotify = new SpotifyClient(config.WithToken(response.AccessToken));\n}\n'})}),"\n",(0,i.jsx)(n.h2,{id:"request-token-on-demand",children:"Request Token On-Demand"}),"\n",(0,i.jsxs)(n.p,{children:["You can also use ",(0,i.jsx)(n.code,{children:"CredentialsAuthenticator"}),", which will make sure the Spotify instance will always have an up-to-date access token by automatically refreshing the token on demand."]}),"\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{className:"language-csharp",children:'public static async Task Main()\n{\n  var config = SpotifyClientConfig\n    .CreateDefault()\n    .WithAuthenticator(new ClientCredentialsAuthenticator("CLIENT_ID", "CLIENT_SECRET"));\n\n  var spotify = new SpotifyClient(config);\n}\n'})}),"\n",(0,i.jsx)(n.admonition,{type:"info",children:(0,i.jsxs)(n.p,{children:["Thread safety is not guaranteed when using ",(0,i.jsx)(n.code,{children:"CredentialsAuthenticator"}),"."]})})]})}function u(e={}){const{wrapper:n}={...(0,s.M)(),...e.components};return n?(0,i.jsx)(n,{...e,children:(0,i.jsx)(d,{...e})}):d(e)}},7052:(e,n,t)=>{t.d(n,{I:()=>c,M:()=>a});var i=t(6651);const s={},o=i.createContext(s);function a(e){const n=i.useContext(o);return i.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function c(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(s):e.components||s:a(e.components),i.createElement(o.Provider,{value:n},e.children)}}}]);