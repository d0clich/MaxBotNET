using MaxBot.Models.Subscriptions;
using MaxBot.Models.Subscriptions.Http;
using MaxBot.Objects;
using MaxBot.Objects.Types;
using MaxBot.Objects.Users;
using System.Net.Http.Json;

namespace MaxBot;

public class MaxBotClient : IDisposable, IAsyncDisposable
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

    public async Task<BotInfo> GetMe(CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBot));

        var botInfo = await _httpClient.GetFromJsonAsync<BotInfo>("me", cts).ConfigureAwait(false);

        if (botInfo == null) throw new MaxBotException("Не удалось получить информацию о боте");

        return botInfo;
    }

    public async Task<GetUpdatesResponse> GetUpdates(UpdateType[]? types = null, int? limit = null, int? timeout = null, int? marker = null, CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBot));

        var model = new UpdatesGet(types, limit, timeout, marker);
        var updates = await _httpClient.GetFromJsonAsync<GetUpdatesResponse>("updates",cts).ConfigureAwait(false);

        return updates!;
    }

    public async Task RemoveSubscription(CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBot));

        var response = await _httpClient.DeleteAsync("subscriptions",cts).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            throw new MaxBotException(await response.Content.ReadAsStringAsync(cts).ConfigureAwait(false));
    }

    public async Task<Subscription[]?> GetSubscriptions(CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBot));

        var subscriptions = await _httpClient.GetFromJsonAsync<Subscription[]>("subscriptions", cts).ConfigureAwait(false);

        return subscriptions;
    }

    public async Task Subscribe(string url, UpdateType[]? types = null, string? secret = null, CancellationToken cts = default)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MaxBot));

        var model = new SubscriptionsPost(url,types,secret);
        var response = await _httpClient.PostAsJsonAsync("subscriptions", model, cts).ConfigureAwait(false);
        
        if (!response.IsSuccessStatusCode)
            throw new MaxBotException(await response.Content.ReadAsStringAsync(cts).ConfigureAwait(false));
    }
}
