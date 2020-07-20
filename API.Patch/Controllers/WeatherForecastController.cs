using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API.Patch.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> _weatherForecasts = new List<WeatherForecast>
        {
            new WeatherForecast
            {
                Id = 1,
                Date = DateTime.Now.AddDays(1),
                TemperatureC = 25,
                Summary = Summaries[0]
            },new WeatherForecast
            {
                Id = 2,
                Date = DateTime.Now.AddDays(2),
                TemperatureC = 26,
                Summary = Summaries[1]
            },new WeatherForecast
            {
                Id = 3,
                Date = DateTime.Now.AddDays(3),
                TemperatureC = 27,
                Summary = Summaries[2]
            },new WeatherForecast
            {
                Id = 4,
                Date = DateTime.Now.AddDays(4),
                TemperatureC = 28,
                Summary = Summaries[3]
            },new WeatherForecast
            {
                Id = 5,
                Date = DateTime.Now.AddDays(5),
                TemperatureC = 29,
                Summary = Summaries[4]
            }
        };

        [HttpGet]
        [Route("WeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecasts;
        }

        [HttpPatch]
        [Route("WeatherForecast/{id:int}")]
        public IActionResult Patch([Required] int id, [Required, FromBody] JObject patchObject)
        {
            var objectToPatch = _weatherForecasts.FirstOrDefault(f => f.Id == id);

            if (objectToPatch is null)
                return NotFound();

            patchObject.PopulateObject(objectToPatch);

            return Ok(objectToPatch);
        }
    }
}
