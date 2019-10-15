using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TennisApi.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Sex
    {
        F,
        M
    }
}
