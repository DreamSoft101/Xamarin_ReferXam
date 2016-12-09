using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ReferLocal;
using ReferLocal.Droid;
using Android.Text;
using Android.Widget;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]

namespace ReferLocal.Droid
{
	public class HtmlLabelRenderer: LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			Control?.SetText(Html.FromHtml(Element.Text), TextView.BufferType.Spannable);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Label.TextProperty.PropertyName)
			{
				Control?.SetText(Html.FromHtml(Element.Text), TextView.BufferType.Spannable);

			}
		}
	}
}
