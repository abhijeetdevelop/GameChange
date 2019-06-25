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
using GameChange.Controls;
using GameChange.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace GameChange.Droid.CustomRenderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
        {
        }

        public static void Init() { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                //Control.Background = null;

                //var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                ////layoutParams.SetMargins(0, 0, 0, 0);
                ////LayoutParameters = layoutParams;
                ////Control.LayoutParameters = layoutParams;
                ////Control.SetPadding(0, 0, 0, 0);
                ////SetPadding(0, 0, 0, 0);
                Control.SetTextColor(Android.Graphics.Color.DarkCyan);
            }
        }
    }
}