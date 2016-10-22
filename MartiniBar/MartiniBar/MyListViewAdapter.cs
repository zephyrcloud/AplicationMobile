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

namespace MartiniBar
{
    class MyListViewAdapter : BaseAdapter<Menu>
    {
        private List<Menu> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context, List<Menu> items) {
            mItems = items;
            mContext = context;
        }

        public override Menu this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null) {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView txtName = row.FindViewById<TextView>(Resource.Id.textView_superior);
            txtName.Text = mItems[position].item;

            TextView txtPrice = row.FindViewById<TextView>(Resource.Id.textView_inferior);
            txtPrice.Text = mItems[position].price;

            TextView descr = row.FindViewById<TextView>(Resource.Id.Description);
            descr.Text = mItems[position].description;

            ImageView img = row.FindViewById<ImageView>(Resource.Id.imageView_imagen);
            img.SetImageResource(mItems[position].idImage);

            return row;
        }
    }
}