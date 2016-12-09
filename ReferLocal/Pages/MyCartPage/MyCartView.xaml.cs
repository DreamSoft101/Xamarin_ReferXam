using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;


namespace ReferLocal
{
	public partial class MyCartView : BaseContentView
	{
		
		List<Cart> cartArray = new List<Cart>();

		Cart selectedCart = null;

		int selectedIndex = 0;

		public MyCartView(BaseElementInterface p) : base(p)
		{
			InitializeComponent();

			Initialize();
		}

		public void Initialize()
		{
			cartListView.HasUnevenRows = true;
			cartListView.SeparatorVisibility = SeparatorVisibility.None;
			cartListView.ItemSelected += (sender, e) =>
			{
				selectedIndex = (cartListView.ItemsSource as List<Cart>).IndexOf(e.SelectedItem as Cart);
				Debug.WriteLine(@"Selected Row  is  {0}", selectedIndex);
			};
			cartListView.ItemsSource = cartArray;

			cartArray.Add(new Cart());
			cartArray.Add(new Cart());
			//
			checkOutBtn.Clicked += CheckOutBtn_Clicked;

			//LoadMyCarts();

		}

		public override object LeftBarButton()
		{
			return null;
		}

		public override bool OnLeftBarButton_Clicked()
		{
			return false;
		}

		//Load My Carts 

		public async void LoadMyCarts()
		{
			var result = await APIManager.sharedInstance().GetCart();

			if (!(result is List<Cart>))
			{
				return;
			}

			cartArray = (List<Cart>)result;

			Debug.WriteLine(@" Carts are {0}", cartArray.Count);


		}

		async void  CheckOutBtn_Clicked(object sender, EventArgs e)
		{
			var result = await APIManager.sharedInstance().Checkout("stripeToken", "1", "couponCode", "cartId", "email");

			if (result is Boolean)
			{

				Debug.WriteLine("Checkout succeed.");
			}
			else {

				await App.Current.MainPage.DisplayAlert("Error", "Request Failed.", "OK");
			}
		}

		public async void RemoveCart()
		{
			
		}
	}
}
