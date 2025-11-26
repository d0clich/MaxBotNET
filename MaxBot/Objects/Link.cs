using System.Text.Json.Serialization;
using MaxBot.Objects.Types;
using MaxBot.Objects.Users;

namespace MaxBot.Objects;
public class Link
{
    [JsonPropertyName("type")]
    public MessageLinkType Type { get; set; } 

    [JsonPropertyName("sender")]
    public User Sender { get; set; } = null!;

    [JsonPropertyName("chat_id")]
    public long? ChatId { get; set; }

    [JsonPropertyName("message")]
    public Body Message { get; set; } = null!;
}
