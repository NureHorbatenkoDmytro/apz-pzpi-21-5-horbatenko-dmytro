namespace FloraService.ApiLayer.Abstractions
{
    public interface IHttpClientFabric
    {
        HttpClient CreateHttpClient();
    }
}
