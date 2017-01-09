using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class DealWebPage : ContentPage
	{

		Uri barcodeUri;
		private string barCode;
		public DealWebPage()
		{
			InitializeComponent();
		}

		public DealWebPage(string barCodeId)
		{
			InitializeComponent();

			barCode = barCodeId;
			barcodeUri = new Uri(string.Format(Constants.API_BARCODELINK + barCodeId));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (barcodeUri != null)
			{

				Debug.WriteLine(string.Format(Constants.API_BARCODELINK + barCode));
				BarcodeShowWebView.Source = string.Format(Constants.API_BARCODELINK + barCode);
				//BarcodeShowWebView.Source = new UrlWebViewSource { 

				//	Url = string.Format(Constants.API_BARCODELINK + barCode)
				//};
				
			}
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();


		}
	}
}
