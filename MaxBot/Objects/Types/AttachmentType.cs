using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

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
