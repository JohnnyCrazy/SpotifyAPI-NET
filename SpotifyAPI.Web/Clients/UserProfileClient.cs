using System;
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

    public Task<PublicUser> Get(string userId, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));

      return API.Get<PublicUser>(SpotifyUrls.User(userId), cancel);
    }
  }
}
