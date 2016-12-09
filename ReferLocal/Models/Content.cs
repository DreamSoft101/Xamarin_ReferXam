using System;
namespace ReferLocal
{
	public class Content
	{


		public long id { get; set;}
		public DateTime created { get; set;}
		public long quantity { get; set;}
		public string gifting_details { get; set;}
		public Offer offer { get; set;}
		public Content()
		{
		}
	}
}
