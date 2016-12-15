using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;


namespace ReferLocal
{
	public partial class App : Application
	{

		static Application app;

		public static Application CurrentApp
		{
			get { return app;}
		}

		public App()
		{
			InitializeComponent();

			app = this;

			GoToLoginpage();
			//GoToHome();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public static void GoToLoginpage()
		{ 
			app.MainPage = new NavigationPage(new LoginPage());
		}

		public static void GoToHome()
		{
			//CurrentApp.MainPage = new HomePage(1);
			CurrentApp.MainPage = new NavigationPage(new RootTabPage());
		}

		static async Task ShowNetworkConnectionAlert()
		{
			await CurrentApp.MainPage.DisplayAlert(

				"Title",
				"Message",
				"Cancel"
			);
		}
	}
}
