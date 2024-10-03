"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[6064],{8268:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>s,default:()=>u,frontMatter:()=>a,metadata:()=>r,toc:()=>d});var o=n(2488),i=n(7052);const a={id:"authorization_code",title:"Authorization Code"},s=void 0,r={id:"auth/authorization_code",title:"Authorization Code",description:"This way is not recommended for client-side apps and requires server-side code to run securely.",source:"@site/versioned_docs/version-5.1.1/auth/authorization_code.md",sourceDirName:"auth",slug:"/auth/authorization_code",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/authorization_code",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/auth/authorization_code.md",tags:[],version:"5.1.1",lastUpdatedBy:"dependabot[bot]",lastUpdatedAt:1727960431,formattedLastUpdatedAt:"Oct 3, 2024",frontMatter:{id:"authorization_code",title:"Authorization Code"},sidebar:"someSidebar",previous:{title:"Implicit Grant",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/implicit_grant"},next:{title:"Client Credentials",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/client_credentials"}},c={},d=[{value:"Token Refresh",id:"token-refresh",level:2}];function h(e){const t={a:"a",code:"code",h2:"h2",p:"p",pre:"pre",strong:"strong",...(0,i.M)(),...e.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsxs)(t.p,{children:["This way is ",(0,o.jsx)(t.strong,{children:"not recommended"})," for client-side apps and requires server-side code to run securely.\nWith this approach, you first get a code which you need to trade against the access-token.\nIn this exchange you need to provide your Client-Secret and because of that it's not recommended.\nA good thing about this method: You can always refresh your token, without having the user to auth it again."]}),"\n",(0,o.jsxs)(t.p,{children:["More info: ",(0,o.jsx)(t.a,{href:"https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow",children:"here"})]}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:'static async void Main(string[] args)\n{\n    AuthorizationCodeAuth auth = new AuthorizationCodeAuth(\n      _clientId,\n      _secretId,\n      "http://localhost:4002",\n      "http://localhost:4002",\n      Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative\n    );\n\n    auth.AuthReceived += async (sender, payload) =>\n    {\n        auth.Stop();\n        Token token = await auth.ExchangeCode(payload.Code);\n        SpotifyWebAPI api = new SpotifyWebAPI()\n        {\n          TokenType = token.TokenType,\n          AccessToken = token.AccessToken\n        };\n        // Do requests with API client\n    };\n    auth.Start(); // Starts an internal HTTP Server\n    auth.OpenBrowser();\n}\n'})}),"\n",(0,o.jsx)(t.h2,{id:"token-refresh",children:"Token Refresh"}),"\n",(0,o.jsxs)(t.p,{children:["Once the ",(0,o.jsx)(t.code,{children:"AccessToken"})," is expired, you can use your ",(0,o.jsx)(t.code,{children:"RefreshToken"})," to get a new one.\nIn this procedure, no HTTP Server is needed in the background and a single HTTP Request is made."]}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:"// Auth code from above\n\nif(token.IsExpired())\n{\n  Token newToken = await auth.RefreshToken(token.RefreshToken);\n  api.AccessToken = newToken.AccessToken\n  api.TokenType = newToken.TokenType\n}\n"})})]})}function u(e={}){const{wrapper:t}={...(0,i.M)(),...e.components};return t?(0,o.jsx)(t,{...e,children:(0,o.jsx)(h,{...e})}):h(e)}},7052:(e,t,n)=>{n.d(t,{I:()=>r,M:()=>s});var o=n(6651);const i={},a=o.createContext(i);function s(e){const t=o.useContext(a);return o.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function r(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(i):e.components||i:s(e.components),o.createElement(a.Provider,{value:t},e.children)}}}]);