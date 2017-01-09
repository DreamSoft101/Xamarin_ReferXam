using System;
using System.Collections.Generic;
using System.Diagnostics; 
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class StripePaymentPage : ContentPage
	{
		public StripePaymentPage()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);

			BuyButton.Clicked += OnBuyButtonTapped;

			BackBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(OnBackBtnClicked)
				}
			);

		}

		async void OnBuyButtonTapped(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(emailTxtField.Text) || string.IsNullOrEmpty(nameTxtField.Text))
			{
				return;
			}

			await Navigation.PushAsync(new StripeCardInputPage(), true);

		}

		async void OnBackBtnClicked()
		{
			await Navigation.PopAsync();
		}
	}
}
