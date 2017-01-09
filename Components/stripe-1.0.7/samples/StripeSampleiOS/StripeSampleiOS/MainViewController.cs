using System;
using Stripe;
using System.Threading.Tasks;

using CoreGraphics;
using UIKit;
using PassKit;
using Foundation;

namespace StripeSampleiOS
{
    public class MainViewController : UIViewController, IStripeTestPaymentAuthorizationViewControllerDelegate, IPKPaymentAuthorizationViewControllerDelegate
	{
		public MainViewController () : base()
		{
		}

		CreditCardInputViewController ccViewController;

		UIButton buttonPay;
		UIButton buttonCcPay;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			buttonPay = new UIButton (UIButtonType.RoundedRect);
			buttonPay.Frame = new CGRect (0, 100, (float)View.Frame.Width, 40);
			buttonPay.SetTitle ("Create Pay Payment", UIControlState.Normal);
			buttonPay.TouchUpInside += (sender, e) => BeginPayment ();

			buttonCcPay = new UIButton (UIButtonType.RoundedRect);
			buttonCcPay.Frame = new CGRect (0, 160, (float)View.Frame.Width, 40);
			buttonCcPay.SetTitle ("Create Credit Card Payment", UIControlState.Normal);
			buttonCcPay.TouchUpInside += (sender, e) => {
				ccViewController = new CreditCardInputViewController ();
				NavigationController.PushViewController (ccViewController, true);
			};

			View.BackgroundColor = UIColor.White;
			View.AddSubview (buttonPay);
			View.AddSubview (buttonCcPay);
		}

		#region IStripeTestPaymentAuthorizationViewControllerDelegate implementation

        public async void DidAuthorizeTestPayment (StripeTestPaymentAuthorizationViewController controller, PKPayment payment, Action<PKPaymentAuthorizationStatus> completion, bool shouldTestFail)
		{
			await HandlePaymentAuthorization (payment, completion, true, shouldTestFail);
		}

		public void PaymentAuthorizationViewControllerDidFinish (StripeTestPaymentAuthorizationViewController controller)
		{
			this.DismissViewController (true, null);
		}

		#endregion

        public void WillAuthorizePayment (PKPaymentAuthorizationViewController controller)
        {
            
        }

        public async void DidAuthorizePayment (PKPaymentAuthorizationViewController controller, PKPayment payment, Action<PKPaymentAuthorizationStatus> completion)
		{
			await HandlePaymentAuthorization (payment, completion);
		}


        async Task HandlePaymentAuthorization (PKPayment payment, Action<PKPaymentAuthorizationStatus> completion, bool isTest = false, bool shouldTestFail = false)
		{
			try {

				Token token = null;

				if (isTest)
					token = await StripeClient.CreateTestToken (payment, shouldTestFail);
				else
					token = await StripeClient.CreateToken (payment);

				var msg = string.Format ("Good news! Stripe turned your credit card into a token: \n{0} \n\nYou can follow the instructions in the README to set up Parse as an example backend, or use this token to manually create charges at dashboard.stripe.com .", 
					token.Id);

				var avMsg = new UIAlertView ("Todo: Submit this token to your backend", msg, null, "OK");
				avMsg.Show ();

				completion (PKPaymentAuthorizationStatus.Success);

			} catch (Exception ex) {

				var avMsg = new UIAlertView ("Payment Failed", ex.Message, null, "OK");
				avMsg.Show ();
			}
		}

		public void PaymentAuthorizationViewControllerDidFinish (PKPaymentAuthorizationViewController controller)
		{
			this.DismissViewController (true, null);
		}
			
		void BeginPayment ()
		{
			var merchantId = AppDelegate.APPLE_MERCHANT_ID;
		
			var paymentRequest = StripeClient.PaymentRequest (merchantId, new NSDecimalNumber ("10"), "USD", "Premium Llama Food");

			// Check if we can use apple pay
			if (StripeClient.CanSubmitPaymentRequest (paymentRequest)) {

				UIViewController paymentController;

				if (AppDelegate.STRIPE_ISTEST)
					paymentController = StripeClient.TestPaymentController (paymentRequest, this);
				else
					paymentController = StripeClient.PaymentController (paymentRequest, this);

				PresentViewController (paymentController, true, null);

			} else {
				// TODO: Non-Apple flow
				var avMsg = new UIAlertView ("Todo: Apple Pay Not supported!", 
					"You need to use a traditional method of collecting credit card information instead!", null, "OK");
				avMsg.Show ();
			}
		}
	}
}

