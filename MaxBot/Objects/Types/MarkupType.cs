using System.Text.Json.Serialization;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(BaseTypeConverter<AttachmentType>))]
public class MarkupType: BaseType<MarkupType>
{
    public static readonly MarkupType Strong = new MarkupType("strong");
    public static readonly MarkupType Emphasized = new MarkupType("emphasized");
    public static readonly MarkupType Monospaced = new MarkupType("monospaced");
    public static readonly MarkupType Link = new MarkupType("link");
    public static readonly MarkupType Strikethrough = new MarkupType("strikethrough");
    public static readonly MarkupType Underline = new MarkupType("underline");
    public static readonly MarkupType UserMention = new MarkupType("user_mention");

    private MarkupType(string value) : base(value)
    {
    }
}