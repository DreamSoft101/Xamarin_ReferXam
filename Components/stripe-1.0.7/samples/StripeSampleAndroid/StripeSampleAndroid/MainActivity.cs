
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Wallet.Fragment;
using Android.Gms.Wallet;
using Android.Gms.Common;
using Android.Gms.Common.Apis;

namespace StripeSampleAndroid
{
    [Activity (Label = "Stripe Sample", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light")]
    public class MainActivity : Android.Support.V4.App.FragmentActivity, IGoogleApiClientConnectionCallbacks, IGoogleApiClientOnConnectionFailedListener
    {
        const int LOAD_MASKED_WALLET_REQ_CODE = 1000;
        const int LOAD_FULL_WALLET_REQ_CODE = 2000;

        public const string STRIPE_PUBLISHABLE_KEY = "YOUR-STRIPE-PUBLISHABLE-KEY ";

        IGoogleApiClient googleApiClient;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Create your application here
            SetContentView (Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.buttonCard).Click += delegate {
                StartActivity (typeof (CardInputActivity));
            };

            var b = new WalletClass.WalletOptions.Builder ()
                .SetEnvironment (WalletConstants.EnvironmentSandbox)
                .SetTheme (WalletConstants.ThemeLight)
                .Build ();
            
            googleApiClient = new GoogleApiClientBuilder (this)
                .AddConnectionCallbacks (this)
                .AddOnConnectionFailedListener (this)
                .AddApi (WalletClass.API, b)
                .Build ();


            var walletFragment = SupportWalletFragment.NewInstance (WalletFragmentOptions.NewBuilder ()
                .SetEnvironment (WalletConstants.EnvironmentSandbox)
                .SetMode (WalletFragmentMode.BuyButton)
                .SetTheme (WalletConstants.ThemeLight)
                .SetFragmentStyle (new WalletFragmentStyle ()
                    .SetBuyButtonText (BuyButtonText.BuyWithGoogle)
                    .SetBuyButtonAppearance (BuyButtonAppearance.Classic)
                    .SetBuyButtonWidth (Dimension.MatchParent))
                .Build ());
            
            var maskedWalletRequest = MaskedWalletRequest.NewBuilder ()

                // Request credit card tokenization with Stripe by specifying tokenization parameters:
                .SetPaymentMethodTokenizationParameters (PaymentMethodTokenizationParameters.NewBuilder ()
                    .SetPaymentMethodTokenizationType (PaymentMethodTokenizationType.PaymentGateway)
                    .AddParameter ("gateway", "stripe")
                    .AddParameter ("stripe:publishableKey", STRIPE_PUBLISHABLE_KEY)
                    .AddParameter ("stripe:version", "1.15.1")
                    .Build ())

                // You want the shipping address:
                .SetShippingAddressRequired (true)

                .SetMerchantName ("Llamanators")
                .SetPhoneNumberRequired (true)
                .SetShippingAddressRequired (true)

                // Price set as a decimal:
                .SetEstimatedTotalPrice ("20.00")
                .SetCurrencyCode ("USD")

                .Build();

            // Set the parameters:  
            var initParams = WalletFragmentInitParams.NewBuilder ()
                .SetMaskedWalletRequest (maskedWalletRequest)
                .SetMaskedWalletRequestCode (LOAD_MASKED_WALLET_REQ_CODE)
                .Build ();
                           
            // Initialize the fragment:
            walletFragment.Initialize (initParams);

            SupportFragmentManager.BeginTransaction ().Replace (Resource.Id.frameFragment, walletFragment).Commit ();
        }

        protected override void OnStart ()
        {
            base.OnStart ();
            googleApiClient.Connect ();
        }

        protected override void OnStop ()
        {
            googleApiClient.Disconnect ();
            base.OnStop ();
        }

        protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
        {            
            if (requestCode == LOAD_MASKED_WALLET_REQ_CODE) { // Unique, identifying constant
                if (resultCode == Result.Ok) {

                    var maskedWallet = data.GetParcelableExtra (WalletConstants.ExtraMaskedWallet).JavaCast<MaskedWallet> ();

                    var fullWalletRequest = FullWalletRequest.NewBuilder ()
                        .SetCart (Cart.NewBuilder ()
                            .SetCurrencyCode ("USD")
                            .SetTotalPrice ("20.00")
                            .AddLineItem (LineItem.NewBuilder () // Identify item being purchased
                                .SetCurrencyCode ("USD")
                                .SetQuantity ("1")
                                .SetDescription ("Premium Llama Food")
                                .SetTotalPrice ("20.00")
                                .SetUnitPrice ("20.00")
                                .Build ())
                            .Build ())
                        .SetGoogleTransactionId (maskedWallet.GoogleTransactionId)
                        .Build ();
                    
                    WalletClass.Payments.LoadFullWallet (googleApiClient, fullWalletRequest, LOAD_FULL_WALLET_REQ_CODE);

                } else {
                    base.OnActivityResult (requestCode, resultCode, data);
                }
            } else if (requestCode == LOAD_FULL_WALLET_REQ_CODE) { // Unique, identifying constant
                    
                if (resultCode == Result.Ok) {
                    var fullWallet = data.GetParcelableExtra (WalletConstants.ExtraFullWallet).JavaCast<FullWallet> ();
                    var tokenJson = fullWallet.PaymentMethodToken.Token;

                    var stripeToken = Stripe.Token.FromJson (tokenJson);

                    var msg = string.Empty;

                    if (stripeToken != null) {

                        //TODO: Send token to your server to process a payment with

                        msg = string.Format ("Good news! Stripe turned your credit card into a token: \n{0} \n\nYou can follow the instructions in the README to set up Parse as an example backend, or use this token to manually create charges at dashboard.stripe.com .", 
                            stripeToken.Id);
                        
                    } else {
                        msg = "Failed to create Token";
                    }

                    new AlertDialog.Builder (this)
                        .SetTitle ("Stripe Response")
                        .SetMessage (msg)
                        .SetCancelable (true)
                        .SetNegativeButton ("OK", delegate { })
                        .Show ();                    
                }

            } else {
                base.OnActivityResult (requestCode, resultCode, data);
            }
        }

        public void OnConnectionFailed (ConnectionResult result)
        {
            Toast.MakeText (this, "Failed to connect to Google Play Services", ToastLength.Long).Show ();
        }

        public void OnConnected (Bundle connectionHint)
        {
            
        }

        public void OnConnectionSuspended (int cause)
        {
            
        }
    }
}

