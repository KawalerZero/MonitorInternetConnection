using MonitorInternetConnectionApplication.Wrappers;
using System;
using System.Threading;

namespace MonitorInternetConnectionApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			Thread thread = new Thread(InternetConnectionExamine);
			thread.Start();
		}
		private static void InternetConnectionExamine()
		{
			Logger logger = new Logger();
			PingWrapper pingWrapper = new PingWrapper();
			DateTimeWrapper dateTimeWrapper = new DateTimeWrapper();
			PingHandler _pingHandler = new PingHandler(logger, pingWrapper, dateTimeWrapper);
			
			while (true)
			{
				Thread.Sleep(60000);
				_pingHandler.Ping();
				GC.Collect();
			}
		}
	}
}