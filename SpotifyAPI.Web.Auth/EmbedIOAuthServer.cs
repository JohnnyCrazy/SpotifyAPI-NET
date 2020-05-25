using System.Reflection;
using System.Threading;
using System.Web;
using System.Globalization;
using System.Text;
using System;
using System.Threading.Tasks;
using EmbedIO;
using EmbedIO.Actions;

namespace SpotifyAPI.Web.Auth
{
  public class EmbedIOAuthServer : IAuthServer
  {
    public event Func<object, AuthorizationCodeResponse, Task>? AuthorizationCodeReceived;
    public event Func<object, ImplictGrantResponse, Task>? ImplictGrantReceived;

    private const string AssetsResourcePath = "SpotifyAPI.Web.Auth.Resources.auth_assets";
    private const string DefaultResourcePath = "SpotifyAPI.Web.Auth.Resources.default_site";

    private CancellationTokenSource? _cancelTokenSource;
    private readonly WebServer _webServer;

    public EmbedIOAuthServer(Uri baseUri, int port)
      : this(baseUri, port, Assembly.GetExecutingAssembly(), DefaultResourcePath) { }

    public EmbedIOAuthServer(Uri baseUri, int port, Assembly resourceAssembly, string resourcePath)
    {
      Ensure.ArgumentNotNull(baseUri, nameof(baseUri));

      BaseUri = baseUri;
      Port = port;

      _webServer = new WebServer(port)
        .WithModule(new ActionModule("/", HttpVerbs.Post, (ctx) =>
        {
          var query = ctx.Request.QueryString;
          if (query["error"] != null)
          {
            throw new AuthException(query["error"], query["state"]);
          }

          var requestType = query.Get("request_type");
          if (requestType == "token")
          {
            ImplictGrantReceived?.Invoke(this, new ImplictGrantResponse(
              query["access_token"], query["token_type"], int.Parse(query["expires_in"])
            )
            {
              State = query["state"]
            });
          }
          if (requestType == "code")
          {
            AuthorizationCodeReceived?.Invoke(this, new AuthorizationCodeResponse(query["code"])
            {
              State = query["state"]
            });
          }

          return ctx.SendStringAsync("OK", "text/plain", Encoding.UTF8);
        }))
        .WithEmbeddedResources("/auth_assets", Assembly.GetExecutingAssembly(), AssetsResourcePath)
        .WithEmbeddedResources(baseUri.AbsolutePath, resourceAssembly, resourcePath);
    }

    public Uri BaseUri { get; }
    public int Port { get; }

    public Task Start()
    {
      _cancelTokenSource = new CancellationTokenSource();
      _webServer.Start(_cancelTokenSource.Token);
      return Task.CompletedTask;
    }

    public Task Stop()
    {
      _cancelTokenSource?.Cancel();
      return Task.CompletedTask;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        _webServer?.Dispose();
      }
    }
  }
}
