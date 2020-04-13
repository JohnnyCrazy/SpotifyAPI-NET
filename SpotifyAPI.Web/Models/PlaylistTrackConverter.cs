using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpotifyAPI.Web.Models
{
    class PlaylistTrackConverter : JsonConverter
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

            if (token["track"] == null)
            {
                return null;
            }

            if (token["track"].Value<bool>() == true)
            {
                var obj = new FullTrack();
                serializer.Populate(token.CreateReader(), obj);
                return obj;
            }
            else 
            {
                var obj = new FullEpisode();
                serializer.Populate(token.CreateReader(), obj);
                return obj;
            }            
        }

        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
