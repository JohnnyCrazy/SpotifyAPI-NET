"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[5828],{3364:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>r,default:()=>u,frontMatter:()=>s,metadata:()=>a,toc:()=>d});var o=n(2488),i=n(7052);const s={id:"client_credentials",title:"Client Credentials"},r=void 0,a={id:"auth/client_credentials",title:"Client Credentials",description:"With this approach, you make a POST Request with a base64 encoded string (consists of ClientId + ClientSecret). You will directly get the token (Without a local HTTP Server), but it will expire and can't be refreshed.",source:"@site/versioned_docs/version-5.1.1/auth/client_credentials.md",sourceDirName:"auth",slug:"/auth/client_credentials",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/client_credentials",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/auth/client_credentials.md",tags:[],version:"5.1.1",lastUpdatedBy:"dependabot[bot]",lastUpdatedAt:1712511195,formattedLastUpdatedAt:"Apr 7, 2024",frontMatter:{id:"client_credentials",title:"Client Credentials"},sidebar:"someSidebar",previous:{title:"Authorization Code",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/authorization_code"},next:{title:"Token Swap",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/token_swap"}},c={},d=[];function l(e){const t={a:"a",code:"code",p:"p",pre:"pre",strong:"strong",...(0,i.M)(),...e.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsxs)(t.p,{children:["With this approach, you make a POST Request with a base64 encoded string (consists of ClientId + ClientSecret). You will directly get the token (Without a local HTTP Server), but it will expire and can't be refreshed.\nIf you want to use it securely, you would need to do it all server-side.\n",(0,o.jsx)(t.strong,{children:"NOTE:"})," You will only be able to query non-user-related information e.g search for a Track."]}),"\n",(0,o.jsxs)(t.p,{children:["More info: ",(0,o.jsx)(t.a,{href:"https://developer.spotify.com/documentation/general/guides/authorization-guide/#client-credentials-flow",children:"here"})]}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:"CredentialsAuth auth = new CredentialsAuth(_clientId, _secretId);\nToken token = await auth.GetToken();\nSpotifyWebAPI api = new SpotifyWebAPI()\n{\n  TokenType = token.TokenType,\n  AccessToken = token.AccessToken\n};\n"})})]})}function u(e={}){const{wrapper:t}={...(0,i.M)(),...e.components};return t?(0,o.jsx)(t,{...e,children:(0,o.jsx)(l,{...e})}):l(e)}},7052:(e,t,n)=>{n.d(t,{I:()=>a,M:()=>r});var o=n(6651);const i={},s=o.createContext(i);function r(e){const t=o.useContext(s);return o.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function a(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(i):e.components||i:r(e.components),o.createElement(s.Provider,{value:t},e.children)}}}]);