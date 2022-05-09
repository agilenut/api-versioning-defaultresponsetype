using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.DoesntWork.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/weather")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] _summaries = { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    [ProducesDefaultResponseType]
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                                                      {
                                                          Date = DateTime.Now.AddDays(index),
                                                          TemperatureC = Random.Shared.Next(-20, 55),
                                                          Summary = _summaries[Random.Shared.Next(_summaries.Length)]
                                                      })
                         .ToArray();
    }
}
