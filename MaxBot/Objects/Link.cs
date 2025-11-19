using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;
public class Link
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }

    [JsonPropertyName("chat_id")]
    public int? ChatId { get; set; }

    [JsonPropertyName("message")]
    public MessageBody Message { get; set; }
}
