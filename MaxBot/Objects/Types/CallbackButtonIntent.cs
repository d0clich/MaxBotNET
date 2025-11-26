using MaxBot.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using MaxBot.Attributes;

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
