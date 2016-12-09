using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReferLocal
{
	public class Cart
	{


		public long id { get; set;}
		public DateTime created { get; set;}
		public int count { get; set;}
		public float total { get; set;}
		public string coupon { get; set;}
		public string transaction { get; set;}
		public List<Content> contents { get; set;}
		public Token token { get; set;}
		public User user { get; set;}
		public bool credits { get; set;}

		public Cart()
		{

		}
	}
}
