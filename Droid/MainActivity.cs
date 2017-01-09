using System;
using Stripe;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;

namespace ReferLocal.Droid
{
	[Activity(Label = "ReferLocal.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Theme = "@style/AppTheme")]

	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);


			Stripe.StripeClient.DefaultPublishableKey = "pk_test_qmnxHIxwb56pjZGWgRTOwlt5";

			UserDialogs.Init(this);
			LoadApplication(new App());
		}
	}
}
