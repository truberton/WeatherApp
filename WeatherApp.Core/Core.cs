using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string City)
        {
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + City + "&units=metric&appid=ef0b32214b6a100ab1811e267f5e7feb";

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Weather();
            weather.Title = (string)results["name"];
            weather.Temperature = (string)results["main"]["temp"] + "c";
            weather.Wind = (string)results["wind"]["speed"] + " m/s";
            weather.AirPressure = (string)results["main"]["pressure"] + " hpa";
            weather.Main = (string)results["weather"][0]["icon"];

            return weather;
        }
    }
}