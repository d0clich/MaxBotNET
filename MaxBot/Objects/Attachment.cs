using MaxBot.Objects.Types;
using System.Text.Json.Serialization;

namespace MaxBot.Objects;
public class Attachment
{
    [JsonPropertyName("type")]
    public AttachmentType Type { get; set; }

    [JsonPropertyName("payload")]
    public Payload Payload { get; set; }
}
