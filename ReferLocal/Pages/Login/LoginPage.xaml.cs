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

			App.GoToHome();
			return;
			if (!string.IsNullOrEmpty(emailTxtField.Text) && !string.IsNullOrEmpty(passwordTxtField.Text))
			{
				MyProgressModel.Show("Signing..");
				var result = await APIManager.sharedInstance().SignInAsync(emailTxtField.Text, passwordTxtField.Text);

				MyProgressModel.Hide();

				if (result is LoginSuccessDataModel)
				{
					var successData = (LoginSuccessDataModel)result;

					AppManager.sharedInstance().tokenString = successData.token;
					App.GoToHome();

				}
				else {
					await DisplayAlert("Error", "Login failed. Try again later.", "OK");

				}

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

		public void OnForgotBtnClicked(object sender, EventArgs e)
		{
			
		}

		public  void OnGuestBtnClicked(object sender, EventArgs e)
		{

			AppManager.sharedInstance().loggedAsGuest = true;

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

