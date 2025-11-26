using MaxBot.Models.Uploads;
using MaxBot.Objects.Types;
using System.Net.Http.Json;
using System.Web;

namespace MaxBot
{
    public partial class MaxBotClient
    {
        private async Task<string> UploadImage(string url, string fileName, Stream file, CancellationToken cts = default)
        {
            var content = new MultipartFormDataContent();
            content.Add(GetStreamContent(fileName, file), "data", fileName);

            var response = await _httpClient.PostAsync(url, content, cts).ConfigureAwait(false);
            await ThrowIfNotSuccessful(response, "uploading image").ConfigureAwait(false);

            var photos = await response.Content.ReadFromJsonAsync<UploadPhotosResponse>(cts).ConfigureAwait(false);
         
            var photo = photos?.Photos?.FirstOrDefault();
            if (photo == null || photo.HasValue == false || photo.Value.Value?.Token == null)
                throw new MaxBotException($"Upload image exception: no photos in response");

            return photo.Value.Value.Token;
        }

        private async Task<string> UploadFile(string url, string fileName, Stream file, CancellationToken cts = default)
        {
            var content = new MultipartFormDataContent();
            content.Add(GetStreamContent(fileName, file), "data", fileName);

            var response = await _httpClient.PostAsync(url, content, cts).ConfigureAwait(false);
            await ThrowIfNotSuccessful(response, "uploading file").ConfigureAwait(false);

            var token = await response.Content.ReadFromJsonAsync<UploadFileResponse>(cts).ConfigureAwait(false);
         
            if (token?.Token == null)
                throw new MaxBotException($"Upload file exception: no token in response");

            return token.Token;
        }

        public async Task<string> Upload(string filePath, UploadType type, CancellationToken cts = default)
        {
            var stream = File.OpenRead(filePath);
            var fileName = stream.Name;

            return await Upload(fileName, stream, type, cts).ConfigureAwait(false);
        }

        public async Task<string> Upload(string fileName, Stream file, UploadType type, CancellationToken cts = default)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));
            if (type == UploadType.Video || type == UploadType.Audio) throw new NotImplementedException();
            if (file == null) throw new ArgumentNullException(nameof(file));
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            if (file.CanSeek)
                file.Position = 0;

            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["type"] = type.ToString();

            var uploadingUrlResponse = await _httpClient.PostAsync($"uploads?{parameters}", null, cts).ConfigureAwait(false);
            await ThrowIfNotSuccessful(uploadingUrlResponse, "getting uploading url").ConfigureAwait(false);

            var urlResponse = await uploadingUrlResponse.Content.ReadFromJsonAsync<UploadsGetUrlResponse>().ConfigureAwait(false);
            var url = urlResponse?.Url;

            if (url == null) throw new MaxBotException("Url to upload was null");

            if (type == UploadType.Image)
                return await UploadImage(url, fileName, file, cts).ConfigureAwait(false);
            if (type == UploadType.File)
                return await UploadFile(url, fileName, file, cts).ConfigureAwait(false);

            return "";
        }
    }
}
