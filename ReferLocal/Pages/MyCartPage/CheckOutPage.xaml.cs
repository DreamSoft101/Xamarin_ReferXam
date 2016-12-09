using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class CheckOutPage : ContentPage
	{
		public CheckOutPage()
		{
			InitializeComponent();

			checkOutBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(CheckOutBtn_Clicked)
				}
			);

			shopBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(ShopBtn_Clicked)
				}
			);
		}

		private async void CheckOutBtn_Clicked()
		{

			var result = await APIManager.sharedInstance().Checkout("stripeToken", "amount", "couponCode", "cartId", "email");


		}

		private void ShopBtn_Clicked()
		{
			App.GoToHome();
		}


	}
}
