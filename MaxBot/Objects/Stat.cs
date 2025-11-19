using System.Text.Json.Serialization;

namespace MaxBot.Objects;
public class Stat
{
    [JsonPropertyName("views")]
    public int? Views { get; set; }
}
