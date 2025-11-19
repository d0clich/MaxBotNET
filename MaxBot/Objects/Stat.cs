using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;
public class Stat
{
    [JsonPropertyName("views")]
    public int? Views { get; set; }
}
