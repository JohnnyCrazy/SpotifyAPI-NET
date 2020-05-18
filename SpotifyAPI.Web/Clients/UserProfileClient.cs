using System;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web
{
  public class UserProfileClient : APIClient, IUserProfileClient
  {
    public UserProfileClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<PrivateUser> Current()
    {
      return API.Get<PrivateUser>(SpotifyUrls.Me());
    }

    public Task<PublicUser> Get(string userId)
    {
      Ensure.ArgumentNotNullOrEmptyString(userId, nameof(userId));

      return API.Get<PublicUser>(SpotifyUrls.User(userId));
    }
  }
}
