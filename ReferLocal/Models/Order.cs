using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;namespace ReferLocal
{
	public class Order
	{

		public long id { get; set; }
		public string created { get; set; }
		public int user { get; set; }
		public long cart { get; set;}
		public string stripeTransaction { get; set; }

		public List<Voucher> vouchers { get; set;}


		public Order()
		{
		}
	}
}
