using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using GasAgency.CustomControl;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace GasAgency.Droid.CustomRenderer
{
    class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var view = (ExtendedEntry)Element;
            if (Control != null|| e.NewElement!=null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetShape(ShapeType.Rectangle);
                gd.SetColor(global::Android.Graphics.Color.Gray);
                gd.SetStroke(30,Color.Gray.ToAndroid());
                Control.SetBackground(gd);
                Control.SetPadding
                    (
                        (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                        (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom
                    );
                Control.SetBackgroundColor(global::Android.Graphics.Color.White);
            }
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}