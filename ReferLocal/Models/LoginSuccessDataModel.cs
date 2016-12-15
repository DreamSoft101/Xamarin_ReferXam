using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ReferLocal
{
	public class LoginSuccessDataModel
	{
		public string token { get; set;}
		public string expires { get; set;}
		public string id { get; set; }
		public string email { get; set; }

		public LoginSuccessDataModel()
		{
			
		}
	}
}
