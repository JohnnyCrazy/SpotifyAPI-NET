"use strict";(self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[]).push([[5249],{3905:function(e,t,n){n.d(t,{Zo:function(){return c},kt:function(){return m}});var r=n(7294);function i(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function a(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?a(Object(n),!0).forEach((function(t){i(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):a(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,r,i=function(e,t){if(null==e)return{};var n,r,i={},a=Object.keys(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||(i[n]=e[n]);return i}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(i[n]=e[n])}return i}var l=r.createContext({}),p=function(e){var t=r.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},c=function(e){var t=p(e.components);return r.createElement(l.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},d=r.forwardRef((function(e,t){var n=e.components,i=e.mdxType,a=e.originalType,l=e.parentName,c=s(e,["components","mdxType","originalType","parentName"]),d=p(n),m=i,h=d["".concat(l,".").concat(m)]||d[m]||u[m]||a;return n?r.createElement(h,o(o({ref:t},c),{},{components:n})):r.createElement(h,o({ref:t},c))}));function m(e,t){var n=arguments,i=t&&t.mdxType;if("string"==typeof e||i){var a=n.length,o=new Array(a);o[0]=d;var s={};for(var l in t)hasOwnProperty.call(t,l)&&(s[l]=t[l]);s.originalType=e,s.mdxType="string"==typeof e?e:i,o[1]=s;for(var p=2;p<a;p++)o[p]=n[p];return r.createElement.apply(null,o)}return r.createElement.apply(null,n)}d.displayName="MDXCreateElement"},6961:function(e,t,n){n.r(t),n.d(t,{assets:function(){return u},contentTitle:function(){return p},default:function(){return h},frontMatter:function(){return l},metadata:function(){return c},toc:function(){return d}});var r=n(7462),i=n(3366),a=(n(7294),n(3905)),o=n(4996),s=["components"],l={id:"implicit_grant",title:"Implicit Grant"},p=void 0,c={unversionedId:"implicit_grant",id:"implicit_grant",title:"Implicit Grant",description:"Implicit grant flow is for clients that are implemented entirely using JavaScript and running in the resource owner\u2019s browser. You do not need any server-side code to use it. Rate limits for requests are improved but there is no refresh token provided. This flow is described in RFC-6749.",source:"@site/docs/implicit_grant.md",sourceDirName:".",slug:"/implicit_grant",permalink:"/SpotifyAPI-NET/docs/implicit_grant",draft:!1,editUrl:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/docs/implicit_grant.md",tags:[],version:"current",lastUpdatedBy:"Jonas Dellinger",lastUpdatedAt:1668768720,formattedLastUpdatedAt:"11/18/2022",frontMatter:{id:"implicit_grant",title:"Implicit Grant"},sidebar:"docs",previous:{title:"Client Credentials",permalink:"/SpotifyAPI-NET/docs/client_credentials"},next:{title:"Authorization Code",permalink:"/SpotifyAPI-NET/docs/authorization_code"}},u={},d=[{value:"Existing Web-Server",id:"existing-web-server",level:2},{value:"Using custom Protocols",id:"using-custom-protocols",level:2}],m={toc:d};function h(e){var t=e.components,n=(0,i.Z)(e,s);return(0,a.kt)("wrapper",(0,r.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("blockquote",null,(0,a.kt)("p",{parentName:"blockquote"},"Implicit grant flow is for clients that are implemented entirely using JavaScript and running in the resource owner\u2019s browser. You do not need any server-side code to use it. Rate limits for requests are improved but there is no refresh token provided. This flow is described in ",(0,a.kt)("a",{parentName:"p",href:"http://tools.ietf.org/html/rfc6749#section-4.2"},"RFC-6749"),".")),(0,a.kt)("p",null,"This flow is useful for getting a user access token for a short timespan."),(0,a.kt)("h2",{id:"existing-web-server"},"Existing Web-Server"),(0,a.kt)("p",null,"If you are already in control of a Web-Server (like ",(0,a.kt)("inlineCode",{parentName:"p"},"ASP.NET"),"), you can start the flow by generating a login uri:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},'// Make sure "http://localhost:5000" is in your applications redirect URIs!\nvar loginRequest = new LoginRequest(\n  new Uri("http://localhost:5000"),\n  "ClientId",\n  LoginRequest.ResponseType.Token\n)\n{\n  Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }\n};\nvar uri = loginRequest.ToUri();\n// Redirect user to uri via your favorite web-server\n')),(0,a.kt)("p",null,"When the user is redirected to the generated uri, they will have to login with their Spotify account and confirm that your application wants to access their user data. Once confirmed, they will be redirected to ",(0,a.kt)("inlineCode",{parentName:"p"},"http://localhost:5000")," and the fragment identifier (",(0,a.kt)("inlineCode",{parentName:"p"},"#")," part of URI) will contain an access token."),(0,a.kt)("div",{className:"admonition admonition-warning alert alert--danger"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M5.05.31c.81 2.17.41 3.38-.52 4.31C3.55 5.67 1.98 6.45.9 7.98c-1.45 2.05-1.7 6.53 3.53 7.7-2.2-1.16-2.67-4.52-.3-6.61-.61 2.03.53 3.33 1.94 2.86 1.39-.47 2.3.53 2.27 1.67-.02.78-.31 1.44-1.13 1.81 3.42-.59 4.78-3.42 4.78-5.56 0-2.84-2.53-3.22-1.25-5.61-1.52.13-2.03 1.13-1.89 2.75.09 1.08-1.02 1.8-1.86 1.33-.67-.41-.66-1.19-.06-1.78C8.18 5.31 8.68 2.45 5.05.32L5.03.3l.02.01z"}))),"warning")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"Note, this parameter is not sent to the server! You need JavaScript to access it."))),(0,a.kt)("h2",{id:"using-custom-protocols"},"Using custom Protocols"),(0,a.kt)("p",null,"This flow can also be used with custom protocols instead of ",(0,a.kt)("inlineCode",{parentName:"p"},"http"),"/",(0,a.kt)("inlineCode",{parentName:"p"},"https"),". This is especially interesting for ",(0,a.kt)("inlineCode",{parentName:"p"},"UWP")," apps, since your able to register custom protocol handlers quite easily."),(0,a.kt)("img",{alt:"protocol handlers",src:(0,o.Z)("img/auth_protocol_handlers.png")}),(0,a.kt)("p",null,"The process is very similar, you generate a uri and open it for the user:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},'// Make sure "spotifyapi.web.oauth://token" is in your applications redirect URIs!\nvar loginRequest = new LoginRequest(\n  new Uri("spotifyapi.web.oauth://token"),\n  "ClientId",\n  LoginRequest.ResponseType.Token\n)\n{\n  Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }\n};\nvar uri = loginRequest.ToUri();\n\n// This call requires Spotify.Web.Auth\nBrowserUtil.Open(uri);\n')),(0,a.kt)("p",null,"After the user has logged in and consented your app, your ",(0,a.kt)("inlineCode",{parentName:"p"},"UWP")," app will receive a callback:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},"protected override void OnActivated(IActivatedEventArgs args)\n{\n  if (args.Kind == ActivationKind.Protocol)\n  {\n    ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;\n    var publisher = Mvx.IoCProvider.Resolve<ITokenPublisherService>();\n\n    // This Uri contains your access token in the Fragment part\n    Console.WriteLine(eventArgs.Uri);\n  }\n}\n")),(0,a.kt)("p",null,"For a real example, have a look at the ",(0,a.kt)("a",{parentName:"p",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.UWP"},"Example.UWP"),", ",(0,a.kt)("a",{parentName:"p",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.ASP"},"Example.ASP")," or ",(0,a.kt)("a",{parentName:"p",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.ASPBlazor"},"Example.ASPBlazor")),(0,a.kt)("h1",{id:"using-spotifywebauth"},"Using Spotify.Web.Auth"),(0,a.kt)("p",null,"For cross-platform CLI and desktop apps (non ",(0,a.kt)("inlineCode",{parentName:"p"},"UWP")," apps), custom protocol handlers are sometimes not an option. The fallback here is a small cross-platform embedded web server running on ",(0,a.kt)("inlineCode",{parentName:"p"},"http://localhost:5000")," serving JavaScript. The JavaScript will parse the fragment part of the URI and sends a request to the web server in the background. The web server then notifies your appliciation via an event."),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},'private static EmbedIOAuthServer _server;\n\npublic static async Task Main()\n{\n  // Make sure "http://localhost:5000/callback" is in your spotify application as redirect uri!\n  _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);\n  await _server.Start();\n\n  _server.ImplictGrantReceived += OnImplicitGrantReceived;\n  _server.ErrorReceived += OnErrorReceived;\n\n  var request = new LoginRequest(_server.BaseUri, "ClientId", LoginRequest.ResponseType.Token)\n  {\n    Scope = new List<string> { Scopes.UserReadEmail }\n  };\n  BrowserUtil.Open(request.ToUri());\n}\n\nprivate static async Task OnImplicitGrantReceived(object sender, ImplictGrantResponse response)\n{\n  await _server.Stop();\n  var spotify = new SpotifyClient(response.AccessToken);\n  // do calls with Spotify\n}\n\nprivate static async Task OnErrorReceived(object sender, string error, string state)\n{\n  Console.WriteLine($"Aborting authorization, error received: {error}");\n  await _server.Stop();\n}\n')),(0,a.kt)("p",null,"For real examples, have a look at ",(0,a.kt)("a",{parentName:"p",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.CLI.PersistentConfig"},"Example.CLI.PersistentConfig")," and ",(0,a.kt)("a",{parentName:"p",href:"https://github.com/JohnnyCrazy/SpotifyAPI-NET/tree/master/SpotifyAPI.Web.Examples/Example.CLI.CustomHTML"},"Example.CLI.CustomHTML")))}h.isMDXComponent=!0}}]);