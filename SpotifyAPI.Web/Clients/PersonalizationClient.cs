using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class PersonalizationClient : APIClient, IPersonalizationClient
  {
    public PersonalizationClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<Paging<FullArtist>> GetTopArtists(CancellationToken cancel = default)
    {
      return API.Get<Paging<FullArtist>>(URLs.PersonalizationTop("artists"), cancel);
    }

    public Task<Paging<FullArtist>> GetTopArtists(PersonalizationTopRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<FullArtist>>(URLs.PersonalizationTop("artists"), request.BuildQueryParams(), cancel);
    }

    public Task<Paging<FullTrack>> GetTopTracks(CancellationToken cancel = default)
    {
      return API.Get<Paging<FullTrack>>(URLs.PersonalizationTop("tracks"), cancel);
    }

    public Task<Paging<FullTrack>> GetTopTracks(PersonalizationTopRequest request, CancellationToken cancel = default)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<FullTrack>>(URLs.PersonalizationTop("tracks"), request.BuildQueryParams(), cancel);
    }
  }
}
