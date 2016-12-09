using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();

			BackBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(OnBackBtnClicked)
				}
			);

			NavigationPage.SetHasNavigationBar(this, false);

		}

		async void OnBackBtnClicked()
		{
			await Navigation.PopAsync();
		}
	}
}
