using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace ReferLocal
{
	public partial class MyCartPage : ContentPage
	{

		public IUserDialogs dialog { get;}
		List<Offer> myOffers = new List<Offer>();

		Cart selectedCart = null;
		bool isFirstLoading = true;
		int selectedIndex = 0;

		public MyCartPage()
		{
			InitializeComponent();

			#region wire up MessagingCenter

			MessagingCenter.Subscribe<MyCartPage>(this, "Success", sender => LoadMyCarts());

			#endregion

			Initialize();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (isFirstLoading)
			{
				isFirstLoading = !isFirstLoading;
				LoadMyCarts();
			}


		}

		public void Initialize()
		{
			cartListView.HasUnevenRows = true;
			cartListView.SeparatorVisibility = SeparatorVisibility.None;
			cartListView.ItemSelected += (sender, e) =>
			{
				selectedIndex = (cartListView.ItemsSource as List<Offer>).IndexOf(e.SelectedItem as Offer);
				Debug.WriteLine(@"Selected Row  is  {0}", selectedIndex);

				((ListView)sender).SelectedItem = null;
			};
			//
			checkOutBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(CheckOutBtn_Clicked)
				}
			);

		}

		//Load My Carts 

		public async void LoadMyCarts()
		{

			MyProgressModel.Show("Loading..");

			var result = await APIManager.sharedInstance().GetCart();
			MyProgressModel.Hide();

			if (!(result is Cart))
			{

				await DisplayAlert("Error", "Something is wrong!.", "OK");

				return;
			}

			var myCart = (Cart)result;

			selectedCart = myCart;

			AppManager.sharedInstance().cartId = selectedCart.id.ToString();

			Debug.WriteLine(@" Offers are {0}", myCart.contents.Count);

			foreach (Content content in myCart.contents) {

				myOffers.Add(content.offer);

			}
			DisplayValue();
			cartListView.ItemsSource = myOffers;
		}


		void DisplayValue()
		{
			float totalPrice = 0;

			foreach (Offer offer in myOffers)
			{

				totalPrice = totalPrice + float.Parse(offer.price);

			}

			priceLabel.Text = totalPrice.ToString("C");
		}

		//Button Actions

		async void CheckOutBtn_Clicked()
		{


			//var result = await APIManager.sharedInstance().Checkout("stripeToken", "1", "couponCode", "cartId", "email");

			//if (result is Boolean)
			//{

			//	Debug.WriteLine("Checkout succeed.");
			//}
			//else {

			//	await App.Current.MainPage.DisplayAlert("Error", "Request Failed.", "OK");
			//}

			await Navigation.PushAsync(new CheckOutPage(myOffers), true);
		}

	}
}
