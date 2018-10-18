using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace WeatherApp
{
    public class Adapter : BaseAdapter<Core.Weather>
    {
        List<Core.Weather> weathers;
        Activity context;

        public Adapter(Activity context, List<Core.Weather> items) : base()
        {
            this.context = context;
            this.weathers = items;
        }

        public override Core.Weather this[int position]
        {
            get { return weathers[position]; }
        }

        public override int Count { get { return weathers.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.FiveDayLayout, null);
            }
            DateTime date = Convert.ToDateTime(weathers[position].Date);
            view.FindViewById<TextView>(Resource.Id.SDate).Text = date.ToString("dddd HH:mm");
            view.FindViewById<TextView>(Resource.Id.STemp).Text = weathers[position].Temperature;
            view.FindViewById<TextView>(Resource.Id.SType).Text = weathers[position].Main;

            return view;
        }
    }
}
