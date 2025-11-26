using System.Text.Json.Serialization;

namespace MaxBot.Objects.Updates
{
    public class MessageCreated: Update
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; } = null!;

        [JsonPropertyName("user_locale")]
        public string UserLocale { get; set; } = null!;
    }
}
