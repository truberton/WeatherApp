using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string City)
        {
            string key = "ef0b32214b6a100ab1811e267f5e7feb";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + City + "&units=metric&appid=" + key;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Weather();
            weather.Title = (string)results["name"];
            weather.Temperature = (string)results["main"]["temp"] + "c";
            weather.Wind = (string)results["wind"]["speed"] + " m/s";
            weather.AirPressure = (string)results["main"]["pressure"] + " hpa";
            weather.Main = (string)results["weather"][0]["main"];

            return weather;
        }
    }
}