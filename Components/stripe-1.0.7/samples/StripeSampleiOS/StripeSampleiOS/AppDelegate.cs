using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Stripe;

namespace StripeSampleiOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{

		// Replace this with your own key!
		public const string STRIPE_PUBLISHABLE_KEY = "pk_test_YOUR_OWN_PUBLISHABLE_KEY";
		public const bool STRIPE_ISTEST = true;
        public const string APPLE_MERCHANT_ID = "merchant.com.{your_app_name}"; // "REPLACE this with your Apple Merchant ID";


		// class-level declarations
		UIWindow window;
		MainViewController mainViewController;
		UINavigationController navController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			StripeClient.DefaultPublishableKey = STRIPE_PUBLISHABLE_KEY;

			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			mainViewController = new MainViewController ();
			navController = new UINavigationController (mainViewController);

			window.RootViewController = navController;

			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

