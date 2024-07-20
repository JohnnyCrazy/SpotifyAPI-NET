"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[5104],{2820:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>a,default:()=>h,frontMatter:()=>i,metadata:()=>s,toc:()=>l});var o=n(2488),r=n(7052);const i={id:"pkce",title:"PKCE"},a=void 0,s={id:"pkce",title:"PKCE",description:"The authorization code flow with PKCE is the best option for mobile and desktop applications where it is unsafe to store your client secret. It provides your app with an access token that can be refreshed. For further information about this flow, see IETF RFC-7636.",source:"@site/docs/pkce.md",sourceDirName:".",slug:"/pkce",permalink:"/SpotifyAPI-NET/docs/pkce",draft:!1,unlisted:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/pkce.md",tags:[],version:"current",lastUpdatedBy:"4or5trees",lastUpdatedAt:1721513023,formattedLastUpdatedAt:"Jul 20, 2024",frontMatter:{id:"pkce",title:"PKCE"},sidebar:"docs",previous:{title:"Authorization Code",permalink:"/SpotifyAPI-NET/docs/authorization_code"},next:{title:"Token Swap",permalink:"/SpotifyAPI-NET/docs/token_swap"}},c={},l=[{value:"Generating Challenge &amp; Verifier",id:"generating-challenge--verifier",level:2},{value:"Generating Login URI",id:"generating-login-uri",level:2}];function d(e){const t={a:"a",blockquote:"blockquote",code:"code",h2:"h2",p:"p",pre:"pre",...(0,r.M)(),...e.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsxs)(t.blockquote,{children:["\n",(0,o.jsxs)(t.p,{children:["The authorization code flow with PKCE is the best option for mobile and desktop applications where it is unsafe to store your client secret. It provides your app with an access token that can be refreshed. For further information about this flow, see ",(0,o.jsx)(t.a,{href:"https://tools.ietf.org/html/rfc7636",children:"IETF RFC-7636"}),"."]}),"\n"]}),"\n",(0,o.jsx)(t.h2,{id:"generating-challenge--verifier",children:"Generating Challenge & Verifier"}),"\n",(0,o.jsxs)(t.p,{children:["For every authentication request, a verify code and its challenge code needs to be generated. The class ",(0,o.jsx)(t.code,{children:"PKCEUtil"})," can be used to generate those, either with random generated or self supplied values:"]}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:'// Generates a secure random verifier of length 100 and its challenge\nvar (verifier, challenge) = PKCEUtil.GenerateCodes();\n\n// Generates a secure random verifier of length 120 and its challenge\nvar (verifier, challenge) = PKCEUtil.GenerateCodes(120);\n\n// Returns the passed string and its challenge (Make sure it\'s random and long enough)\nvar (verifier, challenge) = PKCEUtil.GenerateCodes("YourSecureRandomString");\n'})}),"\n",(0,o.jsx)(t.h2,{id:"generating-login-uri",children:"Generating Login URI"}),"\n",(0,o.jsx)(t.p,{children:"Like most auth flows, you'll need to redirect your user to Spotify's servers so they are able to grant access to your application:"}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:'// Make sure "http://localhost:5543/callback" is in your applications redirect URIs!\nvar loginRequest = new LoginRequest(\n  new Uri("http://localhost:5543/callback"),\n  "YourClientId",\n  LoginRequest.ResponseType.Code\n)\n{\n  CodeChallengeMethod = "S256",\n  CodeChallenge = challenge,\n  Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }\n};\nvar uri = loginRequest.ToUri();\n// Redirect user to uri via your favorite web-server or open a local browser window\n'})}),"\n",(0,o.jsxs)(t.p,{children:["When the user is redirected to the generated uri, they will have to login with their Spotify account and confirm that your application wants to access their user data. Once confirmed, they will be redirected to ",(0,o.jsx)(t.code,{children:"http://localhost:5543/callback"})," and a ",(0,o.jsx)(t.code,{children:"code"})," parameter is attached to the query. The redirect URI can also contain a custom protocol paired with UWP App Custom Protocol handler. This received ",(0,o.jsx)(t.code,{children:"code"})," has to be exchanged for an ",(0,o.jsx)(t.code,{children:"access_token"})," and ",(0,o.jsx)(t.code,{children:"refresh_token"}),":"]}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:'// This method should be called from your web-server when the user visits "http://localhost:5543/callback"\npublic Task GetCallback(string code)\n{\n  // Note that we use the verifier calculated above!\n  var initialResponse = await new OAuthClient().RequestToken(\n    new PKCETokenRequest("ClientId", code, "http://localhost:5543", verifier)\n  );\n\n  var spotify = new SpotifyClient(initialResponse.AccessToken);\n  // Also important for later: response.RefreshToken\n}\n'})}),"\n",(0,o.jsx)(t.p,{children:"With PKCE you can also refresh tokens once they're expired:"}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:'var newResponse = await new OAuthClient().RequestToken(\n  new PKCETokenRefreshRequest("ClientId", initialResponse.RefreshToken)\n);\n\nvar spotify = new SpotifyClient(newResponse.AccessToken);\n'})}),"\n",(0,o.jsxs)(t.p,{children:["If you do not want to take care of manually refreshing tokens, you can use ",(0,o.jsx)(t.code,{children:"PKCEAuthenticator"}),":"]}),"\n",(0,o.jsx)(t.pre,{children:(0,o.jsx)(t.code,{className:"language-csharp",children:"var authenticator = new PKCEAuthenticator(clientId, initialResponse);\n\nvar config = SpotifyClientConfig.CreateDefault()\n  .WithAuthenticator(authenticator);\nvar spotify = new SpotifyClient(config);\n"})})]})}function h(e={}){const{wrapper:t}={...(0,r.M)(),...e.components};return t?(0,o.jsx)(t,{...e,children:(0,o.jsx)(d,{...e})}):d(e)}},7052:(e,t,n)=>{n.d(t,{I:()=>s,M:()=>a});var o=n(6651);const r={},i=o.createContext(r);function a(e){const t=o.useContext(i);return o.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function s(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(r):e.components||r:a(e.components),o.createElement(i.Provider,{value:t},e.children)}}}]);