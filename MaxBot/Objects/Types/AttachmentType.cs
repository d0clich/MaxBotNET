using System.Text.Json.Serialization;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(BaseTypeConverter<AttachmentType>))]
public class AttachmentType : BaseType<AttachmentType> 
{
    public static readonly AttachmentType Image = new AttachmentType("image");
    public static readonly AttachmentType Video = new AttachmentType("video");
    public static readonly AttachmentType Audio = new AttachmentType("audio");
    public static readonly AttachmentType File = new AttachmentType("file");
    public static readonly AttachmentType Sticker = new AttachmentType("sticker");
    public static readonly AttachmentType Contact = new AttachmentType("contact");
    public static readonly AttachmentType InlineKeyboard = new AttachmentType("inline_keyboard");
    public static readonly AttachmentType Share = new AttachmentType("share");
    public static readonly AttachmentType Location = new AttachmentType("location");

    protected AttachmentType(string value) : base(value)
    {
    }
}