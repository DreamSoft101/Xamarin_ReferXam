using System;
using Acr.UserDialogs;
namespace ReferLocal
{
	public class MyProgressModel
	{
		public MyProgressModel()
		{
		}

		static public void Show(string message)
		{
			UserDialogs.Instance.ShowLoading(message, MaskType.Gradient);
		}

		static public void Hide()
		{
			UserDialogs.Instance.HideLoading();
		}
	}
}
