using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
  /// <summary>
  ///   Endpoints for retrieving information about a user’s profile.
  /// </summary>
  /// <remarks>https://developer.spotify.com/documentation/web-api/reference-beta/#category-user-profile</remarks>
  public interface IUserProfileClient
  {
    /// <summary>
    ///   Get detailed profile information about the current user (including the current user’s username).
    /// </summary>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-current-users-profile
    /// </remarks>
    /// <exception cref="APIUnauthorizedException">Thrown if the client is not authenticated.</exception>
    Task<PrivateUser> Current(CancellationToken cancel = default);

    /// <summary>
    ///   Get public profile information about a Spotify user.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <param name="cancel">The cancellation-token to allow to cancel the request.</param>
    /// <remarks>https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-users-profile</remarks>
    /// <exception cref="APIUnauthorizedException">Thrown if the client is not authenticated.</exception>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    Task<PublicUser> Get(string userId, CancellationToken cancel = default);
  }
}
