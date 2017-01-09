using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class DealCell : ViewCell
	{
		public DealCell()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			Debug.WriteLine(this.BindingContext);
			var offer = (Offer)this.BindingContext;
		
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			Debug.WriteLine(this.BindingContext);

		}
	}
}
