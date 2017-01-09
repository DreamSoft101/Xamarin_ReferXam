using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Stripe;
using PassKit;
using UIKit;
using CoreGraphics;
using Foundation;
using ReferLocal;
using ReferLocal.iOS;

[assembly: ExportRenderer(typeof(ReferLocal.CreditCardInputPage), typeof(ReferLocal.iOS.CreditCardInputPageRenderer))]

namespace ReferLocal.iOS
{
	public class CreditCardInputPageRenderer: PageRenderer
	{

		StripeView stripeView;
		UIButton buttonPay;

		CreditCardInputPage inputPage;

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);



		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			View.BackgroundColor = UIColor.White;

			stripeView = new StripeView();
			stripeView.Frame = new CGRect(10, 250, stripeView.Frame.Width, stripeView.Frame.Height);

			buttonPay = new UIButton(UIButtonType.RoundedRect)
			{
				Frame = new CGRect(0, 300, View.Frame.Width, 50)
			};
			buttonPay.SetTitle("Pay Now", UIControlState.Normal);
			buttonPay.TouchUpInside += async delegate
			{

				Card card = null;

				try
				{
					card = stripeView.Card;
				}
				catch (Exception ex)
				{
					var av = new UIAlertView("Card Error", ex.Message, null, "OK");
					av.Show();
					return;
				}

				var msg = string.Empty;

				try
				{
					var token = await StripeClient.CreateToken(card);

					msg = string.Format("Good news! Stripe turned your credit card into a token: \n{0} \n\nYou can follow the instructions in the README to set up Parse as an example backend, or use this token to manually create charges at dashboard.stripe.com .",
						token.Id);

					AppManager.sharedInstance().stripeToken = token.Id;

				}
				catch (Exception ex)
				{
					msg = "Error: " + ex.Message;
				}

				var av2 = new UIAlertView("Token Result", msg, null, "OK");
				av2.Show();
			};

			View.AddSubview(stripeView);
			View.AddSubview(buttonPay);
		}
	}
}
