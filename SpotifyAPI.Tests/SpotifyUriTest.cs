using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Local.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpotifyAPI.Tests
{
    public class SpotifyUriTest
    {
        [Test]
        public void ShouldThrowArgumentExceptionForInvalidUri()
        {
            Assert.Throws<ArgumentException>(() => SpotifyUri.Parse("asdafadfgsrsegqejfa"));
        }

        [Test]
        public void ShouldCorrectlyParseTrackUri()
        {
            string testUri = "spotify:track:3QOruXa2lvqIFvOOa2rYyJ";
            SpotifyUri uri = SpotifyUri.Parse(testUri);

            Assert.AreEqual(uri.Base, "spotify");

            Assert.AreEqual(uri.Type, UriType.track);
            Assert.AreEqual(uri.Id, "3QOruXa2lvqIFvOOa2rYyJ");
            Assert.AreEqual(uri.ToString(), testUri);
        }

        [Test]
        public void ShouldCorrectlyParsePlaylistUri()
        {
            string testUri = "spotify:user:spotifycharts:playlist:37i9dQZEVXbMDoHDwVN2tF";
            SpotifyUri uri = SpotifyUri.Parse(testUri);

            Assert.AreEqual(uri.Base, "spotify");

            Assert.AreEqual(uri.Type, UriType.playlist);
            Assert.AreEqual(uri.Id, "37i9dQZEVXbMDoHDwVN2tF");

            Assert.AreEqual(uri.GetUriPropValue(UriType.user), "spotifycharts");
            Assert.AreEqual(uri.ToString(), testUri);
        }

        [Test]
        public void ShouldHandleNotExistingUriProperty()
        {
            string testUri = "spotify:track:3QOruXa2lvqIFvOOa2rYyJ";
            SpotifyUri uri = SpotifyUri.Parse(testUri);
            Assert.DoesNotThrow(() => uri.GetUriPropValue(UriType.user));
            Assert.IsNull(uri.GetUriPropValue(UriType.user));
        }
    }
}