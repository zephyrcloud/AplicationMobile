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
    class Menu
    {
        public string item { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public int idImage { get; set; }
    }
}