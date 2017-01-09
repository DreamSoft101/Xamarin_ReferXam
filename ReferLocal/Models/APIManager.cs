using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;


namespace ReferLocal
{
	public class APIManager
	{

		private HttpClient client;

		static APIManager sharedManager = null;


		public static APIManager sharedInstance()
		{
			if (sharedManager == null)
			{
				sharedManager = new APIManager();
			}

			return sharedManager;
		}

		public APIManager()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;

		}

		//Sign
		public async Task<object> SignInAsync(string email, string password)
		{

			var dict = new LoginSuccessDataModel();

			var url = Constants.API_SIGNIN;

			Dictionary<string, string> pairs = new Dictionary<string, string>();

			pairs.Add("identity", email);
			pairs.Add("credential", password);

			FormUrlEncodedContent formContent = new FormUrlEncodedContent(pairs);

			var uri = new Uri(string.Format(url));

			try
			{

				var response = await client.PostAsync(uri, formContent);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();

					var json = Newtonsoft.Json.Linq.JObject.Parse(result);

					if (!isErrorReturned(json))
					{
						var data = JsonConvert.SerializeObject(json);

						Debug.WriteLine(data);
						dict = (LoginSuccessDataModel)JsonConvert.DeserializeObject(data, typeof(LoginSuccessDataModel));

						return dict;

					}
					else {

						return false;
					}


				}
				else {

					Debug.WriteLine(@"Request Failed");
					return "Failed";
				}
			}
			catch (Exception ex)
			{

				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

		}

		public async Task<object> GetOffers() 
		{

			var dict = new List<Offer>();

			var url = Constants.API_GETOFFER + AppManager.sharedInstance().tokenString;

			Debug.WriteLine(url);
			var uri = new Uri(string.Format(url));

			try
			{

				//var hud = DependencyService.Get<IHud>();

				//hud.Show("Loading..");
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();

					string jsonDataStr = "{ 'data' : " + result + "}";

					//hud.Dismiss();

					var json = Newtonsoft.Json.Linq.JObject.Parse(jsonDataStr);


					if (!isErrorReturned(json))
					{
						var data = JsonConvert.SerializeObject(json["data"]);

						dict = (List<Offer>)JsonConvert.DeserializeObject(data, typeof(List<Offer>));

						Debug.WriteLine(dict);
					}
					else {

						return false;
					}


				}
				else
				{
					Debug.WriteLine(@"Request Failed");
					return "Failed";
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return dict;
		}

		public async Task<object> GetAccount()
		{
			var dict = new User();

			var url = Constants.API_GETACCOUNT + AppManager.sharedInstance().tokenString;

			var uri = new Uri(string.Format(url));

			try
			{
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();

					// JObject 
					var json = Newtonsoft.Json.Linq.JObject.Parse(result);

					Debug.WriteLine(json);
					var errorProperty = json.Property("error");
					if (errorProperty != null)
					{
						Debug.WriteLine(errorProperty.Value);

						return "Failed";
					}
					else {

						var data = JsonConvert.SerializeObject(json);

						dict = (User)JsonConvert.DeserializeObject(data, typeof(User));

						Debug.WriteLine(dict);
					}

				}
				else
				{
					Debug.WriteLine(@"Request Failed");
					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return dict;
		}

		public async Task<object> AddOfferToCart(string offerId, string quantity)
		{
			var url = Constants.API_ADDOFFER + offerId + "/" + quantity + "?token=" + AppManager.sharedInstance().tokenString;

			var uri = new Uri(string.Format(url));

			try
			{
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();

					// JObject 
					var json = Newtonsoft.Json.Linq.JObject.Parse(result);

					if (isErrorReturned(json))
					{
						return false;
					}
					else {

						return true;
					}
				}
				else {

					Debug.WriteLine(@"Request Failed");
					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return true;

		}

		public async Task<object> AddGiftOfferToCart(string offerId, string quantity, string giftRecipient)
		{
			var url = Constants.API_ADDGIFTOFFER + offerId + "/" + quantity + "/" + giftRecipient + "?token=" + AppManager.sharedInstance().tokenString;
			var uri = new Uri(string.Format(url));

			try
			{
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{

				}
				else {

					Debug.WriteLine(@"Request Failed");
					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return true;
		}

		public async Task<object> RemoveItemFromCart(string offerId, string cartId)
		{
			var url = Constants.API_REMOVEITEM + offerId + "/" + cartId + "?token=" + AppManager.sharedInstance().tokenString;

			var uri = new Uri(string.Format(url));

			try
			{
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();

					// JObject 
					var json = Newtonsoft.Json.Linq.JObject.Parse(result);

					if (isErrorReturned(json))
					{
						return false;
					}
					else {

						return true;
					}

				}
				else {
					 

					Debug.WriteLine(@"Request Failed");
					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return false;
			}

		}

		public async Task<object> GetCart()
		{

			var dict = new Cart();
			var url = Constants.API_GETCART + AppManager.sharedInstance().tokenString;

			var uri = new Uri(string.Format(url));

			try
			{
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();


					var json = Newtonsoft.Json.Linq.JObject.Parse(result);
					var data = JsonConvert.SerializeObject(json);

					if (!isErrorReturned(json))
					{

						dict = (Cart)JsonConvert.DeserializeObject(data, typeof(Cart));

						Debug.WriteLine(dict);
					}
					else {

						return data;
					}

				
				
				}
				else {

					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return dict;

		}

		public async Task<object> CheckCoupon(string coupon, string subtotal)
		{
			var url = Constants.API_CHECKCOUPON + "coupon=" + coupon + "&subtotal=" + subtotal;

			var uri = new Uri(string.Format(url));

			try
			{
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{

				}
				else {

					Debug.WriteLine(@"Request Failed");
					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return true;
		}

		public async Task<object> Checkout(string stripeToken, string amount, string couponCode, string cartId, string email)
		{
			Dictionary<string, string> pairs = new Dictionary<string, string>();

			pairs.Add("token", AppManager.sharedInstance().tokenString);
			pairs.Add("stripeToken", stripeToken);
			pairs.Add("amount", amount);
			pairs.Add("couponCode", couponCode);
			pairs.Add("cartId", cartId);
			pairs.Add("email", email);

			FormUrlEncodedContent formContent = new FormUrlEncodedContent(pairs);

			var url = Constants.API_CHECKOUT;

			var uri = new Uri(string.Format(url));

			try
			{

				var response = await client.PostAsync(uri, formContent);

				if (response.IsSuccessStatusCode)
				{

				}
				else {
					
					Debug.WriteLine(@"Request Failed");
					return "Failed";
				}
			}
			catch (Exception ex)
			{

				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return true;
		}

		//Get Deal

		public async Task<object> GetOrderByToken()
		{
			var dict = new List<Order>();

			var url = Constants.API_GETORDER + AppManager.sharedInstance().tokenString;

			var uri = new Uri(string.Format(url));

			try
			{
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					string jsonDataStr = "{ 'data' : " + result + "}";

					//hud.Dismiss();

					var json = Newtonsoft.Json.Linq.JObject.Parse(jsonDataStr);
					Debug.WriteLine(json);


					if (!isErrorReturned(json))
					{
						var data = JsonConvert.SerializeObject(json["data"]);
						Debug.WriteLine(data);

						dict = (List<Order>)JsonConvert.DeserializeObject(data, typeof(List<Order>));

						Debug.WriteLine(dict);
					}
					else {

						return false;
					}
				}
				else {

					Debug.WriteLine(@"Request Failed");

					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return dict;
		}




		public async Task<object> GetOrder(string orderId, string stripeCharge)
		{

			var dict = new List<Order>();

			var url = Constants.API_GETORDER + AppManager.sharedInstance().tokenString;

			var uri = new Uri(string.Format(url));

			try
			{
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					string jsonDataStr = "{ 'data' : " + result + "}";

					//hud.Dismiss();

					var json = Newtonsoft.Json.Linq.JObject.Parse(jsonDataStr);


					if (!isErrorReturned(json))
					{
						var data = JsonConvert.SerializeObject(json["data"]);
						Debug.WriteLine(data);

						dict = (List<Order>)JsonConvert.DeserializeObject(data, typeof(List<Order>));

						Debug.WriteLine(dict);
					}
					else {

						return false;
					}				}
				else {
					
					Debug.WriteLine(@"Request Failed");

					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"Error {0}", ex.Message);

				return ex.Message;
			}

			return dict;
		}

		public Boolean isErrorReturned(JObject jObject)
		{
			var errorProperty = jObject.Property("error");
			if (errorProperty != null)
			{
				Debug.WriteLine(errorProperty.Value);

				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
