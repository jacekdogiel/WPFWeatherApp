using System.Collections.ObjectModel;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherVM
    {
        public AccuWeather Weather { get; set; }

        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                GetCities();
            }
        }

        public ObservableCollection<City> Cities { get; set; }
        public ObservableCollection<DailyForecast> Forecasts { get; set; }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                GetWeather();
            }
        }



        public WeatherVM()
        {
            Weather = new AccuWeather();
            Cities = new ObservableCollection<City>();
            Forecasts = new ObservableCollection<DailyForecast>();
            SelectedCity = new City();
        }

        private async void GetCities()
        {
            var cities = await WeatherAPI.GetAutocompleteAsync(Query);

            Cities.Clear();

            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        private async void GetWeather()
        {
            if (!string.IsNullOrEmpty(selectedCity.Key))
            {
                var weather = await WeatherAPI.GetWeatherInformationAsync(selectedCity.Key);
                Weather.DailyForecasts = weather.DailyForecasts;
            }

            Forecasts.Clear();
            if (Weather.DailyForecasts != null)
            {
                foreach (var forecast in Weather.DailyForecasts)
                {
                    Forecasts.Add(forecast);
                }
            }
        }
    }
}
