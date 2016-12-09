using System;


using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;


namespace ReferLocal
{
	public class RootPage : MasterDetailPage
	{

		Dictionary<MenuType, NavigationPage> Pages { get; set;}

		public RootPage()
		{
			Pages = new Dictionary<MenuType, NavigationPage>();
			Master = new MenuPage(this);
			BindingContext = new BaseViewModel(Navigation)
			{
				Title = "",
				Icon = ""
			};

			// Setup Home Page
			NavigateAsync(MenuType.CurrentDeals);
		}

		void SetDetailIfNull(Page page)
		{
			if (Detail == null && page != null)
			{
				Detail = page;
			}
		}

		public async Task NavigateAsync(MenuType id)
		{
			Page newPage;

			if (!Pages.ContainsKey(id))
			{
				switch (id)
				{
					case MenuType.CurrentDeals:
						var page = new RLNavigationPage(new CurrentDealPage
						{
							Title = "CURRENT DEALS",
							Icon = new FileImageSource { File = "deal_icon_empty.png" }
						});
						SetDetailIfNull(page);
						Pages.Add(id, page);
						break;
					case MenuType.MyCart:
						page = new RLNavigationPage(new MyCartPage
						{
							Title = "",
							Icon = new FileImageSource { File = "cart_icon_empty.png"}
						});
						Pages.Add(id, page);
						break;
					case MenuType.MyDeals:
						page = new RLNavigationPage(new MyDealsPage
						{
							Title = "",
							Icon = new FileImageSource { File = "my_deals_icon_empty.png"}
						});
						Pages.Add(id, page);
						break;
					case MenuType.Account:
						page = new RLNavigationPage(new AccountPage
						{
							Title = "",
							Icon = new FileImageSource { File = "account_icon_empty.png"}
						});
						Pages.Add(id, page);
						break;
				}
			}

			newPage = Pages[id];

			if (newPage == null) 
				return;

			Detail = newPage;
		}
	}

	public class RootTabPage : TabbedPage
	{
		public RootTabPage()
		{
			Children.Add(new RLNavigationPage(new CurrentDealPage
			{
				Title = "REFERLOCAL",
				Icon = new FileImageSource { File = "deal_icon_empty.png" }
			})
			{
				Title = "CURRENT DEALS",
				Icon = new FileImageSource { File = "deal_icon_empty.png" }
			});

			Children.Add(new RLNavigationPage(new MyCartPage
			{
				Title = "MY CART",
				Icon = new FileImageSource { File = "cart_icon_empty.png" }
			})
			{
				Title = "MY CART",
				Icon = new FileImageSource { File = "cart_icon_empty.png" }
			});

			Children.Add(new RLNavigationPage(new MyDealsPage
			{
				Title = "MY DEALS",
				Icon = new FileImageSource { File = "my_deals_icon_empty.png" }
			})
			{
				Title = "MY DEALS",
				Icon = new FileImageSource { File = "my_deals_icon_empty.png" }
			});

			Children.Add(new RLNavigationPage(new AccountPage
			{
				Title = "MY ACCOUNT",
				Icon = new FileImageSource { File = "account_icon_empty.png" }
			})
			{
				Title = "ACCOUNT",
				Icon = new FileImageSource { File = "account_icon_empty.png" }
			});
		}
		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();
			this.Title = this.CurrentPage.Title;
		}
	}

	public class RLNavigationPage : NavigationPage
	{
		public RLNavigationPage(Page root)
			: base(root)
		{
			Init();
		}

		public RLNavigationPage()
		{
			Init();
		}

		void Init()
		{
			BarTextColor = Color.White;
		}
	}

	public enum MenuType
	{
		CurrentDeals,
		MyCart,
		MyDeals,
		Account
	}

	public class HomeMenuItem
	{
		public HomeMenuItem()
		{
			MenuType = MenuType.CurrentDeals;
		}

		public string Icon { get; set;}
		public MenuType MenuType { get; set; }
		public string Title { get; set;}
		public string Details { get; set;}
		public int Id { get; set;}
	}
}

