using System.Collections.Generic;

namespace SpotifyAPI.Web
{
  public class TracksAudioFeaturesRequest : RequestParams
  {
    public TracksAudioFeaturesRequest(IList<string> ids)
    {
      Ensure.ArgumentNotNullOrEmptyList(ids, nameof(ids));

      Ids = ids;
    }

    [QueryParam("ids")]
    public IList<string> Ids { get; }
  }
}

