using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ReferLocal;
using ReferLocal.Droid;


[assembly: ExportRenderer(typeof(CustomButton), typeof(MyButtonRenderer))]
namespace ReferLocal.Droid
{
	public class MyButtonRenderer: ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			var button = (CustomButton)Element;

			if (button == null) return;




		}
	}
}
