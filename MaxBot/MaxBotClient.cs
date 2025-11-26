using MaxBot.Models;
using MaxBot.Models.Messages;
using MaxBot.Objects;
using MaxBot.Objects.Types;
using MaxBot.Objects.Users;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace MaxBot;

public partial class MaxBotClient : IDisposable, IAsyncDisposable
{
    private bool _disposed = false;

    private readonly string _maxDefaultUrl = "https://platform-api.max.ru";
    private readonly string _token;

    private readonly bool _disposeHttpClient;
    private readonly HttpClient _httpClient;    

    public MaxBotClient(string token, HttpClient? httpClient = null)
    {
        _token = !string.IsNullOrWhiteSpace(token) ? token : throw new ArgumentNullException(nameof(token));

        _httpClient = httpClient ?? new HttpClient();
        _disposeHttpClient = httpClient == null;

        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _token);
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

        _httpClient.BaseAddress = new Uri(_maxDefaultUrl);  
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            if (_disposeHttpClient)
                _httpClient?.Dispose();
        
            _disposed = true;
        }
    }

    public async ValueTask DisposeAsync()
    {
        Dispose();
    }
    
    public async Task DeleteMessage(string messageId, CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));

        var parameters = HttpUtility.ParseQueryString(string.Empty);
        parameters["message_id"] = messageId.ToString();

        var response = await _httpClient.DeleteAsync($"messages?{parameters}", cts).ConfigureAwait(false);
        await ThrowIfNotSuccessful(response, "deleting").ConfigureAwait(false);

        var successResponse = await response.Content.ReadFromJsonAsync<SuccessResponse>(cts);
        if (successResponse == null)
            throw new MaxBotException("Response content is null");
        if (!successResponse.Success)
            throw new MaxBotException("Error while deleting message: " + successResponse.Message);
    }

    public async Task<Message?> SendMessage(
        long? chatId = null, 
        long? userId = null, 
        long? disableLinkPreview = null, 
        string? text = null, 
        IEnumerable<Attachment>? attachments = null, 
        Link? link = null, 
        bool notify = true, 
        FormatType? format = null,
        CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));
        if (chatId == null && userId == null) throw new ArgumentNullException("Both " + nameof(userId) + " and " + nameof(chatId) + " are null");

        var parameters = HttpUtility.ParseQueryString(string.Empty);
        
        if (chatId != null)
            parameters["chat_id"] = chatId.ToString();
        if (userId != null)
            parameters["user_id"] = userId.ToString();
        if (disableLinkPreview != null)
            parameters["disable_link_preview"] = disableLinkPreview.ToString();

        var request = new SendMessageRequest()
        {
            Text = text,
            Attachments = attachments,
            Link = link,
            Notify = notify,
            Format = format
        };

        var response = await _httpClient.PostAsJsonAsync($"messages?{parameters}", request, cts).ConfigureAwait(false);
        await ThrowIfNotSuccessful(response, "sending").ConfigureAwait(false);

        var message = await response.Content.ReadFromJsonAsync<MessageWrapper>(cts).ConfigureAwait(false);
        if (message?.Message == null)
            throw new MaxBotException($"Empty message info");

        return message.Message;
    }
    
    public async Task<BotInfo> GetMe(CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));

        var botInfo = await _httpClient.GetFromJsonAsync<BotInfo>("me", cts).ConfigureAwait(false);

        if (botInfo == null) throw new MaxBotException("Не удалось получить информацию о боте");

        return botInfo;
    }
}
