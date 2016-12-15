using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReferLocal
{
	public class User
	{

		public int id { get; set;}
		public string userName { get; set;}
		public string email { get; set;}
		public string displayName { get; set;}
		public string phone { get; set;}
		public string streetAddress { get; set;}
		public string city { get; set;}
		public string zip { get; set;}
		public string state { get; set;}
		public string created { get; set;}
		public string admin { get; set;}
		public string dealsStripe { get; set;}
		public List<Address> addresses { get; set;}
		public List<Phone> phones { get; set;}


		public User()
		{
		}
	}
}
