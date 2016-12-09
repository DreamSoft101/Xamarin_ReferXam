using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class CheckOutView : BaseContentView
	{
		public CheckOutView(BaseElementInterface p) : base(p) 
		{
			InitializeComponent();
		}

		public override object LeftBarButton()
		{
			return null;
		}

		public override bool OnLeftBarButton_Clicked()
		{
			return false;
		}
	}
}
