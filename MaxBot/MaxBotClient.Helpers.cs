using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http.Headers;

namespace MaxBot
{
    public partial class MaxBotClient
    {
        private static readonly FileExtensionContentTypeProvider provider = new();

        private async Task ThrowIfNotSuccessful(HttpResponseMessage? message, string action, CancellationToken cts = default)
        {
            if (message is null)
                throw new ArgumentNullException($"Http response message was null");

            if (message.IsSuccessStatusCode) return;

            var errorMessage = await message.Content.ReadAsStringAsync(cts).ConfigureAwait(false);
            throw new MaxBotException($"{message.StatusCode} Error while {action}: {errorMessage}");
        }

        private string GetContentType(string fileName)
        {
            string contentType = "application/octet-stream";
            if (provider.TryGetContentType(fileName, out string? mime))
            {
                contentType = mime;
            }
            return contentType;
        }

        private StreamContent GetStreamContent(string fileName, Stream file)
        {
            var fileContent = new StreamContent(file);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(GetContentType(fileName));
            return fileContent;
        }
    }
}
