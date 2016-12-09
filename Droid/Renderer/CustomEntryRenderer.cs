using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using ReferLocal;
using ReferLocal.Droid;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ReferLocal.Droid
{
	public class CustomEntryRenderer: EntryRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				//Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
				Control.Background = null;
			}
		}
	}
}
