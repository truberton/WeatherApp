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
            weather0.Temperature = (string)results["list"][1]["main"]["temp"] + "c";
            weather0.Wind = (string)results["list"][1]["wind"]["speed"] + " m/s";
            weather0.Main = (string)results["list"][1]["weather"][0]["main"];
            weather0.Date = (string)results["list"][1]["dt_txt"];
            weathers.Add(weather0);

            var weather1 = new Weather();
            weather1.Temperature = (string)results["list"][9]["main"]["temp"] + "c";
            weather1.Wind = (string)results["list"][9]["wind"]["speed"] + " m/s";
            weather1.Main = (string)results["list"][9]["weather"][0]["main"];
            weather1.Date = (string)results["list"][9]["dt_txt"];
            weathers.Add(weather1);

            var weather2 = new Weather();
            weather2.Temperature = (string)results["list"][17]["main"]["temp"] + "c";
            weather2.Wind = (string)results["list"][17]["wind"]["speed"] + " m/s";
            weather2.Main = (string)results["list"][17]["weather"][0]["main"];
            weather2.Date = (string)results["list"][17]["dt_txt"];
            weathers.Add(weather2);

            var weather3 = new Weather();
            weather3.Temperature = (string)results["list"][25]["main"]["temp"] + "c";
            weather3.Wind = (string)results["list"][25]["wind"]["speed"] + " m/s";
            weather3.Main = (string)results["list"][25]["weather"][0]["main"];
            weather3.Date = (string)results["list"][25]["dt_txt"];
            weathers.Add(weather3);

            var weather4 = new Weather();
            weather4.Temperature = (string)results["list"][33]["main"]["temp"] + "c";
            weather4.Wind = (string)results["list"][33]["wind"]["speed"] + " m/s";
            weather4.Main = (string)results["list"][33]["weather"][0]["main"];
            weather4.Date = (string)results["list"][33]["dt_txt"];
            weathers.Add(weather4);

            return weathers;
        }
    }
}
