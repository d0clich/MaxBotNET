using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;
public class Attachment
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("payload")]
    public Payload Payload { get; set; }
}
