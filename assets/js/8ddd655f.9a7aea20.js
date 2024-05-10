"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[8192],{7384:(e,t,o)=>{o.r(t),o.d(t,{assets:()=>p,contentTitle:()=>s,default:()=>l,frontMatter:()=>i,metadata:()=>a,toc:()=>c});var n=o(2488),r=o(7052);const i={id:"proxy",title:"Proxy Settings",sidebar_label:"Proxy Settings"},s=void 0,a={id:"web/proxy",title:"Proxy Settings",description:"You can forward your proxy settings to the web api by using a field in the SpotifyLocalAPIConfig.",source:"@site/versioned_docs/version-5.1.1/web/proxy.md",sourceDirName:"web",slug:"/web/proxy",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/proxy",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/web/proxy.md",tags:[],version:"5.1.1",lastUpdatedBy:"XY Wang",lastUpdatedAt:1715323874,formattedLastUpdatedAt:"May 10, 2024",frontMatter:{id:"proxy",title:"Proxy Settings",sidebar_label:"Proxy Settings"},sidebar:"someSidebar",previous:{title:"Profiles",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/profiles"},next:{title:"Search",permalink:"/SpotifyAPI-NET/docs/5.1.1/web/search"}},p={},c=[];function d(e){const t={code:"code",p:"p",pre:"pre",...(0,r.M)(),...e.components};return(0,n.jsxs)(n.Fragment,{children:[(0,n.jsxs)(t.p,{children:["You can forward your proxy settings to the web api by using a field in the ",(0,n.jsx)(t.code,{children:"SpotifyLocalAPIConfig"}),"."]}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:'ProxyConfig proxyConfig = new ProxyConfig()\n{\n    Host = "127.0.0.1",\n    Port = 8080\n    // Additional values like Username and Password are available\n};\n\nSpotifyWebAPI api = new SpotifyWebAPI(proxyConfig);\n'})})]})}function l(e={}){const{wrapper:t}={...(0,r.M)(),...e.components};return t?(0,n.jsx)(t,{...e,children:(0,n.jsx)(d,{...e})}):d(e)}},7052:(e,t,o)=>{o.d(t,{I:()=>a,M:()=>s});var n=o(6651);const r={},i=n.createContext(r);function s(e){const t=n.useContext(i);return n.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function a(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(r):e.components||r:s(e.components),n.createElement(i.Provider,{value:t},e.children)}}}]);