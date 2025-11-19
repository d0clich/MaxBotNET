using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;

public class Recipient
{
    [JsonPropertyName("chat_id")]
    public int? ChatId { get; set; }

    [JsonPropertyName("chat_type")]
    public string ChatType { get; set; }

    [JsonPropertyName("user_id")]
    public int? UserId { get; set; }
}
