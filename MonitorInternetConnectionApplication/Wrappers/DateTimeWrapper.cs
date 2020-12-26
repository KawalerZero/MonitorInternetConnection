using System;
using MonitorInternetConnectionApplication.Interfaces;

namespace MonitorInternetConnectionApplication.Wrappers
{
	public class DateTimeWrapper : IDateTime
	{
		public string Now()
		{
			return DateTime.Now.ToString(); ;
		}
	}
}
