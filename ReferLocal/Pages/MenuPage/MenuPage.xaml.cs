using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class MenuPage : ContentPage
	{
		RootPage root;
		List<HomeMenuItem> menuItems;
		public MenuPage(RootPage root)
		{
			this.root = root;
			InitializeComponent();

			BindingContext = new BaseViewModel(Navigation)
			{
				Title = "REFERLOCAL",
				Icon = "bg_login.png"
			};

			ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
			{
				new HomeMenuItem {Title = "CURRENT DEALS" , MenuType = MenuType.CurrentDeals, Icon = "deal-icon-fill.png"},
				new HomeMenuItem {Title = "MY CART" , MenuType = MenuType.MyCart, Icon = "cart-icon-empty.png"},
				new HomeMenuItem {Title = "MY DEALS" , MenuType = MenuType.MyDeals, Icon = "my-deals-icon-empty.png"},
				new HomeMenuItem {Title = "ACCOUNT" , MenuType = MenuType.Account, Icon = "account-icon-empty.png"}
			};

			ListViewMenu.SelectedItem = menuItems[0];

			ListViewMenu.ItemSelected += async (sender, e) =>
			{
				if (ListViewMenu.SelectedItem == null)
					return;

				await this.root.NavigateAsync(((HomeMenuItem)e.SelectedItem).MenuType);
			};



		}
	}
}
