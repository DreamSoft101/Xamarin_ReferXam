using System;

using Xamarin.Forms;

namespace ReferLocal
{
	public abstract class BaseContentView : ContentView, BaseElementInterface
	{

		protected BaseElementInterface parent;
		protected BaseElementInterface activeChild;
		protected int activeChildIndex;

		public BaseContentView(BaseElementInterface p)
		{
			parent = p;
			activeChild = null;
			activeChildIndex = 0;
		}

		public virtual bool OnContentViewSelectionChanged()
		{
			return true;
		}

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
			if (OnContentViewSelectionChanged() == true)
			{
				if (parent != null)
				{
					parent.OnChildViewSelectionChanged();
				}
			}
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

