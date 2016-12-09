using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class AccountPage : ContentPage
	{

		bool isEmailChecked = false;
		bool isMessageChecked = false;
		bool isCallChecked = false;
		bool isMailChecked = false;

		public User currentUser = null;

		public AccountPage()
		{
			InitializeComponent();
			Initialize();
		}

		public void Initialize()
		{
			emailCheckBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(OnEmailCheckButtonTapped)
				}
			); 

			messageCheckBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(OnMessageCheckButtonTapped)
				}
			);

			callCheckBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(OnCallCheckButtonTapped)
				}
			);

			mailCheckBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(OnMailCheckButtonTapped)
				}
			);

			logoutBtn.GestureRecognizers.Add(

				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(OnLogoutButtonTapped)
				}
			);

			GetAccountInfo();

		}

		// Get Account Info

		async void  GetAccountInfo()
		{
			var result = await APIManager.sharedInstance().GetAccount();

			if (!(result is User))
			{
				return;
			}

			currentUser = (User)result;

			nameLabel.Text = currentUser.displayName;

		}

		// button Actions

		public void OnEmailCheckButtonTapped()
		{
			isEmailChecked = !isEmailChecked;

			if (isEmailChecked == true)
			{
				emailCheckBtn.Source = "preferences_box_filled.png";
			}
			else {

				emailCheckBtn.Source = "preferences_box.png";
			}
		}

		public void OnMessageCheckButtonTapped()
		{
			isMessageChecked = !isMessageChecked;

			if (isMessageChecked == true)
			{
				messageCheckBtn.Source = "preferences_box_filled.png";
			}
			else {

				messageCheckBtn.Source = "preferences_box.png";
			}
		}

		public void OnCallCheckButtonTapped()
		{
			isCallChecked = !isCallChecked;

			if (isCallChecked == true)
			{
				callCheckBtn.Source = "preferences_box_filled.png";
			}
			else {

				callCheckBtn.Source = "preferences_box.png";
			}
		}

		public void OnMailCheckButtonTapped()
		{
			isMailChecked = !isMailChecked;

			if (isMailChecked == true)
			{
				mailCheckBtn.Source = "preferences_box_filled.png";
			}
			else {

				mailCheckBtn.Source = "preferences_box.png";
			}
		}

		public void OnLogoutButtonTapped()
		{
			App.GoToLoginpage();
		}
	}
}
