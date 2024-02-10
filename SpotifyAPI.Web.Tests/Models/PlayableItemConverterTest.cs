using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class PPlayableItemConverterTest
  {
    [Test]
    public void PlayableItemConverter_CanSerialize()
    {
      var context = new CurrentlyPlayingContext { Item = new FullTrack() };

      Assert.DoesNotThrow(() =>
      {
        var serialized = JsonConvert.SerializeObject(context);
      });
    }

    [Test]
    public async Task PlayableItemConverter_Reserialize()
    {
      // This has lowercase field names since it's a spotify response
      var fixture = await File.ReadAllTextAsync(
        Path.Join(TestContext.CurrentContext.TestDirectory, "Fixtures/full_playlist_response.json")
      );

      var fullPlaylist = JsonConvert.DeserializeObject<FullPlaylist>(fixture);
      // This whill have uppercase field names since we use default JsonConvert settings
      var serialized = JsonConvert.SerializeObject(fullPlaylist);

      Assert.DoesNotThrow(() =>
      {
        var deserialized = JsonConvert.DeserializeObject<FullPlaylist>(serialized);
      });
    }
  }
}
