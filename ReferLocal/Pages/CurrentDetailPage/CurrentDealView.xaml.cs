using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class CurrentDealView : BaseContentView
	{

		List<Offer> offerArray = new List<Offer>();

		Offer selectedOffer = null;

		int selectedIndex = 0;

		public CurrentDealView(BaseElementInterface p) : base(p) 
		{
			InitializeComponent();
			Initialize();
		}

		public override object LeftBarButton()
		{
			return null;
		}

		public override bool OnLeftBarButton_Clicked()
		{
			return false;
		}

		public void Initialize()
		{
			offerListView.HasUnevenRows = true;
			offerListView.SeparatorVisibility = SeparatorVisibility.None;
			offerListView.ItemSelected += (sender, e) => {

				selectedIndex = (offerListView.ItemsSource as List<Offer>).IndexOf(e.SelectedItem as Offer);
				Debug.WriteLine(@"Selected Row  is  {0}", selectedIndex);
			};
			addCartBtn.Clicked += OnAddCartBtnTapped;
			LoadOffers();
		}

		//Button Action
		public async void  OnAddCartBtnTapped(object sender, EventArgs e)
		{
			selectedOffer = offerArray[selectedIndex];

			var result = await APIManager.sharedInstance().AddOfferToCart(selectedOffer.id, "1");

			Debug.WriteLine(result);
		}

		//
		private async void LoadOffers()
		{
			var result = await APIManager.sharedInstance().GetOffers();

			if (!(result is List<Offer>))
			{
				return;
			}

			offerArray = (List<Offer>)result;

			offerListView.ItemsSource = offerArray;


		}
	}
}
