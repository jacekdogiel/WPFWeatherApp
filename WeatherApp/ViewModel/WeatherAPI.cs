using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherAPI
    {
        public const string API_KEY = "ohXrTBlqBXIDxPGZq5djbbfVLo3QBkTa";
        public const string BASE_URL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&metric=true";

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
    }
}
