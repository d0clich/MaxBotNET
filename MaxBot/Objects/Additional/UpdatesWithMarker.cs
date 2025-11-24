using System.Text.Json.Serialization;

namespace MaxBot.Objects.Additional
{
    public class UpdatesWithMarker
    {
        [JsonPropertyName("marker")]
        public long Marker { get; set; }
        [JsonPropertyName("updates")]
        public Update[] Updates { get; set; } = null!;
    }
}
