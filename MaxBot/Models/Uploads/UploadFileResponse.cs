using System.Text.Json.Serialization;

namespace MaxBot.Models.Uploads
{
    internal class UploadFileResponse
    {
        [JsonPropertyName("fileId")]
        public long FileId {  get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
