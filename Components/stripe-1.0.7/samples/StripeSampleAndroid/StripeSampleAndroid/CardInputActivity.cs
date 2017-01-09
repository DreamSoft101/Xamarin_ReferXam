using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Stripe;

namespace StripeSampleAndroid
{
	[Activity (Label = "Pay with Card", Theme = "@android:style/Theme.Holo.Light")]
	public class CardInputActivity : Activity
	{
		StripeView stripeView;
		EditText name;
		EditText address1;
		EditText address2;
		EditText city;
		EditText state;
		EditText zip;
		EditText country;
		Button buttonToken;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Stripe.StripeClient.DefaultPublishableKey = MainActivity.STRIPE_PUBLISHABLE_KEY;

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.CardInput);

			stripeView = FindViewById<Stripe.StripeView> (Resource.Id.stripeView);
			name = FindViewById<EditText> (Resource.Id.name);
			address1 = FindViewById<EditText> (Resource.Id.address1);
			address2 = FindViewById<EditText> (Resource.Id.address2);
			city = FindViewById<EditText> (Resource.Id.city);
			state = FindViewById<EditText> (Resource.Id.state);
			zip = FindViewById<EditText> (Resource.Id.zip);
			country = FindViewById<EditText> (Resource.Id.country);
			buttonToken = FindViewById<Button> (Resource.Id.buttonToken);

			buttonToken.Click += async delegate {
				var c = stripeView.Card;

				if (!c.IsCardValid) {
					var errorMsg = "Invalid Card Information";

					if (!c.IsNumberValid)
						errorMsg = "Invalid Card Number";
					else if (!c.IsValidExpiryDate)
						errorMsg = "Invalid Card Expiry Date";
					else if (!c.IsValidCvc)
						errorMsg = "Invalid CVC";

					Toast.MakeText(this, errorMsg, ToastLength.Short).Show();
				} else {
					c.Name = name.Text;
					c.AddressLine1 = address1.Text;
					c.AddressLine2 = address2.Text;
					c.AddressCity = city.Text;
					c.AddressState = state.Text;
					c.AddressZip = zip.Text;
					c.AddressCountry = country.Text;

					try {
						var token = await StripeClient.CreateToken (c, MainActivity.STRIPE_PUBLISHABLE_KEY);

						if (token != null) {

							//TODO: Send token to your server to process a payment with

							var msg = string.Format ("Good news! Stripe turned your credit card into a token: \n{0} \n\nYou can follow the instructions in the README to set up Parse as an example backend, or use this token to manually create charges at dashboard.stripe.com .", 
								token.Id);

							Toast.MakeText(this, msg, ToastLength.Long).Show();
						} else {
							Toast.MakeText(this, "Failed to create Token", ToastLength.Short).Show();
						}
					} catch (Exception ex) {
						Toast.MakeText (this, "Failure: " + ex.Message, ToastLength.Short).Show ();
					}
				}
			};
		}
	}
}


