using System.Text.Json.Serialization;

namespace MaxBot.Objects.Updates
{
    public class MessageRemoved: Update
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }

        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
    }
}
