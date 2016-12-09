using System;
namespace ReferLocal
{
	public class Order
	{

		public long id { get; set; }
		public DateTime created { get; set; }
		public int user { get; set; }
		public long cart { get; set;}
		public string stripeTransaction { get; set; }

		public Voucher vouchers { get; set;}


		public Order()
		{
		}
	}
}
