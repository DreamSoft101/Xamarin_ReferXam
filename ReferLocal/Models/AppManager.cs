using System;
using Xamarin.Forms;
using ZXing;


namespace ReferLocal
{
	public class AppManager: Object
	{
		static AppManager sharedManager = null;

		public string tokenString = "5817bb0a1ffea0f08a05f8af6101dde92f512544";
		public string stripeToken = "";
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

		public static byte[] GetBarcodeImage(string codeNumber)
		{
			var content = codeNumber;
			var writer = new BarcodeWriter
			{
				Format = BarcodeFormat.CODE_128
			};

			var bitmap = writer.Write(content);

			return bitmap;
		}
	}
}
