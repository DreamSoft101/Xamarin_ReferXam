using System;
namespace ReferLocal
{
	public class Token
	{
		public string token { get; set;}
		public int user { get; set;}
		public DateTime expires { get; set;}
		public DateTime created { get; set;}
		public long cart { get; set;}

		public Token()
		{
		}
	}
}
