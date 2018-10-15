using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class FiveDayCore
    {
        public static async Task<List<Weather>> GetWeather(string City)
        {
            List<Weather> weathers = new List<Weather>();
            string queryString = "http://api.openweathermap.org/data/2.5/forecast?q=" + City + "&units=metric&appid=ef0b32214b6a100ab1811e267f5e7feb";
            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            var weather0 = new Weather();
            weather0.Temperature = (string)results["list"][3]["main"]["temp"] + "c";
            weather0.Wind = (string)results["list"][3]["wind"]["speed"] + " m/s";
            weather0.Main = (string)results["list"][3]["weather"][0]["main"];
            weather0.Date = (string)results["list"][3]["dt_txt"];
            weathers.Add(weather0);

            var weather1 = new Weather();
            weather1.Temperature = (string)results["list"][11]["main"]["temp"] + "c";
            weather1.Wind = (string)results["list"][11]["wind"]["speed"] + " m/s";
            weather1.Main = (string)results["list"][11]["weather"][0]["main"];
            weather1.Date = (string)results["list"][11]["dt_txt"];
            weathers.Add(weather1);

            return weathers;
        }
    }
}
