using System;
namespace ReferLocal
{
	public class Voucher
	{
		public long id { get; set;}
		public DateTime created { get; set;}
		public int userId { get; set;}
		public string code { get; set;}
		public long offerId { get; set;} 
		public DateTime expires { get; set;}
		public string redeemedDate { get; set;}
		public long transactionId { get; set;}
		public string gifted { get; set;}
		public string redeemed { get; set;}
		public string recipient { get; set;}
		public string nimbleOffer { get; set;}
		public Offer offer { get; set;}

 		public Voucher()
		{
		}
	}
}
