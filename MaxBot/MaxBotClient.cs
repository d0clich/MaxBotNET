using MaxBot.Models.Subscriptions;
using MaxBot.Models.Subscriptions.Http;
using MaxBot.Objects;
using MaxBot.Objects.Types;
using MaxBot.Objects.Users;
using System;
using System.Net.Http.Json;
using System.Web;
using MaxBot.Models;
using MaxBot.Models.Uploads;
using MaxBot.Models.Messages;
using MaxBot.Objects.Additional;
using System.Text.Json.Serialization;
using System.Text.Json;

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
            parameters["disable_link_perview"] = disableLinkPreview.ToString();

        var request = new SendMessageRequest()
        {
            Text = text,
            Attachments = attachments,
            Link = link,
            Notify = notify,
            Format = format
        };

        Console.WriteLine(JsonSerializer.Serialize(request, new JsonSerializerOptions() { WriteIndented = true}));

        var response = await _httpClient.PostAsJsonAsync($"messages?{parameters}", request, cts).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync(cts).ConfigureAwait(false);
            throw new MaxBotException($"{response.StatusCode} Error while sending message: {errorMessage}");
        }

        var message = await response.Content.ReadFromJsonAsync<Message>(cts).ConfigureAwait(false);

        return message;
    }
    
    public async Task<BotInfo> GetMe(CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));

        var botInfo = await _httpClient.GetFromJsonAsync<BotInfo>("me", cts).ConfigureAwait(false);

        if (botInfo == null) throw new MaxBotException("Не удалось получить информацию о боте");

        return botInfo;
    }

    public async Task<UpdatesWithMarker> GetUpdates(UpdateType[]? types = null, int? limit = null, int? timeout = null, int? marker = null, CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));

        var model = new UpdatesGet(types, limit, timeout, marker);
        var updates = await _httpClient.GetFromJsonAsync<GetUpdatesResponse>("updates",cts).ConfigureAwait(false);

        return new UpdatesWithMarker() { Marker = updates!.Marker, Updates = updates!.Updates};
    }

    public async Task RemoveSubscription(string url, CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));
        if (url == null) throw new ArgumentNullException(nameof(url));

        var query = HttpUtility.ParseQueryString(string.Empty);
        query["url"] = url; 
      
        var response = await _httpClient.DeleteFromJsonAsync<SuccessResponse>($"subscriptions?{query}",cts).ConfigureAwait(false);

        if (response is not { Success:true})
            throw new MaxBotException(response?.Message ?? "unknown error");
    }

    public async Task<Subscription[]?> GetSubscriptions(CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));

        var subscriptions = await _httpClient.GetFromJsonAsync<Subscription[]>("subscriptions", cts).ConfigureAwait(false);

        return subscriptions;
    }

    public async Task Subscribe(string url, UpdateType[]? types = null, string? secret = null, CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));
        if (url == null) throw new ArgumentNullException(nameof(url));

        var model = new SubscriptionsPost(url,types,secret);
        var response = await _httpClient.PostAsJsonAsync("subscriptions", model, cts).ConfigureAwait(false);
        var jsonResponse = await response.Content.ReadFromJsonAsync<SuccessResponse>().ConfigureAwait(false);

        if (jsonResponse is not { Success: true})
            throw new MaxBotException(jsonResponse?.Message ?? "unknown error");
    }
}
