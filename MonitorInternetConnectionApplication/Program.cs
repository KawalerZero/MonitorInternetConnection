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
			while (true)
			{
				Thread.Sleep(60000);
				PingHandler.Ping();
				GC.Collect();
			}
		}
	}
}