using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class CreditCardInputPage : ContentPage
	{
		public CreditCardInputPage()
		{
			InitializeComponent();

			BackBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(OnBackBtnClicked)
				}
			);		
		}

		async void OnBackBtnClicked()
		{
			await Navigation.PopModalAsync();
		}


	}
}
