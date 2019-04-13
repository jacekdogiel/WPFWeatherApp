using System;
using System.Collections.Generic;

namespace WeatherApp.Model
{
    public class Range
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public Range Minimum { get; set; }
        public Range Maximum { get; set; }
    }

    public class TimeOfDay
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
    }

    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public Temperature Temperature { get; set; }
        public TimeOfDay Day { get; set; }
        public TimeOfDay Night { get; set; }
        public List<string> Sources { get; set; }
    }

    public class AccuWeather
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }
}
