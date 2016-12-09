using System;
namespace ReferLocal
{
	public interface BaseElementInterface
	{
		void OnChildViewSelectionChanged();
		Object GetLeftBarButton();
		void OnLeftBarButtonClicked(object sender, EventArgs e);
	}
}
