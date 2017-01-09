using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using ReferLocal;
using ReferLocal.Droid;


[assembly: ExportRenderer(typeof(ReferLocal.CreditCardInputPage), typeof(ReferLocal.Droid.CreditCardInputPageRenderer))]

 namespace ReferLocal.Droid
{
	public class CreditCardInputPageRenderer: PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
		}
	}
}
