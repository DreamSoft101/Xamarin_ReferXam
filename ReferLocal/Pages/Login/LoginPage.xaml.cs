using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();

			// Button Initialize



			//forgotBtn.GestureRecognizers.Add();
			//signUpBtn.GestureRecognizers.Add();
			//guestBtn.GestureRecognizers.Add(
			//	new TapGestureRecognizer()
			//	{
			//		NumberOfTapsRequired = 1,
			//		Command = new Command(GuestButtonTapped)
			//	});

			signInBtn.Clicked += OnSignInBtnClicked;
			signUpBtn.Clicked += OnSignUpBtnClicked;
			forgotBtn.Clicked += OnForgotBtnClicked;
			guestBtn.Clicked += OnGuestBtnClicked;

			NavigationPage.SetHasNavigationBar(this, false);


		}

		public  async void OnSignInBtnClicked( object sender, EventArgs e)
		{

			//App.GoToHome();

			//return;
			if (!string.IsNullOrEmpty(emailTxtField.Text) && !string.IsNullOrEmpty(passwordTxtField.Text))
			{
				MyProgressModel.Show("Signing..");
				var result = await APIManager.sharedInstance().SignInAsync(emailTxtField.Text, passwordTxtField.Text);

				MyProgressModel.Hide();

				App.GoToHome();
			}
			else {

				await DisplayAlert("Error", "Please enter your information.", "OK");
			}


		}

		public async void OnSignUpBtnClicked(object sender, EventArgs e)
		{

			var email = emailTxtField.Text;


			await Navigation.PushAsync(new RegisterPage());
		}

		public async void OnForgotBtnClicked(object sender, EventArgs e)
		{
			
		}

		public async void OnGuestBtnClicked(object sender, EventArgs e)
		{
			App.GoToHome();
		}
		private bool checkInputValue()
		{
			if (emailTxtField.Text == null || passwordTxtField.Text == null)
			{
				
			}
			return true;
		}

	}
}

