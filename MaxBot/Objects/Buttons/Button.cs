using System.Text.Json.Serialization;

namespace MaxBot.Objects.Buttons
{
    [JsonDerivedType(typeof(CallbackButton))]
    public abstract class Button
    {

    }
}
