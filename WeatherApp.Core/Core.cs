using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "ef0b32214b6a100ab1811e267f5e7feb";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=London" + "&appid=" + key;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Weather();
            weather.Temperature = (string)results["main"]["temp"] + " C";

            return weather;
        }
    }
}