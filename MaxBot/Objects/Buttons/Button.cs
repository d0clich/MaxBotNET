using System.Text.Json.Serialization;

namespace MaxBot.Objects.Buttons
{
    [JsonDerivedType(typeof(CallbackButton))]
    [JsonDerivedType(typeof(MessageButton))]
    [JsonDerivedType(typeof(LinkButton))]
    public class Button
    {

    }
}
