using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class CheckOutPage : ContentPage
	{

		public List<Offer> offerArrInCart;

		float totalPrice = 0;

		public CheckOutPage(List<Offer> _offerArrInCart)
		{
			InitializeComponent();
			Title = "CHECKOUT";
			offerArrInCart = _offerArrInCart;

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

			UpdateComponent();
		}

		public CheckOutPage()
		{
			InitializeComponent();


		}

		public void UpdateComponent()
		{

			foreach (Offer offer in offerArrInCart)
			{

				totalPrice = totalPrice + float.Parse(offer.price);

			}

			SubTotalPriceLabel.Text = totalPrice.ToString("C");
			TotalPriceLabel.Text = totalPrice.ToString("C");
		}

		private async void CheckOutBtn_Clicked()
		{

			//var amount = totalPrice.ToString();
			//var couponCode = CouponCodeField.Text;

			//var result = await APIManager.sharedInstance().Checkout("stripeToken", amount,  couponCode, "cartId", "email");

			//await Navigation.PushAsync(new CreditCardInputPage());
			await Navigation.PushModalAsync(new CreditCardInputPage());
		}

		private void ShopBtn_Clicked()
		{
			App.GoToHome();
		}


	}
}
