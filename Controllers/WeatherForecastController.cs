using Microsoft.AspNetCore.Mvc;

namespace MyMicroservice.Controllers;

[ApiController]
[Route("[controller]")]

// i assume use ControllerBase because class does not need view support
public class WeatherForecastController : ControllerBase
{
    //create a list of string weather conditions
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    //sends data using query string. data attached to url and is visible to all
    //http post using heap method to send data. data not attached to url and is not visible to all
    [HttpGet(Name = "GetWeatherForecast")]

    //return five days worth of weather forecast via range 1,5
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            //retrieve datetime now
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //randomize temp
            TemperatureC = Random.Shared.Next(-20, 55),
            //randomize weather conditions
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
