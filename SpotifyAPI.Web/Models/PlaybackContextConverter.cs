using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpotifyAPI.Web.Models
{
    class PlaybackContextConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            var token = JToken.ReadFrom(reader);
            if (token.Type == JTokenType.Null)
            {
                return null;
            }

            // Create an instance of MyClass, and set property as per "isFoo".
            var obj = new PlaybackContext();

            if (token["currently_playing_type"] != null)
            {
                if (token["currently_playing_type"].Value<string>() == "track")
                {
                    obj.Item = new FullTrack();
                }
                else if (token["currently_playing_type"].Value<string>() == "episode")
                {
                    obj.Item = new FullEpisode();
                }
            }

            // Populate properties
            serializer.Populate(token.CreateReader(), obj);
            return obj;
        }

        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
