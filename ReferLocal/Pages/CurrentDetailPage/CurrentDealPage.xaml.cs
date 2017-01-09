using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class CurrentDealPage : ContentPage
	{

		List<Offer> offerArray = new List<Offer>();

		Offer selectedOffer = null;

		int selectedIndex = 0;
		bool isFirstLoading = true;
		public CurrentDealPage()
		{
			InitializeComponent();

			Initialize();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (isFirstLoading)
			{
				isFirstLoading = !isFirstLoading;
				LoadOffers();
			}


		}

		public void Initialize()
		{
			offerListView.HasUnevenRows = true;
			offerListView.SeparatorVisibility = SeparatorVisibility.None;
			offerListView.ItemSelected += (sender, e) =>
			{

				selectedIndex = (offerListView.ItemsSource as List<Offer>).IndexOf(e.SelectedItem as Offer);
				Debug.WriteLine(@"Selected Row  is  {0}", selectedIndex);
			};
		}

		//Button Action
		public async void OnAddCartBtnTapped()
		{
			selectedOffer = offerArray[selectedIndex];
			MyProgressModel.Show("Adding..");

			var result = await APIManager.sharedInstance().AddOfferToCart(selectedOffer.id, "1");
			MyProgressModel.Hide();

			Debug.WriteLine(result);

			if (result is Boolean)
			{
				if (!(Boolean)result)
				{
					await DisplayAlert("Error", "Faild!", "OK");
				}
				else {

					await DisplayAlert("Success", "Offer was added successfully.", "OK");
				}
			}

		}

		//
		private async void LoadOffers()
		{
			MyProgressModel.Show("Loading..");

			var result = await APIManager.sharedInstance().GetOffers();

			MyProgressModel.Hide();
			if (!(result is List<Offer>))
			{
				return;
			}

			offerArray = (List<Offer>)result;
			offerListView.ItemsSource = offerArray;
		}
	}
}
