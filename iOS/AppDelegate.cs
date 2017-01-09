using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Stripe;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ReferLocal.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif


			Stripe.StripeClient.DefaultPublishableKey = "pk_test_qmnxHIxwb56pjZGWgRTOwlt5";
			LoadApplication(new App());
			ConfigureTheme();

			return base.FinishedLaunching(app, options);
		}

		void ConfigureTheme()
		{

			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
			UIApplication.SharedApplication.SetStatusBarHidden(false, false);
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.BarTintColor = Color.FromHex("#1269b0").ToUIColor();


			UITabBar.Appearance.TintColor = UIColor.White;
			UITabBar.Appearance.BarTintColor = UIColor.White;
			UITabBar.Appearance.SelectedImageTintColor = UIColor.Black;
			UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.Black }, UIControlState.Selected);

		}
	}
}
