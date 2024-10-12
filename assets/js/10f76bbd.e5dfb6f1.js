"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[5427],{6193:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>i,default:()=>l,frontMatter:()=>r,metadata:()=>a,toc:()=>h});var o=n(3274),s=n(2438);const r={id:"token_swap",title:"Token Swap"},i=void 0,a={id:"auth/token_swap",title:"Token Swap",description:"This way uses server-side code or at least access to an exchange server, otherwise, compared to other",source:"@site/versioned_docs/version-5.1.1/auth/token_swap.md",sourceDirName:"auth",slug:"/auth/token_swap",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/token_swap",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/versioned_docs/version-5.1.1/auth/token_swap.md",tags:[],version:"5.1.1",lastUpdatedBy:"Jonas Dellinger",lastUpdatedAt:1617911058,formattedLastUpdatedAt:"Apr 8, 2021",frontMatter:{id:"token_swap",title:"Token Swap"},sidebar:"someSidebar",previous:{title:"Client Credentials",permalink:"/SpotifyAPI-NET/docs/5.1.1/auth/client_credentials"}},c={},h=[{value:"Using TokenSwapWebAPIFactory",id:"using-tokenswapwebapifactory",level:2},{value:"Using TokenSwapAuth",id:"using-tokenswapauth",level:2},{value:"Token Swap Endpoint",id:"token-swap-endpoint",level:2},{value:"Remarks",id:"remarks",level:2}];function d(e){const t={a:"a",code:"code",h2:"h2",li:"li",p:"p",pre:"pre",strong:"strong",ul:"ul",...(0,s.R)(),...e.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsx)(t.p,{children:"This way uses server-side code or at least access to an exchange server, otherwise, compared to other\nmethods, it is impossible to use."}),"\n",(0,o.jsx)(t.p,{children:'With this approach, you provide the URI/URL to your desired exchange server to perform all necessary\nrequests to Spotify, as well as requests that return back to the "server URI".'}),"\n",(0,o.jsxs)(t.p,{children:["The exchange server ",(0,o.jsx)(t.strong,{children:"must"})," be able to:"]}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsx)(t.li,{children:'Return the authorization code from Spotify API authenticate page via GET request to the "server URI".'}),"\n",(0,o.jsx)(t.li,{children:"Request the token response object via POST to the Spotify API token page."}),"\n",(0,o.jsx)(t.li,{children:"Request a refreshed token response object via POST to the Spotify API token page."}),"\n"]}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.strong,{children:"The good news is that you do not need to code it yourself."})}),"\n",(0,o.jsxs)(t.p,{children:["The advantages of this method are that the client ID and redirect URI are very well hidden and almost unexposed, but more importantly, your client secret is ",(0,o.jsx)(t.strong,{children:"never"})," exposed and is completely hidden compared to other methods (excluding ",(0,o.jsx)(t.a,{href:"/SpotifyAPI-NET/docs/5.1.1/auth/implicit_grant",children:"ImplicitGrantAuth"}),"\nas it does not deal with a client secret). This means\nyour Spotify app ",(0,o.jsx)(t.strong,{children:"cannot"})," be spoofed by a malicious third party."]}),"\n",(0,o.jsx)(t.h2,{id:"using-tokenswapwebapifactory",children:"Using TokenSwapWebAPIFactory"}),"\n",(0,o.jsx)(t.p,{children:"The TokenSwapWebAPIFactory will create and configure a SpotifyWebAPI object for you."}),"\n",(0,o.jsxs)(t.p,{children:["It does this through the method GetWebApiAsync ",(0,o.jsx)(t.strong,{children:"asynchronously"}),", which means it will not halt execution of your program while obtaining it for you. If you would like to halt execution, which is ",(0,o.jsx)(t.strong,{children:"synchronous"}),", use ",(0,o.jsx)(t.code,{children:"GetWebApiAsync().Result"})," without using ",(0,o.jsx)(t.strong,{children:"await"}),"."]}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:'TokenSwapWebAPIFactory webApiFactory;\nSpotifyWebAPI spotify;\n\n// You should store a reference to WebAPIFactory if you are using AutoRefresh or want to manually refresh it later on. New WebAPIFactory objects cannot refresh SpotifyWebAPI object that they did not give to you.\nwebApiFactory = new TokenSwapWebAPIFactory("INSERT LINK TO YOUR index.php HERE")\n{\n    Scope = Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate,\n    AutoRefresh = true\n};\n// You may want to react to being able to use the Spotify service.\n// webApiFactory.OnAuthSuccess += (sender, e) => authorized = true;\n// You may want to react to your user\'s access expiring.\n// webApiFactory.OnAccessTokenExpired += (sender, e) => authorized = false;\n\ntry\n{\n    spotify = await webApiFactory.GetWebApiAsync();\n    // Synchronous way:\n    // spotify = webApiFactory.GetWebApiAsync().Result;\n}\ncatch (Exception ex)\n{\n    // Example way to handle error reporting gracefully with your SpotifyWebAPI wrapper\n    // UpdateStatus($"Spotify failed to load: {ex.Message}");\n}\n'})}),"\n",(0,o.jsx)(t.h2,{id:"using-tokenswapauth",children:"Using TokenSwapAuth"}),"\n",(0,o.jsx)(t.p,{children:"Since the TokenSwapWebAPIFactory not only simplifies the whole process but offers additional functionality too\n(such as AutoRefresh and AuthSuccess AuthFailure events), use of this way is very verbose and is only\nrecommended if you are having issues with TokenSwapWebAPIFactory or need access to the tokens."}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:'TokenSwapAuth auth = new TokenSwapAuth(\n    exchangeServerUri: "INSERT LINK TO YOUR index.php HERE",\n    serverUri: "http://localhost:4002",\n    scope: Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate\n);\nauth.AuthReceived += async (sender, response) =>\n{\n    lastToken = await auth.ExchangeCodeAsync(response.Code);\n\n    spotify = new SpotifyWebAPI()\n    {\n        TokenType = lastToken.TokenType,\n        AccessToken = lastToken.AccessToken\n    };\n\n    authenticated = true;\n    auth.Stop();\n};\nauth.OnAccessTokenExpired += async (sender, e) => spotify.AccessToken = (await auth.RefreshAuthAsync(lastToken.RefreshToken)).AccessToken;\nauth.Start();\nauth.OpenBrowser();\n'})}),"\n",(0,o.jsx)(t.h2,{id:"token-swap-endpoint",children:"Token Swap Endpoint"}),"\n",(0,o.jsx)(t.p,{children:"To keep your client secret completely secure and your client ID and redirect URI as secure as possible, use of a web server (such as a php website) is required."}),"\n",(0,o.jsx)(t.p,{children:"To use this method, an external HTTP Server (that you may need to create) needs to be able to supply the following HTTP Endpoints to your application:"}),"\n",(0,o.jsxs)(t.p,{children:[(0,o.jsx)(t.code,{children:"/swap"})," - Swaps out an ",(0,o.jsx)(t.code,{children:"authorization_code"})," with an ",(0,o.jsx)(t.code,{children:"access_token"})," and ",(0,o.jsx)(t.code,{children:"refresh_token"})," - The following parameters are required in the JSON POST Body:"]}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsxs)(t.li,{children:[(0,o.jsx)(t.code,{children:"grant_type"})," (set to ",(0,o.jsx)(t.code,{children:'"authorization_code"'}),")"]}),"\n",(0,o.jsxs)(t.li,{children:[(0,o.jsx)(t.code,{children:"code"})," (the ",(0,o.jsx)(t.code,{children:"authorization_code"}),")"]}),"\n",(0,o.jsx)(t.li,{children:(0,o.jsx)(t.code,{children:"redirect_uri"})}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsxs)(t.li,{children:[(0,o.jsx)(t.strong,{children:"Important"})," The page that the redirect URI links to must return the authorization code json to your ",(0,o.jsx)(t.code,{children:"serverUri"})," (default is '",(0,o.jsx)(t.a,{href:"http://localhost:4002",children:"http://localhost:4002"}),"') but to the folder 'auth', like this: '",(0,o.jsx)(t.a,{href:"http://localhost:4002/auth",children:"http://localhost:4002/auth"}),"'."]}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,o.jsxs)(t.p,{children:[(0,o.jsx)(t.code,{children:"/refresh"})," - Refreshes an ",(0,o.jsx)(t.code,{children:"access_token"})," - The following parameters are required in the JSON POST Body:"]}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsxs)(t.li,{children:[(0,o.jsx)(t.code,{children:"grant_type"})," (set to ",(0,o.jsx)(t.code,{children:'"refresh_token"'}),")"]}),"\n",(0,o.jsx)(t.li,{children:(0,o.jsx)(t.code,{children:"refresh_token"})}),"\n"]}),"\n",(0,o.jsx)(t.p,{children:"The following open-source token swap endpoint code can be used for your website:"}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsx)(t.li,{children:(0,o.jsx)(t.a,{href:"https://github.com/rollersteaam/spotify-token-swap-php",children:"rollersteaam/spotify-token-swap-php"})}),"\n",(0,o.jsx)(t.li,{children:(0,o.jsx)(t.a,{href:"https://github.com/simontaen/SpotifyTokenSwap",children:"simontaen/SpotifyTokenSwap"})}),"\n"]}),"\n",(0,o.jsx)(t.h2,{id:"remarks",children:"Remarks"}),"\n",(0,o.jsx)(t.p,{children:"It should be noted that GitHub Pages does not support hosting php scripts. Hosting php scripts through it will cause the php to render as plain HTML, potentially compromising your client secret while doing absolutely nothing."}),"\n",(0,o.jsx)(t.p,{children:"Be sure you have whitelisted your redirect uri in the Spotify Developer Dashboard otherwise the authorization will always fail."}),"\n",(0,o.jsxs)(t.p,{children:["If you did not use the WebAPIFactory or you provided a ",(0,o.jsx)(t.code,{children:"serverUri"})," different from its default, you must make sure your redirect uri's script at your endpoint will properly redirect to your ",(0,o.jsx)(t.code,{children:"serverUri"})," (such as changing the areas which refer to ",(0,o.jsx)(t.code,{children:"localhost:4002"})," if you had changed ",(0,o.jsx)(t.code,{children:"serverUri"})," from its default), otherwise it will never reach your new ",(0,o.jsx)(t.code,{children:"serverUri"}),"."]})]})}function l(e={}){const{wrapper:t}={...(0,s.R)(),...e.components};return t?(0,o.jsx)(t,{...e,children:(0,o.jsx)(d,{...e})}):d(e)}},2438:(e,t,n)=>{n.d(t,{R:()=>i,x:()=>a});var o=n(9474);const s={},r=o.createContext(s);function i(e){const t=o.useContext(r);return o.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function a(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(s):e.components||s:i(e.components),o.createElement(r.Provider,{value:t},e.children)}}}]);