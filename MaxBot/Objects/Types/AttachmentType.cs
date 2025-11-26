using MaxBot.Converters;
using System.Text.Json.Serialization;
using MaxBot.Attributes;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(EnumConverter<AttachmentType>))]
public enum AttachmentType
{
    [JsonPropertyValue("image")]
    Image,
    [JsonPropertyValue("video")]
    Video,
    [JsonPropertyValue("audio")]
    Audio,
    [JsonPropertyValue("file")]
    File,
    [JsonPropertyValue("sticker")]
    Sticker,
    [JsonPropertyValue("contact")]
    Contact,
    [JsonPropertyValue("inline_keyboard")]
    InlineKeyboard,
    [JsonPropertyValue("share")]
    Share,
    [JsonPropertyValue("location")]
    Location
}
