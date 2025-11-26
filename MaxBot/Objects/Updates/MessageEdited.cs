using System.Text.Json.Serialization;

namespace MaxBot.Objects.Updates
{
    public class MessageEdited: Update
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; } = null!;
    }
}
