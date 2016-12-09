using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ReferLocal
{
	public partial class OfferCellXAML : ViewCell
	{
		public OfferCellXAML()
		{
			this.View = new OfferCellXAMLContentView();
		}

		public OfferCellXAML(Offer arg) : this()
		{
			
		}
 
	}
}
