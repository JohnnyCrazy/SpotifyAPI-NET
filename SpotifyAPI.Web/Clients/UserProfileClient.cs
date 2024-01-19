using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using SpotifyAPI.Web.Models.Request;

namespace SpotifyAPI.Web
{
  public class UserProfileClient : APIClient, IUserProfileClient
  {
    public UserProfileClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<PrivateUser> Current(CancellationToken cancel = default)
    {
      return API.Get<PrivateUser>(SpotifyUrls.Me(), cancel);
    }

    public Task<PublicUser> Get(string userId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));

      return API.Get<PublicUser>(SpotifyUrls.User(userId), cancel);
    }

    public Task<UsersTopTracksResponse> GetTopTracks(UsersTopItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<UsersTopTracksResponse>(SpotifyUrls.TopTracks(), request.BuildQueryParams(), cancel);

    }

    public Task<UsersTopArtistsResponse> GetTopArtists(UsersTopItemsRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<UsersTopArtistsResponse>(SpotifyUrls.TopArtists(), request.BuildQueryParams(), cancel);
    }
  }
}
