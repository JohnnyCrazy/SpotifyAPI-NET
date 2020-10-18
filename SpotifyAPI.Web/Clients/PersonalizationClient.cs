using System.Threading.Tasks;
using SpotifyAPI.Web.Http;
using URLs = SpotifyAPI.Web.SpotifyUrls;

namespace SpotifyAPI.Web
{
  public class PersonalizationClient : APIClient, IPersonalizationClient
  {
    private const string URL_PARAMS_ARTISTS = "artists";
    private const string URL_PARAMS_TRACKS = "tracks";

    public PersonalizationClient(IAPIConnector apiConnector) : base(apiConnector) { }

    public Task<Paging<FullArtist>> GetTopArtists()
    {
      return API.Get<Paging<FullArtist>>(URLs.PersonalizationTop(URL_PARAMS_ARTISTS));
    }

    public Task<Paging<FullArtist>> GetTopArtists(PersonalizationTopRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<FullArtist>>(URLs.PersonalizationTop(URL_PARAMS_ARTISTS), request.BuildQueryParams());
    }

    public Task<Paging<FullTrack>> GetTopTracks()
    {
      return API.Get<Paging<FullTrack>>(URLs.PersonalizationTop(URL_PARAMS_TRACKS));
    }

    public Task<Paging<FullTrack>> GetTopTracks(PersonalizationTopRequest request)
    {
      Ensure.ArgumentNotNull(request, nameof(request));

      return API.Get<Paging<FullTrack>>(URLs.PersonalizationTop(URL_PARAMS_TRACKS), request.BuildQueryParams());
    }
  }
}
