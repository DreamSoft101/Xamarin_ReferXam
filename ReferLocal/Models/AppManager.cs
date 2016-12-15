using System;
namespace ReferLocal
{
	public class AppManager: Object
	{
		static AppManager sharedManager = null;

		public string tokenString = "5817bb0a1ffea0f08a05f8af6101dde92f512544";
		public string cartId { get; set;}
		public Boolean loggedAsGuest { get; set; }
		public AppManager()
		{
			
		}

		public static AppManager sharedInstance()
		{
			if (sharedManager == null)
			{
				sharedManager = new AppManager();
			}

			return sharedManager;
		}
	}
}
