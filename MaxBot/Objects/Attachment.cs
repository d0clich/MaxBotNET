using MaxBot.Objects.Payloads;
using MaxBot.Objects.Types;
using System.Text.Json.Serialization;

namespace MaxBot.Objects;
public class Attachment
{
    [JsonPropertyName("type")]
    public AttachmentType Type { get; set; } 

    [JsonPropertyName("payload")]
    public Payload? Payload { get; set; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }
}
