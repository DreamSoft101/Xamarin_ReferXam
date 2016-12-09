using System;
namespace ReferLocal
{
	public class Address
	{

		public long id { get; set; }
		public string user_id { get; set; }
		public string street1 { get; set; }
		public string street2 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zip { get; set; }
		public string type { get; set; }
		public string marketOptIn { get; set;}
		public DateTime created { get; set; }
		public int userId { get; set;}

		public Address()
		{
		}
	}
}
