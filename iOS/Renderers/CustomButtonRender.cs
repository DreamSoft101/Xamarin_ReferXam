using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;
using CoreGraphics;
using Foundation;
using ReferLocal;
using ReferLocal.iOS;
[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRender))]
namespace ReferLocal.iOS
{
	public class CustomButtonRender: ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			var button = (CustomButton)Element;

			if (button == null) return;

			var control = new UIButton(UIButtonType.Custom);

				
		}
	}
}
