using System.Text.Json.Serialization;

namespace MaxBot.Objects.Updates;

public class MessageChatCreated:Update
{
    [JsonPropertyName(("chat"))]
    public Chat Chat { get; set; }
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; }
    [JsonPropertyName("start_payload")]
    public string StartPayload { get; set; }
}