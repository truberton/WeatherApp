using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using System.Net;
using System;
using System.Collections.Generic;
using Android.Content;
using System.Threading.Tasks;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var button = FindViewById<Button>(Resource.Id.button1);
            var button2 = FindViewById<Button>(Resource.Id.button2);

            button.Click += Button_Click;
            button2.Click += Button2_Click;
        }

        private async void Button2_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FindViewById<TextView>(Resource.Id.Title).Text))
            {
                try
                {
                    await GetForecast();
                    var fiveDay = new Intent(this, typeof(FiveDay));
                    StartActivity(fiveDay);
                }
                catch (Exception)
                {
                    Toast.MakeText(Application, "Something is wrong, please try again", ToastLength.Long).Show();
                }
            }
        }

        private async Task<List<Core.Weather>> GetForecast()
        {
            List<Core.Weather> weather = await Core.FiveDayCore.GetWeather(FindViewById<EditText>(Resource.Id.CitySearch).Text);
            Core.Weathers.weathers = weather;
            return weather;
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            try
            {
                var Title = FindViewById<TextView>(Resource.Id.Title);
                var Temp = FindViewById<TextView>(Resource.Id.Temp);
                var Speed = FindViewById<TextView>(Resource.Id.speed);
                var Press = FindViewById<TextView>(Resource.Id.press);
                var Icon = FindViewById<ImageView>(Resource.Id.imageView1);
                var citySearch = FindViewById<EditText>(Resource.Id.CitySearch);

                var weather = await Core.Core.GetWeather(citySearch.Text);
                Title.Text = weather.Title;
                Temp.Text = weather.Temperature;
                Speed.Text = weather.Wind;
                Press.Text = weather.AirPressure;

                switch (weather.Main)
                {
                    case "01d":
                    case "01n":
                        Icon.SetImageResource(Resource.Drawable._01d);
                        break;
                    case "02d":
                    case "02n":
                        Icon.SetImageResource(Resource.Drawable._02d);
                        break;
                    case "03d":
                    case "03n":
                        Icon.SetImageResource(Resource.Drawable._03d);
                        break;
                    case "04d":
                    case "04n":
                        Icon.SetImageResource(Resource.Drawable._04d);
                        break;
                    case "09d":
                    case "09n":
                        Icon.SetImageResource(Resource.Drawable._09d);
                        break;
                    case "10d":
                    case "10n":
                        Icon.SetImageResource(Resource.Drawable._10d);
                        break;
                    case "11d":
                    case "11n":
                        Icon.SetImageResource(Resource.Drawable._11d);
                        break;
                    case "13d":
                    case "13n":
                        Icon.SetImageResource(Resource.Drawable._13d);
                        break;
                    case "50d":
                    case "50n":
                        Icon.SetImageResource(Resource.Drawable._50d);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                Toast.MakeText(Application, "That city does not exist or something else went wrong", ToastLength.Long).Show();
            }
        }
    }
}