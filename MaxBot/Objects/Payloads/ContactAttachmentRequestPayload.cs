using System.Text.Json.Serialization;

namespace MaxBot.Objects.Payloads
{
    public class ContactAttachmentRequestPayload:Payload
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("contact_id")]
        public long? ContactId { get; set; }
        [JsonPropertyName("vcf_info")]
        public string? VcfInfo { get; set; }
        [JsonPropertyName("vcf_phone")]
        public string? VcfPhone { get; set; }
    }
}
