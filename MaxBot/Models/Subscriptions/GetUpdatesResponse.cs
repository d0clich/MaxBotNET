using MaxBot.Objects;
using System.Text.Json.Serialization;

namespace MaxBot.Models.Subscriptions
{
    public class GetUpdatesResponse
    {
        [JsonPropertyName("marker")]
        public long Marker {  get; set; }
        [JsonPropertyName("updates")]
        public Update[] Updates { get; set; } = null!;
    }
}
