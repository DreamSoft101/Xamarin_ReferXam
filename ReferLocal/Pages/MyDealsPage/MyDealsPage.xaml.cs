using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class MyDealsPage : ContentPage
	{

		//ObservableCollection<Deal> dealArray = new ObservableCollection<Deal>();
		List<Order> deals = new List<Order>();
		int selectedIndex;
		Order selectedOrder;

		bool isFirstLoading = true;

		public MyDealsPage()
		{
			InitializeComponent();
			InitializeListview();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (isFirstLoading)
			{
				isFirstLoading = !isFirstLoading;
				LoadMyDeal();
			}
		}

		public void InitializeListview()
		{
			dealListView.HasUnevenRows = true;
			dealListView.SeparatorVisibility = SeparatorVisibility.None;

			dealListView.ItemSelected += (sender, e) =>
			{

				selectedIndex = (dealListView.ItemsSource as List<Order>).IndexOf(e.SelectedItem as Order);
				Debug.WriteLine(@"Selected Row  is  {0}", selectedIndex);

				selectedOrder = e.SelectedItem as Order;

				if (selectedOrder != null) 
				{
					ShowBarcodeWebPage();
				}
			};
		
		}

		public async void LoadMyDeal()
		{ 
			MyProgressModel.Show("Loading..");

			var result = await APIManager.sharedInstance().GetOrderByToken();
			MyProgressModel.Hide();

			if (!(result is List<Order>))
			{
				return ;
			}

			deals = (List<Order>)result;

			dealListView.ItemsSource = deals;
		}

		private async void ShowBarcodeWebPage()
		{
			await Navigation.PushAsync(new DealWebPage(selectedOrder.vouchers[0].code), true);

		}
	}
}
