using System.Text.Json.Serialization;
using MaxBot.Objects.Types;

namespace MaxBot.Objects.Buttons;

[JsonDerivedType(typeof(CallbackButton))]
[JsonDerivedType(typeof(MessageButton))]
[JsonDerivedType(typeof(LinkButton))]
public class Button
{
    [JsonInclude]
    [JsonPropertyName("type")]
    protected ButtonType Type { get; set;}
}