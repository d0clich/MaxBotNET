using System.Text.Json.Serialization;

namespace MaxBot.Objects.Payloads;

[JsonDerivedType(typeof(ContactAttachmentRequestPayload))]
[JsonDerivedType(typeof(InlineKeyboardPayload))]
[JsonDerivedType(typeof(PhotoAttachmentRequestPayload))]
[JsonDerivedType(typeof(ShareAttachmentPayload))]
[JsonDerivedType(typeof(StickerAttachmentRequestPayload))]
[JsonDerivedType(typeof(UploadedInfoPayload))]
public class Payload
{

}
