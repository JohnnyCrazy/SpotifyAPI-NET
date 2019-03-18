using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web.Tests
{
    [TestFixture]
    public class SpotifyWebAPITest
    {
        private static readonly string FixtureDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../fixtures/");

        private Mock<IClient> _mock;
        private SpotifyWebAPI _spotify;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IClient>();
            _spotify = new SpotifyWebAPI
            {
                WebClient = _mock.Object,
                UseAuth = false
            };
        }

        private static T GetFixture<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(FixtureDir, file)));
        }

        private static bool ContainsValues(string str, params string[] values)
        {
            return values.All(str.Contains);
        }

        [Test]
        public void ShouldGetPrivateProfile_WithoutAuth()
        {
            _spotify.UseAuth = false;

            Assert.Throws<InvalidOperationException>(() => _spotify.GetPrivateProfile());
        }

        [Test]
        public void ShouldGetPrivateProfile_WithAuth()
        {
            PrivateProfile profile = GetFixture<PrivateProfile>("private-user.json");
            _mock.Setup(client => client.DownloadJson<PrivateProfile>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .Returns(new Tuple<ResponseInfo, PrivateProfile>(ResponseInfo.Empty, profile));

            _spotify.UseAuth = true;
            Assert.AreEqual(profile, _spotify.GetPrivateProfile());
            _mock.Verify(client => client.DownloadJson<PrivateProfile>(
                It.Is<string>(str => ContainsValues(str, "/me")),
                It.IsNotNull<Dictionary<string, string>>()), Times.Exactly(1));
        }

        [Test]
        public void ShouldGetPublicProfile()
        {
            PublicProfile profile = GetFixture<PublicProfile>("public-user.json");
            _mock.Setup(client => client.DownloadJson<PublicProfile>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .Returns(new Tuple<ResponseInfo, PublicProfile>(ResponseInfo.Empty, profile));


            _spotify.UseAuth = false;
            Assert.AreEqual(profile, _spotify.GetPublicProfile("wizzler"));
            _mock.Verify(client => client.DownloadJson<PublicProfile>(
                It.Is<string>(str => ContainsValues(str, "/users/wizzler")), 
                It.Is<Dictionary<string, string>>(headers => headers.Count == 0)), Times.Exactly(1));
        }

        //Will add more tests once I decided if this is worth the effort (propably not?)
    }
}