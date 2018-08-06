using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
namespace MonitorInternetConnectionApplication
{
	public static class PingHandler
	{
		private static string PATH = @"d:\LogsMonitorInternetConnection\";
		private static string SECOND_PART_OF_FILENAME = "Logs.txt";
		private static string[] ARRAY_OF_IP_ADDRESSES = { "139.130.4.5", "204.15.21.255", "212.77.101.5", "178.33.51.179", "8.8.8.8" };
		private static int PING_NUMBER = 0;

		public static void Ping()
		{
			Ping ping = new Ping();
			try
			{
				var pingReply = ping.Send(ARRAY_OF_IP_ADDRESSES[PING_NUMBER]);
				PING_NUMBER++;
				if (PING_NUMBER > ARRAY_OF_IP_ADDRESSES.Length - 1)
				{
					PING_NUMBER = 0;
				}
				Log(DateTime.Now + ": Ping to: " + pingReply.Address + " Status: " + pingReply.Status);
			}
			catch (PingException pingEx)
			{
				Log(DateTime.Now + ": Ping exception: " + pingEx.Message);
			}
			catch (Exception ex)
			{
				Log(DateTime.Now + ": Unexpected exception: " + ex.Message);
			}
		}
		private static void Log(string message)
		{
			try
			{
				string fullPath = PATH + DateTime.Today.ToShortDateString() + SECOND_PART_OF_FILENAME;
				var file = new StreamWriter(fullPath, true);
				file.WriteLine(message);
				file.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
		}
	}
}