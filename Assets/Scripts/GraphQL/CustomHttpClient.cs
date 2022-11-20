using System.Net.Http;

public class CustomHttpClient : IHttpClientFactory
{
    public HttpClient CreateClient(string name)
    {
        return new HttpClient();
    }
}