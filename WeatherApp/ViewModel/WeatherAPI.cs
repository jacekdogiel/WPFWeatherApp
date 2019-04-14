using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherAPI
    {
        public const string API_KEY = "ohXrTBlqBXIDxPGZq5djbbfVLo3QBkTa";
        public const string BASE_URL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&metric=true";
        public const string AUTOCOMPLETE_URL = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";


        public static async Task<AccuWeather> GetWeatherInformationAsync(string locationKey)
        {
            var result = new AccuWeather();

            string url = string.Format(BASE_URL, locationKey, API_KEY);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<AccuWeather>(json);
            }
            return result;
        }

        public static async Task<List<City>> GetAutocompleteAsync(string query)
        {
            var result = new List<City>();

            string url = string.Format(AUTOCOMPLETE_URL, API_KEY, query);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<City>>(json);
            }
            return result;
        }
    }
}
