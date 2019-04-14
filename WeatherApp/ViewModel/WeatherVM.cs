using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherVM
    {
        public AccuWeather Weather { get; set; }

        public WeatherVM()
        {
            Weather = new AccuWeather();
        }
    }
}
