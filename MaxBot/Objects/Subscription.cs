using MaxBot.Objects.Types;
using System.Text.Json.Serialization;

namespace MaxBot.Objects
{
    public class Subscription
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;
        [JsonPropertyName("time")]
        public long Time { get; set; }
        [JsonPropertyName("update_types")]
        public UpdateType[]? UpdateTypes { get; set; }
    }
}
