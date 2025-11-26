using System.Text.Json.Serialization;
using MaxBot.Attributes;
using MaxBot.Converters;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(EnumConverter<UploadType>))]
public enum UploadType
{
    [JsonPropertyValue("image")]
    Image,

    [JsonPropertyValue("video")]
    Video,

    [JsonPropertyValue("audio")]
    Audio,

    [JsonPropertyValue("file")]
    File
}