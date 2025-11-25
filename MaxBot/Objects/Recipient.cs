using System.Text.Json.Serialization;

namespace MaxBot.Objects;

public class Recipient
{
    [JsonPropertyName("chat_id")]
    public long? ChatId { get; set; }

    [JsonPropertyName("chat_type")]
    public string ChatType { get; set; } = null!;

    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }
}
