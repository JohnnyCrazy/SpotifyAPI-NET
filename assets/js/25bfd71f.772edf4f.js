"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[1650],{2148:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>a,contentTitle:()=>r,default:()=>l,frontMatter:()=>o,metadata:()=>c,toc:()=>d});var s=n(2488),i=n(7052);const o={id:"example_cli_persistent_config",title:"CLI - Persistent Config"},r=void 0,c={id:"example_cli_persistent_config",title:"CLI - Persistent Config",description:"Description",source:"@site/docs/example_cli_persistent_config.md",sourceDirName:".",slug:"/example_cli_persistent_config",permalink:"/SpotifyAPI-NET/docs/example_cli_persistent_config",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/example_cli_persistent_config.md",tags:[],version:"current",lastUpdatedBy:"4or5trees",lastUpdatedAt:1721513023,formattedLastUpdatedAt:"Jul 20, 2024",frontMatter:{id:"example_cli_persistent_config",title:"CLI - Persistent Config"},sidebar:"docs",previous:{title:"CLI - Custom HTML",permalink:"/SpotifyAPI-NET/docs/example_cli_custom_html"},next:{title:"Token Swap",permalink:"/SpotifyAPI-NET/docs/example_token_swap"}},a={},d=[{value:"Description",id:"description",level:2},{value:"Run it",id:"run-it",level:2}];function p(e){const t={a:"a",code:"code",h2:"h2",p:"p",pre:"pre",...(0,i.M)(),...e.components};return(0,s.jsxs)(s.Fragment,{children:[(0,s.jsx)(t.h2,{id:"description",children:"Description"}),"\n",(0,s.jsxs)(t.p,{children:["An example to show how an obtained access and refresh token can be stored persistently and re-used across application restarts. This results in fewer requests to spotifys authentication endpoints and a faster experience for the user. The example uses ",(0,s.jsx)(t.a,{href:"/SpotifyAPI-NET/docs/pkce",children:"PKCE"})," in combination with the ",(0,s.jsx)(t.code,{children:"PKCEAuthenticator"}),", which automatically refreshes expired tokens."]}),"\n",(0,s.jsxs)(t.p,{children:["The access and refresh token is saved in a ",(0,s.jsx)(t.code,{children:"credentials.json"})," file of the current working directory."]}),"\n",(0,s.jsx)(t.h2,{id:"run-it",children:"Run it"}),"\n",(0,s.jsxs)(t.p,{children:["Before running it, make sure you created an app in your ",(0,s.jsx)(t.a,{href:"https://developer.spotify.com/dashboard/",children:"spotify dashboard"})," and ",(0,s.jsx)(t.code,{children:"https://localhost:5543"})," is a redirect uri of it."]}),"\n",(0,s.jsx)(t.pre,{children:(0,s.jsx)(t.code,{className:"language-bash",children:"# Assumes linux and current working directory is the cloned repository\ncd SpotifyAPI.Web.Examples/Example.CLI.PersistentConfig\ndotnet restore\n\nSPOTIFY_CLIENT_ID=YourClientId dotnet run\n# A browser window should appear\n# Restarting the process should NOT open a new authentication window\n# Instead, the local `crendentials.json` file is used\nSPOTIFY_CLIENT_ID=YourClientId dotnet run\n"})})]})}function l(e={}){const{wrapper:t}={...(0,i.M)(),...e.components};return t?(0,s.jsx)(t,{...e,children:(0,s.jsx)(p,{...e})}):p(e)}},7052:(e,t,n)=>{n.d(t,{I:()=>c,M:()=>r});var s=n(6651);const i={},o=s.createContext(i);function r(e){const t=s.useContext(o);return s.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function c(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(i):e.components||i:r(e.components),s.createElement(o.Provider,{value:t},e.children)}}}]);