using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class PersonalizationClient : APIClient, IPersonalizationClient
  {
    public PersonalizationClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<Paging<FullArtist>> GetTopArtists()
    {
      return API.Get<Paging<FullArtist>>(URLs.PersonalizationTop("artists"));
    }

    public Task<Paging<FullArtist>> GetTopArtists(PersonalizationTopRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<FullArtist>>(URLs.PersonalizationTop("artists"), request.BuildQueryParams());
    }

    public Task<Paging<FullTrack>> GetTopTracks()
    {
      return API.Get<Paging<FullTrack>>(URLs.PersonalizationTop("tracks"));
    }

    public Task<Paging<FullTrack>> GetTopTracks(PersonalizationTopRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<FullTrack>>(URLs.PersonalizationTop("tracks"), request.BuildQueryParams());
    }
  }
}
