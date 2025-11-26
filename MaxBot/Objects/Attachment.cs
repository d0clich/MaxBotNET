using System.Text.Json.Serialization;
using MaxBot.Objects.Payloads;
using MaxBot.Objects.Types;

namespace MaxBot.Objects;

public class Attachment
{
    [JsonPropertyName("type")]
    public AttachmentType Type { get; set; } 
    [JsonPropertyName("payload")]
    public Payload? Payload { get; set; }
    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    public static Attachment CreateContact(
            string name,
            long? contactId = null,
            string? vcfInfo = null,
            string? vcfPhone = null
            )
    {
        var contact = new ContactAttachmentRequestPayload
        {
            ContactId = contactId,
            Name = name,
            VcfInfo = vcfInfo,
            VcfPhone = vcfPhone
        };
        return new Attachment() { Type = AttachmentType.Contact, Payload = contact };
    }

    public static Attachment CreatePhoto(string? token = null, string? url = null, string? photos = null)
    {
        var photo = new PhotoAttachmentRequestPayload()
        {
            Photos = photos,
            Token = token,
            Url = url,
        };
        return new Attachment() { Type = AttachmentType.Image, Payload = photo };
    }

    public static Attachment CreateUploadedInfo(string token)
    {
        var uploaded = new UploadedInfoPayload()
        {
            Token = token,
        };
        return new Attachment() {  Type = AttachmentType.File , Payload = uploaded };
    }

    public static Attachment CreateButtons(InlineKeyboardPayload payload)
    {
        return new Attachment() { Type = AttachmentType.InlineKeyboard, Payload = payload };
    }
}
