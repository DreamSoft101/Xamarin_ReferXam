using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;
using CoreGraphics;
using Foundation;
using ReferLocal;
using ReferLocal.iOS;


[assembly: Xamarin.Forms.ResolutionGroupName("Effects")]
[assembly: Xamarin.Forms.ExportEffect(typeof(ButtonEffect), "ButtonEffect")]
namespace ReferLocal.iOS
{
	public class ButtonEffect: Xamarin.Forms.Platform.iOS.PlatformEffect
	{
		protected override void OnAttached()
		{
			throw new NotImplementedException();
		}

		protected override void OnDetached()
		{
			throw new NotImplementedException();
		}
	}
}
