using MaxBot.Converters;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(EnumConverter<UpdateType>))]
public enum UpdateType
{
    [JsonPropertyValue("message_created")]
    MessageCreated,

    [JsonPropertyValue("message_callback")]
    MessageCallback,

    [JsonPropertyValue("message_edited")]
    MessageEdited,

    [JsonPropertyValue("message_removed")]
    MessageRemoved,

    [JsonPropertyValue("bot_added")]
    BotAdded,

    [JsonPropertyValue("bot_removed")]
    BotRemoved,

    [JsonPropertyValue("dialog_muted")]
    DialogMuted,

    [JsonPropertyValue("dialog_unmuted")]
    DialogUnmuted,

    [JsonPropertyValue("dialog_cleared")]
    DialogCleared,

    [JsonPropertyValue("dialog_removed")]
    DialogRemoved,

    [JsonPropertyValue("user_added")]
    UserAdded,

    [JsonPropertyValue("user_removed")]
    UserRemoved,

    [JsonPropertyValue("bot_started")]
    BotStarted,

    [JsonPropertyValue("bot_stopped")]
    BotStopped,

    [JsonPropertyValue("chat_title_changed")]
    ChatTitleChanged,

    [JsonPropertyValue("message_chat_created")]
    MessageChatCreated
}