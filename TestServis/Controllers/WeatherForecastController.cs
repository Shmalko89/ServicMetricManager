
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TestServis.Controllers
{
    [Route("api/crud")]
    [ApiController]

    public class WheatherForecastController : Controller
    {


        private TempHolder _tempHolder;
        public WheatherForecastController(TempHolder tempHolder)
        {
            _tempHolder = tempHolder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] int TemperatureC, [FromQuery] DateTime Date)
        {
            _tempHolder.THolder.Add(new WeatherForecast());
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] int UpdateTemperatureC, [FromQuery] DateTime Date, [FromQuery] int NewTemperatureC)
        {
            foreach (WeatherForecast data in _tempHolder.THolder)
            {
                if (data.TemperatureC == UpdateTemperatureC && data.Date == Date)
                    data.TemperatureC = NewTemperatureC;
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            foreach (WeatherForecast data in _tempHolder.THolder.ToList())
            {
                if (data.Date >= from && data.Date <= to)
                {
                    _tempHolder.THolder.Remove(data);
                }
            }
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            foreach (WeatherForecast data in _tempHolder.THolder)
            {
                return Ok(data.Date >= from && data.Date <= to);
            }
            return Ok();
        }

    }
}
