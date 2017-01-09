using System;
using System.Collections.Generic;
using System.Diagnostics;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class OrderCell : ViewCell
	{

		ZXingBarcodeImageView barcode;
		Label codeLabel;
		public OrderCell()
		{
			InitializeComponent();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			Debug.WriteLine(this.BindingContext);
			var order = (Order)this.BindingContext;


		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			var order = (Order)this.BindingContext;


			if (order.vouchers.Count > 0)
			{
				var voucher = order.vouchers[0];

				Debug.WriteLine("voucher is {0}", voucher.offer.title);

				descriptionLabel.Text = voucher.offer.title;

				//Image Url
				var heaerImageUri = new Uri(string.Format(voucher.offer.imageUrl));
				HeaderImageView.Source = ImageSource.FromUri(heaerImageUri);

				//Barcode Image Url - BarCodeContentLayout


				barcode = new ZXingBarcodeImageView
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					AutomationId = string.Format(voucher.code),
				};
				barcode.BarcodeFormat = ZXing.BarcodeFormat.CODE_128;

				//barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
				barcode.BarcodeOptions.Width = 300;
				barcode.BarcodeOptions.Height = 70;
				barcode.BarcodeOptions.Margin = 10;
				barcode.BarcodeValue = "ZXing.Net.Mobile";
				BarCodeContentLayout.Children.Add(barcode);

				//

				codeLabel = new Label
				{
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.End,
				};
				codeLabel.Text = string.Format(voucher.code);
				BarCodeContentLayout.Children.Add(codeLabel);
				//Purchase Date

				dateLabel.Text = order.created;
			}


			                         

		}
	}
}
