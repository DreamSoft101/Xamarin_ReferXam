using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ReferLocal
{
	public partial class HomePage : BaseContentPage
	{

		Button currentDealBtn;
		Button myCartBtn;
		Button myDealBtn;
		Button accountBtn;

		public HomePage()
		{
			InitializeComponent();
		}

		public HomePage(int pageIndex) : this()
		{
			InitTabItems();

			LoadContentView(pageIndex);

		}

		// Initialize Tab Bar items

		private void InitTabItems()
		{
			currentDealBtn = new Button
			{
				Image = "deal_icon_fill.png",
			};

			myCartBtn = new Button
			{
				Image = "cart_icon_empty.png"
			};

			myDealBtn = new Button
			{
				Image = "my_deals_icon_empty.png"
			};

			accountBtn = new Button
			{
				Image = "account_icon_empty.png"
			};

			currentDealBtn.Clicked += OnCurrentDealButtonClicked;
			myCartBtn.Clicked += OnMyCartButtonClicked;
			myDealBtn.Clicked += OnMyDealButtonClicked;
			accountBtn.Clicked += OnAccountButtonClicked;

			var tabBarGrid = new Grid()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,

				ColumnDefinitions = {

					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star) }
				}
			};

			tabBarGrid.WidthRequest = Width;
			tabBarGrid.Children.Add(currentDealBtn, 0, 0);
			tabBarGrid.Children.Add(myCartBtn, 1, 0);
			tabBarGrid.Children.Add(myDealBtn, 2, 0);
			tabBarGrid.Children.Add(accountBtn, 3, 0);

			TabBarLayout.Children.Add(tabBarGrid);
		}

		private void LoadContentView(int index)
		{
			ContentViewLayout.Children.Clear();

			switch (index)
			{
				case 1:

					CurrentDealView currentDealView = new CurrentDealView(this);

					activeChild = currentDealView;
					activeChildIndex = 1;
					OnChildViewSelectionChanged();
					ContentViewLayout.Children.Add(currentDealView);

					break;
				case 2:
					MyCartView myCartView = new MyCartView(this);

					activeChild = myCartView;
					activeChildIndex = 1;
					OnChildViewSelectionChanged();
					ContentViewLayout.Children.Add(myCartView);
					break;
				case 3:
					MyDealsView myDealsView = new MyDealsView(this);

					activeChild = myDealsView;
					activeChildIndex = 1;
					OnChildViewSelectionChanged();
					ContentViewLayout.Children.Add(myDealsView);
					break;
				case 4:
					AccountView accountView = new AccountView(this);

					activeChild = accountView;
					activeChildIndex = 1;
					OnChildViewSelectionChanged();
					ContentViewLayout.Children.Add(accountView);
					break;
				default:
					CurrentDealView currentDealView5 = new CurrentDealView(this);

					activeChild = currentDealView5;
					activeChildIndex = 1;
					OnChildViewSelectionChanged();
					ContentViewLayout.Children.Add(currentDealView5);
					break;	
			}

			UpdateTabItem(index);
		}

		// Change image when the tab bar is selected

		private void UpdateTabItem(int index)
		{
			currentDealBtn.Image = "deal_icon_empty.png";
			myCartBtn.Image = "cart_icon_empty.png";
			myDealBtn.Image = "my_deals_icon_empty.png";
			accountBtn.Image = "account_icon_empty.png";

			switch (index)
			{
				case 1:
					currentDealBtn.Image = "deal_icon_fill.png";
					break;
				case 2:
					myCartBtn.Image = "cart_icon_fill.png";

					break;
				case 3:
					myDealBtn.Image = "my_deals_icon_fill.png";
					break;
				case 4:
					accountBtn.Image = "account_icon_fill.png";

					break;
				default:
					
					break;
			}

		}

		// button Actions

		public void OnCurrentDealButtonClicked(object sender, EventArgs e)
		{
			LoadContentView(1);

		}

		public void OnMyCartButtonClicked(object sender, EventArgs e)
		{
			LoadContentView(2);

		}

		public void OnMyDealButtonClicked(object sender, EventArgs e)
		{
			LoadContentView(3);
		}

		public void OnAccountButtonClicked(object sender, EventArgs e)
		{
			LoadContentView(4);
		}

		//

		public override void OnContentViewSelectionChanged()
		{
			Object leftBarButton = GetLeftBarButton();

			if (leftBarButton != null)
			{
				Button leftBtn = (Button)leftBarButton;


			}
		}
	}
}
