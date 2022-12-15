using System.Text.Json;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    string DAPR_STORE_NAME = "statestore";

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    // [HttpGet]
    // public async Task<string> Get([FromServices]DaprClient client)
    // {
    //     // var weather = await cache.GetStringAsync("weather");

    //     var weather = await client.GetStateAsync<string>(DAPR_STORE_NAME,"weather");

    //     if (weather == null)
    //     {
    //         var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //         {
    //             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //             TemperatureC = Random.Shared.Next(-20, 55),
    //             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //         })
    //         .ToArray();

    //         weather = JsonSerializer.Serialize(forecasts);
    //         await client.SaveStateAsync(DAPR_STORE_NAME,"weather", weather);
    //     }
    //     return weather;
    // }
    
}
