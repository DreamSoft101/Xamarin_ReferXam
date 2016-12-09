using System;
namespace ReferLocal
{
	public interface IHud
	{

		void Show();
		void Show(string message);
		void Dismiss();
	}
}
