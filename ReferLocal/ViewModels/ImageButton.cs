using System;
using Xamarin.Forms;
namespace ReferLocal
{
	public class ImageButton: View
	{
		public event EventHandler Clicked;

		public void SendClicked()
		{
			var handler = Clicked;

			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}
	}
}
