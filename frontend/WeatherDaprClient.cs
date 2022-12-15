using System.Text.Json;
using Dapr.Client;

namespace frontend
{
    public class WeatherDaprClient
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        private readonly DaprClient _daprClient;

        public WeatherDaprClient(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        

        public async Task<WeatherForecast[]?> GetWeatherAsync()
        {
            //return await this.client.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");

            var req = _daprClient.CreateInvokeMethodRequest(HttpMethod.Get,"backend","/weatherforecast");
            return await _daprClient.InvokeMethodAsync<WeatherForecast[]>(req);
        }
    }
}