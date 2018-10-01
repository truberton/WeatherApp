using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class Core
    {
        public static async Task<Weather> GetWeather()
        {
            string key = "ef0b32214b6a100ab1811e267f5e7feb";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=Tallinn&units=metric&appid=" + key;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Weather();
            weather.Title = (string)results["name"];
            weather.Temperature = (string)results["main"]["temp"] + "c";
            weather.Wind = (string)results["wind"]["speed"] + " m/s";

            return weather;
        }
    }
}