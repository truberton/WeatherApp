using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

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

            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, System.EventArgs e)
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
                default:
                    break;
            }
        }
    }
}