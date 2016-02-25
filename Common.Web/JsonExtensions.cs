using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common.Web
{
    public static class JsonExtensions
    {
        private const Formatting JsonFormatting = Formatting.None;

        private readonly static JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
                                                                             {
                                                                                 NullValueHandling = NullValueHandling.Ignore, 
                                                                                 Formatting = JsonFormatting
                                                                             };

        public static string ObjectToJson(this object obj)
        {
            if (obj == null)
                return "{}";

            return JsonConvert.SerializeObject(obj, _serializerSettings);
        }

        public static TResult JsonToObject<TResult>(this string json)
        {
            return JsonConvert.DeserializeObject<TResult>(json);
        }

        public static string RemoveJsonProperties(this string json, IEnumerable<string> propertyNames)
        {
            if (propertyNames == null || !propertyNames.Any())
                return json;

            var jobj = JObject.Parse(json);
            foreach (string propertyName in propertyNames)
                jobj.Remove(propertyName);
            
            return jobj.ToString(JsonFormatting);
        }

    }
}
