using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MaxBot.Models.Uploads
{
    internal class UploadPhotosResponse
    {
        [JsonPropertyName("photos")]
        public Dictionary<string,UploadsGetTokenResponse> Photos {  get; set; }
    }
}
