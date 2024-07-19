"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[5288],{1716:(t,e,n)=>{n.r(e),n.d(e,{assets:()=>c,contentTitle:()=>r,default:()=>l,frontMatter:()=>o,metadata:()=>s,toc:()=>d});var i=n(2488),a=n(7052);const o={id:"implicit_grant",title:"Implicit Grant",sidebar_label:"Implicit Grant"},r=void 0,s={id:"auth/implicit_grant",title:"Implicit Grant",description:"This way is recommended and the only auth-process which does not need a server-side exchange of keys. With this approach, you directly get a Token object after the user authed your application.",source:"@site/versioned_docs/version-5.1.1/auth/implicit_grant.md",sourceDirName:"auth",slug:"/auth/implicit_grant",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/implicit_grant",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/auth/implicit_grant.md",tags:[],version:"5.1.1",lastUpdatedBy:"dependabot[bot]",lastUpdatedAt:1721422558,formattedLastUpdatedAt:"Jul 19, 2024",frontMatter:{id:"implicit_grant",title:"Implicit Grant",sidebar_label:"Implicit Grant"},sidebar:"someSidebar",previous:{title:"Getting Started",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/getting_started"},next:{title:"Authorization Code",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/authorization_code"}},c={},d=[];function p(t){const e={a:"a",code:"code",p:"p",pre:"pre",strong:"strong",...(0,a.M)(),...t.components};return(0,i.jsxs)(i.Fragment,{children:[(0,i.jsxs)(e.p,{children:["This way is ",(0,i.jsx)(e.strong,{children:"recommended"})," and the only auth-process which does not need a server-side exchange of keys. With this approach, you directly get a Token object after the user authed your application.\nYou won't be able to refresh the token. If you want to use the internal Http server, please add \"",(0,i.jsx)(e.a,{href:"http://localhost:YOURPORT",children:"http://localhost:YOURPORT"}),'" to your application redirect URIs.']}),"\n",(0,i.jsxs)(e.p,{children:["More info: ",(0,i.jsx)(e.a,{href:"https://developer.spotify.com/documentation/general/guides/authorization-guide/#implicit-grant-flow",children:"here"})]}),"\n",(0,i.jsx)(e.pre,{children:(0,i.jsx)(e.code,{className:"language-csharp",children:'static async void Main(string[] args)\n{\n  ImplicitGrantAuth auth = new ImplicitGrantAuth(\n    _clientId,\n    "http://localhost:4002",\n    "http://localhost:4002",\n    Scope.UserReadPrivate\n  );\n  auth.AuthReceived += async (sender, payload) =>\n  {\n    auth.Stop(); // `sender` is also the auth instance\n    SpotifyWebAPI api = new SpotifyWebAPI()\n    {\n      TokenType = payload.TokenType,\n      AccessToken = payload.AccessToken\n    };\n    // Do requests with API client\n  };\n  auth.Start(); // Starts an internal HTTP Server\n  auth.OpenBrowser();\n}\n'})})]})}function l(t={}){const{wrapper:e}={...(0,a.M)(),...t.components};return e?(0,i.jsx)(e,{...t,children:(0,i.jsx)(p,{...t})}):p(t)}},7052:(t,e,n)=>{n.d(e,{I:()=>s,M:()=>r});var i=n(6651);const a={},o=i.createContext(a);function r(t){const e=i.useContext(o);return i.useMemo((function(){return"function"==typeof t?t(e):{...e,...t}}),[e,t])}function s(t){let e;return e=t.disableParentContext?"function"==typeof t.components?t.components(a):t.components||a:r(t.components),i.createElement(o.Provider,{value:e},t.children)}}}]);