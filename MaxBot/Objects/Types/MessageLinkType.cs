using System.Text.Json.Serialization;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(BaseTypeConverter<MessageLinkType>))]
public class MessageLinkType: BaseType<MessageLinkType>
{

    public static readonly MessageLinkType Forward = new MessageLinkType("forward");
    public static readonly MessageLinkType Reply = new MessageLinkType("Reply");

    public MessageLinkType(string value) : base(value) { }
}

