using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class CartOfferCell : ViewCell
	{
		public CartOfferCell()
		{
			InitializeComponent();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var price = this.priceLabel.Text;
			Debug.WriteLine(price);

		}
	}
}
