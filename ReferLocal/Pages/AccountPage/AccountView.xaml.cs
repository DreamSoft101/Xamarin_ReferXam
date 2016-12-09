using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class AccountView : BaseContentView
	{

		bool isEmailChecked 	= false;
		bool isMessageChecked 	= false;
		bool isCallChecked 		= false;
		bool isMailChecked 		= false;

		public AccountView(BaseElementInterface p) : base(p)
		{
			InitializeComponent();
			Intialize();
		}

		public override object LeftBarButton()
		{
			return null;
		}

		public override bool OnLeftBarButton_Clicked()
		{
			return false;
		}

		public void Intialize()
		{
			emailCheckBtn.Clicked 	+= OnEmailCheckButtonTapped;
			messageCheckBtn.Clicked += OnMessageCheckButtonTapped;
			callCheckBtn.Clicked 	+= OnCallCheckButtonTapped;
			mailCheckBtn.Clicked 	+= OnMailCheckButtonTapped;
			logoutBtn.Clicked 		+= OnLogoutButtonTapped;
		}

		// button Actions

		public void OnEmailCheckButtonTapped(object sender, EventArgs e)
		{
			isEmailChecked = !isEmailChecked;

			if (isEmailChecked == true)
			{
				emailCheckBtn.Image = "preferences_box_filled.png";
			}
			else {

				emailCheckBtn.Image = "preferences_box.png";
			}
		}

		public void OnMessageCheckButtonTapped(object sender, EventArgs e)
		{
			isMessageChecked = !isMessageChecked;

			if (isMessageChecked == true)
			{
				messageCheckBtn.Image = "preferences_box_filled.png";
			}
			else {

				messageCheckBtn.Image = "preferences_box.png";
			}
		}

		public void OnCallCheckButtonTapped(object sender, EventArgs e)
		{
			isCallChecked = !isCallChecked;

			if (isCallChecked == true)
			{
				callCheckBtn.Image = "preferences_box_filled.png";
			}
			else {

				callCheckBtn.Image = "preferences_box.png";
			}
		}

		public void OnMailCheckButtonTapped(object sender, EventArgs e)
		{
			isMailChecked = !isMailChecked;

			if (isMailChecked == true)
			{
				mailCheckBtn.Image = "preferences_box_filled.png";
			}
			else {

				mailCheckBtn.Image = "preferences_box.png";
			}
		}

		public void OnLogoutButtonTapped(object sender, EventArgs e)
		{

		}
	}
}
