using System;
using System.Collections.Generic;

namespace TestServis
{
    public class TempHolder
    {
        public List<WeatherForecast> THolder { get; set; }

        public TempHolder()
        {
            THolder = new List<WeatherForecast>();
        }
    }
}
