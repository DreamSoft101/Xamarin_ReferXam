using System;
using ReferLocal;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

using UIKit;
using CoreGraphics;
using Foundation;
using ReferLocal.iOS;
using BigTed;



[assembly: Dependency(typeof(Hud))]
namespace ReferLocal.iOS
{
	public class Hud : IHud
	{
		public Hud()
		{
		}

		public void Show()
		{
			BTProgressHUD.Show();
		}

		public void Show(string message)
		{
			BTProgressHUD.Show(message);
		}

		public void Dismiss()
		{
			BTProgressHUD.Dismiss();
		}
	}
}
