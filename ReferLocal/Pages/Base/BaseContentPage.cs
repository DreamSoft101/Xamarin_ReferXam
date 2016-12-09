using System;

using Xamarin.Forms;

namespace ReferLocal
{
	public class BaseContentPage : ContentPage, BaseElementInterface
	{
		protected BaseElementInterface activeChild;
		protected int activeChildIndex;
		public BaseContentPage()
		{
			activeChild = null;
			activeChildIndex = 0;
		}

		public virtual void OnContentViewSelectionChanged() { }
		public virtual Object LeftBarButton()
		{
			return null;
		}

		public virtual bool OnLeftBarButton_Clicked()
		{
			return true;
		}

		//Implementations of BaseElementInterface

		public void OnChildViewSelectionChanged()
		{
			OnContentViewSelectionChanged();
		}

		public Object GetLeftBarButton()
		{
			Object leftBtn = LeftBarButton();

			if (leftBtn != null)
			{
				return leftBtn;
			}

			if (activeChild != null && activeChildIndex > 0)
				leftBtn = activeChild.GetLeftBarButton();

			return leftBtn;
		}

		public void OnLeftBarButtonClicked(object sender, EventArgs e)
		{
			if (OnLeftBarButton_Clicked() == true)
			{
				if (activeChild != null && activeChildIndex > 0)
					activeChild.OnLeftBarButtonClicked(sender, e);
			}
		}
	}
}

