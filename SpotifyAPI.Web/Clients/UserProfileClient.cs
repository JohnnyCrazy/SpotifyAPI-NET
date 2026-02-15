using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class UserProfileClient : APIClient, IUserProfileClient
  {
    public UserProfileClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<PrivateUser> Current(CancellationToken cancel = default)
    {
      return API.Get<PrivateUser>(SpotifyUrls.Me(), cancel);
    }

    [System.Obsolete("This endpoint (GET /users/{id}) has been removed.")]
    public Task<PublicUser> Get(string userId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));

      return API.Get<PublicUser>(SpotifyUrls.User(userId), cancel);
    }

    public Task<CursorPaging<FullTrack>> GetTopTracks(UsersTopItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CursorPaging<FullTrack>>(SpotifyUrls.TopTracks(), request.BuildQueryParams(), cancel);

    }

    public Task<CursorPaging<FullArtist>> GetTopArtists(UsersTopItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<CursorPaging<FullArtist>>(SpotifyUrls.TopArtists(), request.BuildQueryParams(), cancel);
    }
  }
}
