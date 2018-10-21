using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace WeatherApp
{
    [Activity(Label = "DayForecast")]
    public class DayForecast : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            var weather = Core.Weathers.weathers[Core.Weathers.chosenDay];

            DateTime date = Convert.ToDateTime(weather.Date);
            string day = date.ToString("dddd HH:mm");

            var Icon = FindViewById<ImageView>(Resource.Id.imageView1);
            FindViewById<EditText>(Resource.Id.CitySearch).Visibility = ViewStates.Invisible;
            FindViewById<Button>(Resource.Id.button1).Visibility = ViewStates.Invisible;
            FindViewById<Button>(Resource.Id.button2).Visibility = ViewStates.Invisible;

            FindViewById<TextView>(Resource.Id.Title).Text = day;
            FindViewById<TextView>(Resource.Id.Temp).Text = weather.Temperature;
            FindViewById<TextView>(Resource.Id.speed).Text = weather.Wind;
            FindViewById<TextView>(Resource.Id.press).Text = weather.AirPressure;

            switch (weather.Icon)
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
            //var Icon = FindViewById<ImageView>(Resource.Id.imageView1);

            // Create your application here
        }
    }
}