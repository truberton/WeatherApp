using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name")]
    class FiveDay : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            List<Core.Weather> weather = Core.Weathers.weathers;
            string[] weathers = new string[] { weather[0].Date + " is " + weather[0].Main + " and the temperature will be " + weather[0].Temperature, weather[1].Date + " is " + weather[1].Main + " and the temperature will be " + weather[1].Temperature };
            base.OnCreate(savedInstanceState);
            ListAdapter = new ArrayAdapter<string>(this,
            Android.Resource.Layout.SimpleListItem1, weathers);
            ListView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs args)
        {
            Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Long).Show();
        }
    }
}