using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Moq;
using NUnit.Framework;
using SpotifyAPI.Web.Http;

namespace SpotifyAPI.Web.Tests
{
  public class NewtonsoftJSONSerializerTest
  {

    public static IEnumerable<object> DontSerializeTestSource
    {
      get
      {
        yield return new TestCaseData(null);
        yield return new TestCaseData("string");
        yield return new TestCaseData(new MemoryStream(Encoding.UTF8.GetBytes("string")));
        yield return new TestCaseData(new StringContent("string"));
      }
    }

    [TestCaseSource(nameof(DontSerializeTestSource))]
    public void SerializeRequest_SkipsAlreadySerialized(object input)
    {
      var serializer = new NewtonsoftJSONSerializer();
      var request = new Mock<IRequest>();
      request.SetupGet(r => r.Body).Returns(input);

      serializer.SerializeRequest(request.Object);

      Assert.That(input, Is.EqualTo(request.Object.Body));
    }

    public static IEnumerable<object> SerializeTestSource
    {
      get
      {
        yield return new TestCaseData(new { Uppercase = true }, "{\"uppercase\":true}");
        yield return new TestCaseData(new { CamelCase = true }, "{\"camel_case\":true}");
        yield return new TestCaseData(new { CamelCase = true, UPPER = true }, "{\"camel_case\":true,\"upper\":true}");
      }
    }

    [TestCaseSource(nameof(SerializeTestSource))]
    public void SerializeRequest_CorrectNaming(object input, string result)
    {
      var serializer = new NewtonsoftJSONSerializer();
      var request = new Mock<IRequest>();
      request.SetupGet(r => r.Body).Returns(input);

      serializer.SerializeRequest(request.Object);

      request.VerifySet(r => r.Body = result);
    }

    [TestCase]
    public void DeserializeResponse_SkipsNonJson()
    {
      var serializer = new NewtonsoftJSONSerializer();
      var response = new Mock<IResponse>();
      response.SetupGet(r => r.Body).Returns("hello");
      response.SetupGet(r => r.ContentType).Returns("media/mp4");

      IAPIResponse<object> apiResonse = serializer.DeserializeResponse<object>(response.Object);
      Assert.That(apiResonse.Body, Is.Null);
      Assert.That(apiResonse.Response, Is.EqualTo(response.Object));
    }

    [TestCase]
    public void DeserializeResponse_HandlesJson()
    {
      var serializer = new NewtonsoftJSONSerializer();
      var response = new Mock<IResponse>();
      response.SetupGet(r => r.Body).Returns("{\"hello_world\": false}");
      response.SetupGet(r => r.ContentType).Returns("application/json");

      IAPIResponse<TestResponseObject> apiResonse = serializer.DeserializeResponse<TestResponseObject>(response.Object);
      Assert.That(apiResonse.Body?.HelloWorld, Is.False);
      Assert.That(apiResonse.Response, Is.EqualTo(response.Object));
    }

    public class TestResponseObject
    {
      public bool HelloWorld { get; set; }
    }
  }
}
