using System;
using System.Collections.Generic;
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
  }
}
