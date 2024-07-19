"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[9700],{6948:(t,e,n)=>{n.r(e),n.d(e,{assets:()=>c,contentTitle:()=>p,default:()=>u,frontMatter:()=>s,metadata:()=>a,toc:()=>d});var o=n(2488),i=n(7052),r=n(4764);const s={id:"proxy",title:"Proxy"},p=void 0,a={id:"proxy",title:"Proxy",description:"The included HTTPClient has full proxy configuration support:",source:"@site/docs/proxy.md",sourceDirName:".",slug:"/proxy",permalink:"/SpotifyAPI-NET/docs/proxy",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/proxy.md",tags:[],version:"current",lastUpdatedBy:"dependabot[bot]",lastUpdatedAt:1721422558,formattedLastUpdatedAt:"Jul 19, 2024",frontMatter:{id:"proxy",title:"Proxy"},sidebar:"docs",previous:{title:"Logging",permalink:"/SpotifyAPI-NET/docs/logging"},next:{title:"Pagination",permalink:"/SpotifyAPI-NET/docs/pagination"}},c={},d=[];function l(t){const e={a:"a",code:"code",p:"p",pre:"pre",...(0,i.M)(),...t.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsxs)(e.p,{children:["The included ",(0,o.jsx)(e.code,{children:"HTTPClient"})," has full proxy configuration support:"]}),"\n",(0,o.jsx)(e.pre,{children:(0,o.jsx)(e.code,{className:"language-csharp",children:'var httpClient = new NetHttpClient(new ProxyConfig("localhost", 8080)\n{\n  User = "",\n  Password = "",\n  SkipSSLCheck = false,\n});\nvar config = SpotifyClientConfig\n  .CreateDefault()\n  .WithHTTPClient(httpClient);\n\nvar spotify = new SpotifyClient(config);\n'})}),"\n",(0,o.jsxs)(e.p,{children:["As an example, ",(0,o.jsx)(e.a,{href:"https://mitmproxy.org/",children:"mitmproxy"})," can be used to inspect the requests and responses:"]}),"\n",(0,o.jsx)("img",{alt:"mitmproxy",src:(0,r.c)("img/mitmproxy.png")})]})}function u(t={}){const{wrapper:e}={...(0,i.M)(),...t.components};return e?(0,o.jsx)(e,{...t,children:(0,o.jsx)(l,{...t})}):l(t)}},7052:(t,e,n)=>{n.d(e,{I:()=>p,M:()=>s});var o=n(6651);const i={},r=o.createContext(i);function s(t){const e=o.useContext(r);return o.useMemo((function(){return"function"==typeof t?t(e):{...e,...t}}),[e,t])}function p(t){let e;return e=t.disableParentContext?"function"==typeof t.components?t.components(i):t.components||i:s(t.components),o.createElement(r.Provider,{value:e},t.children)}}}]);