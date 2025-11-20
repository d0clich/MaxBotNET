using System.Text.Json.Serialization;

namespace MaxBot.Objects.Users
{
    public class BotCommand
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
