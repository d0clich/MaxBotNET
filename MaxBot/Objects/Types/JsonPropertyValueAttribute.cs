namespace MaxBot.Objects.Types;

internal class JsonPropertyValueAttribute : Attribute
{
    public string StringValue { get; protected set; }

    public JsonPropertyValueAttribute(string value)
    {
        StringValue = value;
    }
}