using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class MyDealsPage : ContentPage
	{

		ObservableCollection<Deal> dealArray = new ObservableCollection<Deal>();


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
			dealListView.ItemsSource = dealArray;

			dealArray.Add(new Deal());
			dealArray.Add(new Deal());
		}

		public async void LoadMyDeal()
		{ 
			MyProgressModel.Show("Loading..");

			var result = await APIManager.sharedInstance().GetMyDeal();
			MyProgressModel.Hide();

		}
	}
}
