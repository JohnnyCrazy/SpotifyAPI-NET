using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SpotifyAPI.Web.Tests
{
  [TestFixture]
  public class RequestParamsTest
  {
    [Test]
    public void CacheDoesNotInterfereQuery()
    {
      var first = new FirstRequestModel { First = true };
      var firstParams = first.BuildQueryParams();

      var second = new SecondRequestModel { Second = false };
      var secondParams = second.BuildQueryParams();

      Assert.AreEqual(1, firstParams.Keys.Count);
      Assert.AreEqual("true", firstParams["first"]);

      Assert.AreEqual(1, secondParams.Keys.Count);
      Assert.AreEqual("false", secondParams["second"]);
    }

    [Test]
    public void CacheDoesNotInterfereBody()
    {
      var first = new FirstRequestModel { First = true };
      var firstParams = first.BuildBodyParams();

      var second = new SecondRequestModel { Second = false };
      var secondParams = second.BuildBodyParams();

      Assert.AreEqual("{\"first\":true}", firstParams.ToString(Formatting.None));
      Assert.AreEqual("{\"second\":false}", secondParams.ToString(Formatting.None));
    }

    [Test]
    public void EmptyListIsSkippedInQueryParams()
    {
      var first = new EmptyListExampleRequestModel();
      Assert.AreEqual(new Dictionary<string, string> { }, first.BuildQueryParams());
      first.List.Add("hello_world");
      Assert.AreEqual(new Dictionary<string, string> { { "list", "hello_world" } }, first.BuildQueryParams());
    }

    [Test]
    public void EnumWithoutFlagsDoesNotHaveMultipleValues()
    {
      var enumModel = new EnumWithoutFlagsRequestModel
      {
        AnEnumParam = EnumWithoutFlagsRequestModel.AnEnum.Two
      };

      var result = enumModel.BuildQueryParams();
      Assert.AreEqual(1, result.Keys.Count);
      Assert.AreEqual("two", result["an_enum"]);
    }

    [Test]
    public void EnumWithFlagsDoesHaveMultipleValues()
    {
      var enumModel = new EnumWitFlagsRequestModel
      {
        AnEnumParam = EnumWitFlagsRequestModel.AnEnum.Two | EnumWitFlagsRequestModel.AnEnum.One
      };

      var result = enumModel.BuildQueryParams();
      Assert.AreEqual(1, result.Keys.Count);
      Assert.AreEqual("one,two", result["an_enum"]);
    }
  }

  public class FirstRequestModel : RequestParams
  {
    [BodyParam("first")]
    [QueryParam("first")]
    public bool? First { get; set; }
  }

  public class SecondRequestModel : RequestParams
  {
    [BodyParam("second")]
    [QueryParam("second")]
    public bool? Second { get; set; }
  }

  public class EmptyListExampleRequestModel : RequestParams
  {
    [QueryParam("list")]
    public IList<string> List { get; set; } = new List<string>();
  }

  public class EnumWithoutFlagsRequestModel : RequestParams
  {
    [QueryParam("an_enum")]
    public AnEnum AnEnumParam { get; set; }

    public enum AnEnum
    {
      [String("one")]
      One,

      [String("two")]
      Two,
    }
  }

  public class EnumWitFlagsRequestModel : RequestParams
  {
    [QueryParam("an_enum")]
    public AnEnum AnEnumParam { get; set; }

    [Flags]
    public enum AnEnum
    {
      [String("one")]
      One = 1,

      [String("two")]
      Two = 2,
    }
  }
}
