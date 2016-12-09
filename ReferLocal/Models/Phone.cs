using System;
namespace ReferLocal
{
	public class Phone
	{

		public long id { get; set; }
		public string user_id { get; set;}
		public string number { get; set;}
		public string type { get; set;}
		public int marketOptIn { get; set;}
		public string marketTextOptIn { get; set;}
		public DateTime created { get; set;}
		public int userId { get; set;}

		public Phone()
		{
		}
	}
}
