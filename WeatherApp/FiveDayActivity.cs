using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Collections.Generic;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name")]
    public class FiveDayActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_5Day);
            var list = FindViewById<ListView>(Resource.Id.listView1);
            List<Core.Weather> weathers = Core.Weathers.weathers;
            list.Adapter = new Adapter(this, weathers);
        }
    }
}