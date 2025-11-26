using MaxBot.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Types
{
    [JsonConverter(typeof(EnumConverter<FormatType>))]
    public enum FormatType
    {
        [JsonPropertyValue("html")]
        HTML,

        [JsonPropertyValue("markdown")]
        Markdown
    }
}
