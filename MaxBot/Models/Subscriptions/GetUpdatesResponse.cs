using System.Text.Json.Serialization;
using MaxBot.Objects;

namespace MaxBot.Models.Subscriptions
{
    internal class GetUpdatesResponse
    {
        [JsonPropertyName("marker")]
        public long Marker {  get; set; }
        [JsonPropertyName("updates")]
        public Update[] Updates { get; set; } = null!;
    }
}
