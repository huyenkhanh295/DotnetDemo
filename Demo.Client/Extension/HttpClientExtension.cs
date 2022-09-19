using Demo.Client.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Demo.Client.Extension;

public class HttpClientExtension
{
    private HttpClient _httpClient;
    private HttpClientExtension(string url)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(url);
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

    }

    public static HttpClientExtension Instance(string url)
    {
        return new HttpClientExtension(url);
    }

    public HttpClientExtension SetToken(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return this;
    }

    public async Task<TResult> PostAsync<T, TResult>(string path, T model)
    {
        var response = await _httpClient.PostAsJsonAsync(path, model);
        var stringContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TResult>(stringContent);

        return result;
    }

    public async Task<TResult> GetAsync<TResult>(string path) where TResult : BaseModel, new()
    {
        var result = new TResult();
        var response = await _httpClient.GetAsync(path);
        result.Content = await response.Content.ReadAsStringAsync();
        result.StatusCode = response.StatusCode;

        return result;
    }
}