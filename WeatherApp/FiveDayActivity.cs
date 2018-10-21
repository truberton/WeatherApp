using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
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

            list.ItemClick += list_Click;
        }

        private void list_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            //switch (e.Position)
            //{
            //    case 0:
            //        Core.Weathers.chosenDay = "1";
            //        break;
            //    case 1:
            //        Core.Weathers.chosenDay = "9";
            //        break;
            //    case 2:
            //        Core.Weathers.chosenDay = "17";
            //        break;
            //    case 3:
            //        Core.Weathers.chosenDay = "25";
            //        break;
            //    case 4:
            //        Core.Weathers.chosenDay = "33";
            //        break;
            //    default:
            //        Core.Weathers.chosenDay = "0";
            //        break;
            //}
            Core.Weathers.chosenDay = e.Position;
            var certainDay = new Intent(this, typeof(DayForecast));
            StartActivity(certainDay);
        }
    }
}