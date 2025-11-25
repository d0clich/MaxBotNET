using MaxBot.Models.Uploads;
using MaxBot.Objects.Types;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Web;

namespace MaxBot
{
    public partial class MaxBotClient
    {
        private async Task<string> UploadImage(string url, string fileName, Stream file, CancellationToken cts = default)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(file), "data", fileName);

            var response = await _httpClient.PostAsync(url, content, cts).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new MaxBotException($"Upload image exception: {response.StatusCode} " + await response.Content.ReadAsStringAsync(cts).ConfigureAwait(false));

           var photos = await response.Content.ReadFromJsonAsync<UploadPhotosResponse>(cts).ConfigureAwait(false);
         
            var photo = photos?.Photos?.FirstOrDefault();
            if (photo == null || photo.HasValue == false || photo.Value.Value?.Token == null)
                throw new MaxBotException($"Upload image exception: no photos in response");

            return photo.Value.Value.Token;
        }
        
        private async Task<string> UploadFile(string url, string fileName, Stream file, CancellationToken cts = default)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(file), "data", fileName);

            var response = await _httpClient.PostAsync(url, content, cts).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new MaxBotException($"Upload image exception: {response.StatusCode} " + await response.Content.ReadAsStringAsync(cts).ConfigureAwait(false));

           var photos = await response.Content.ReadFromJsonAsync<UploadPhotosResponse>(cts).ConfigureAwait(false);
         
            var photo = photos?.Photos?.FirstOrDefault();
            if (photo == null || photo.HasValue == false || photo.Value.Value?.Token == null)
                throw new MaxBotException($"Upload image exception: no photos in response");

            return photo.Value.Value.Token;
        }

        public async Task<string> Upload(string fileName, Stream file, UploadType type, CancellationToken cts = default)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));
            if (type == UploadType.File || type == UploadType.Video || type == UploadType.Audio) throw new NotImplementedException();
            if (file == null) throw new ArgumentNullException(nameof(file));

            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["type"] = type.ToString();

            var uploadingUrlResponse = await _httpClient.PostAsync($"uploads?{parameters}", null, cts).ConfigureAwait(false);
            if (!uploadingUrlResponse.IsSuccessStatusCode)
                throw new MaxBotException($"Get upload url exception: {uploadingUrlResponse.StatusCode} " + await uploadingUrlResponse.Content.ReadAsStringAsync(cts).ConfigureAwait(false));

            var url = await uploadingUrlResponse.Content.ReadFromJsonAsync<UploadsGetUrlResponse>().ConfigureAwait(false);

            if (url == null) throw new MaxBotException("Url to upload was null");

            if (type == UploadType.Image)
                return await UploadImage(url.Url, fileName, file);
            if (type == UploadType.File)
                return await UploadFile(url.Url, fileName, file);

            return "";
        }
    }
}
