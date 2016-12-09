using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class MyDealsView : BaseContentView
	{

		ObservableCollection<Deal> dealArray = new ObservableCollection<Deal>();


		public MyDealsView(BaseElementInterface p) : base(p)
		{
			InitializeComponent();
			InitializeListview();
		}

		public override object LeftBarButton()
		{
			return null;
		}

		public override bool OnLeftBarButton_Clicked()
		{
			return false;
		}

		public void InitializeListview()
		{
			dealListView.HasUnevenRows = true;
			dealListView.SeparatorVisibility = SeparatorVisibility.None;
			dealListView.ItemsSource = dealArray;

			dealArray.Add(new Deal());
			dealArray.Add(new Deal());
		} 
	}
}
