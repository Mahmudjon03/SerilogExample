using Serilog;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly Serilog.ILogger _log;

    public WeatherForecastController(Serilog.ILogger log)
    {
        _log = log;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get(int id)
    {

        {
            if (id > 1)
            {
                var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                       .ToArray();
                _log.Information($"Test -> Serolig information");

                return result;
            }
            else
            {
                _log.Error($"Weather forecasts are not supported.");
                return Enumerable.Empty<WeatherForecast>();
            }



        }
    }
}
