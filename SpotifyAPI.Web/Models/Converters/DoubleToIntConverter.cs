using System;
using System.Globalization;

using Newtonsoft.Json;

namespace SpotifyAPI.Web
{
  public class DoubleToIntConverter : JsonConverter<int>
  {
    public override void WriteJson(JsonWriter? writer, int value, JsonSerializer serializer)
    {
      writer?.WriteValue(value);
    }

    public override int ReadJson(JsonReader? reader, Type objectType, int existingValue, bool hasExistingValue,
      JsonSerializer serializer)
    {
      return reader != null ? Convert.ToInt32(reader.Value, CultureInfo.InvariantCulture) : 0;
    }
  }
}
