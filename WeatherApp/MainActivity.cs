using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Content;
using System.Threading.Tasks;
using Android.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/MaxTheme", MainLauncher = true)]
    public class MainActivity : Activity 
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenter.Start("2914a09a-f9d1-4805-9224-ec27c2c54ef6",
                   typeof(Analytics), typeof(Crashes));
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar1);
            SetActionBar(toolbar);

            var button = FindViewById<Button>(Resource.Id.button1);
            var button2 = FindViewById<Button>(Resource.Id.button2);

            button.Click += Button_Click;
            button2.Click += Button2_Click;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
        ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            var Title = FindViewById<TextView>(Resource.Id.Title);
            var Temp = FindViewById<TextView>(Resource.Id.Temp);
            var Speed = FindViewById<TextView>(Resource.Id.speed);
            var Press = FindViewById<TextView>(Resource.Id.press);
            var Icon = FindViewById<ImageView>(Resource.Id.imageView1);
            var citySearch = FindViewById<EditText>(Resource.Id.CitySearch);

            try
            {
                var weather = await Core.Core.GetWeather(citySearch.Text);
                Title.Text = weather.Title;
                Temp.Text = weather.Temperature;
                Speed.Text = weather.Wind;
                Press.Text = weather.AirPressure;

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
            }
            catch (Exception)
            {
                Toast.MakeText(Application, "That city does not exist or something else went wrong", ToastLength.Long).Show();
            }
        }

        private async void Button2_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FindViewById<TextView>(Resource.Id.Title).Text))
            {
                try
                {
                    await GetForecast();
                    var fiveDayActivity = new Intent(this, typeof(FiveDayActivity));
                    StartActivity(fiveDayActivity);
                }
                catch (Exception)
                {
                    Toast.MakeText(Application, "Something is wrong, please enter the city again and try once more", ToastLength.Long).Show();
                }
            }
        }

        private async Task<List<Core.Weather>> GetForecast()
        {
            List<Core.Weather> weather = await Core.FiveDayCore.GetWeather(FindViewById<EditText>(Resource.Id.CitySearch).Text);
            Core.Weathers.weathers = weather;

            return weather;
        }

    }
}