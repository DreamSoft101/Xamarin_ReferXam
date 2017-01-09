using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;
using CoreGraphics;
using Foundation;
using ReferLocal;
using ReferLocal.iOS;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]

namespace ReferLocal.iOS
{
	public class HtmlLabelRenderer: LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
			{
				var attr = new NSAttributedStringDocumentAttributes();

				var nsError = new NSError();

				attr.DocumentType = NSDocumentType.HTML;

				var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);

				Control.Lines = 0;
				//Control.Font = UIFont.SystemFontOfSize(26);

				Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
			}


		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Label.TextProperty.PropertyName)
			{
				if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
				{
					var attr = new NSAttributedStringDocumentAttributes();

					var nsError = new NSError();

					attr.DocumentType = NSDocumentType.HTML;

					var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);

					Control.Lines = 0;
					//Control.Font = UIFont.SystemFontOfSize(26);
					Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
				}
			}
		}
	}
}
