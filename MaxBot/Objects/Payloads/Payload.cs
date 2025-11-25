using System.Text.Json.Serialization;

namespace MaxBot.Objects.Payloads;

[JsonDerivedType(typeof(ContactAttachmentRequestPayload))]
[JsonDerivedType(typeof(InlineKeyboardAttachmentRequestPayload))]
[JsonDerivedType(typeof(PhotoAttachmentRequestPayload))]
[JsonDerivedType(typeof(ShareAttachmentPayload))]
[JsonDerivedType(typeof(StickerAttachmentRequestPayload))]
[JsonDerivedType(typeof(UploadedInfoPayload))]
public class Payload
{

}
