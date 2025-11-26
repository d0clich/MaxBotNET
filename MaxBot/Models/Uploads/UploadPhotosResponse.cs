using System.Text.Json.Serialization;

namespace MaxBot.Models.Uploads
{
    internal class UploadPhotosResponse
    {
        [JsonPropertyName("photos")]
        public Dictionary<string,UploadsGetTokenResponse> Photos {  get; set; }
    }
}
