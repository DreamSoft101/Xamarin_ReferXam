using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;
using CoreGraphics;
using Foundation;
using ReferLocal;
using ReferLocal.iOS;

[assembly: ExportRenderer (typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ReferLocal.iOS
{
	public class CustomEntryRenderer: EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			var view = e.NewElement as CustomEntry;

			if (view != null)
			{
				SetBackgroundColor(view);	
			}

		}

		private void SetBackgroundColor(CustomEntry view)
		{
			
			Control.BackgroundColor = UIColor.Clear;
			Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}
