namespace MaxBot;

public class MaxBot : IDisposable, IAsyncDisposable
{
    private bool _disposed = false;
    private readonly string _maxDefaultUrl = "https://platform-api.max.ru";
    private readonly string _token;
    private readonly HttpClient _httpClient;    

    public MaxBot(string token, HttpClient? httpClient = null)
    {
        _token = token;
        _httpClient = httpClient ?? new HttpClient();

        if (httpClient == null)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _token);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            _httpClient.BaseAddress = new Uri(_maxDefaultUrl);
        }

    }

    
    public void Dispose()
    {
        if (!_disposed)
        {
            _httpClient?.Dispose();
        
            _disposed = true;
        }
    }

    public async ValueTask DisposeAsync()
    {
        Dispose();
    }

    public async Task Subscribe(string url)
    {
       
    }

}
