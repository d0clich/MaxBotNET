using System.Text.Json.Serialization;

namespace MaxBot.Objects;
public class Stat
{
    [JsonPropertyName("views")]
    public long? Views { get; set; }
}
