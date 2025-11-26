using System.Text.Json.Serialization;
using MaxBot.Attributes;
using MaxBot.Converters;

namespace MaxBot.Objects.Types
{
    [JsonConverter(typeof(EnumConverter<CallbackButtonIntent>))]
    public enum CallbackButtonIntent
    {
        [JsonPropertyValue("default")]
        Default,
        [JsonPropertyValue("positive")]
        Positive,
        [JsonPropertyValue("negative")]
        Negative,
    }
}
