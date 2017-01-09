using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;


namespace ReferLocal
{
	public class Offer: INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;


		string _description;
		public float value { get; set; }
		public string title { get; set; }
		public string start { get; set; }
		public long savings { get; set; }
		public string price { get; set; }
		public string nimbleOffer { get ; set; }
		public string limit { get; set; }
		public string imageUrl { get; set; }
		public string id { get; set; }
		public string finePrint { get; set; }
		public string expires { get; set; }
		public string end { get; set; }
		public string description {
			get {
				return _description;
			} 
			set
			{
				_description = value;
				OnPropertyChanged("DescriptionHtml");
			}
		}
		public DateTime created { get; set; }
		public string allowGifting { get; set; }

		public HtmlWebViewSource DescriptionHtml { 
			get 
			{
				string htmlText = description.ToString().Replace(@"\", string.Empty);
				var html = new HtmlWebViewSource
				{
					Html = htmlText
				};
				return html;
			}
		}


		public Offer()
		{
		}

		// Override

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null) // if there is any subscribers 
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}


		ICommand _RemoveButtonTappedCommand;

		public ICommand RemoveButtonTappedCommand
		{
			get
			{
				return _RemoveButtonTappedCommand ?? (_RemoveButtonTappedCommand = new Command(async () => await ExecuteRemoveButtonTappedCommand()));
			}
		}

		async Task ExecuteRemoveButtonTappedCommand()
		{

			Debug.WriteLine(this.id);

			await APIManager.sharedInstance().RemoveItemFromCart(this.id, AppManager.sharedInstance().cartId);
		}

		ICommand _SendButtonTappedCommand;

		public ICommand SendButtonTappedCommand
		{
			get
			{
				return _SendButtonTappedCommand ?? (_SendButtonTappedCommand = new Command(async () => await ExecuteSendButtonTappedCommand()));
			}
		}

		async Task ExecuteSendButtonTappedCommand()
		{
			await APIManager.sharedInstance().AddGiftOfferToCart(this.id, "1", "recipient");
		}

		ICommand _AddCartButtonTappedCommand;

		public ICommand AddCartButtonTappedCommand
		{
			get
			{
				return _AddCartButtonTappedCommand ?? (_AddCartButtonTappedCommand = new Command(async () => await ExecuteAddCartButtonTappedCommand()));
			}
		}

		async Task ExecuteAddCartButtonTappedCommand()
		{
			MyProgressModel.Show("Adding..");
			var result = await APIManager.sharedInstance().AddOfferToCart(this.id, "1");
			MyProgressModel.Hide();

			Debug.WriteLine(result);

			if (result is Boolean)
			{
				if (!(Boolean)result)
				{
				}
				else {

					MessagingCenter.Send<MyCartPage>(RootTabPage.sharedRootPage().myCartPage, "Success");
				}
			}

		}

	}


}
