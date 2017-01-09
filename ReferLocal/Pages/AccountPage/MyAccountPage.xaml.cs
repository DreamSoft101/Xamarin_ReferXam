using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class MyAccountPage : ContentPage
	{
		public MyAccountPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			AccountWebView.Source = Constants.API_ACCOUNT_SETTING + AppManager.sharedInstance().tokenString;
		}
	}
}
