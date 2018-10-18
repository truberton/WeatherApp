using System;
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
    public class Adapter : BaseAdapter<Core.Weather>
    {
        List<Core.Weather> items;
        Activity context;

        public Adapter(Activity context, List<Core.Weather> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override Core.Weather this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.FiveDayLayout, null);

            view.FindViewById<TextView>(Resource.Id.STemp).Text = items[position].Temperature;
            view.FindViewById<TextView>(Resource.Id.STemp).Text = items[position].Main;

            return view;
        }
    }
}