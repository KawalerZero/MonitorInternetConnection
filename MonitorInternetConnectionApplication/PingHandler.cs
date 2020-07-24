using System;
using System.Net.NetworkInformation;
namespace MonitorInternetConnectionApplication
{
	public static class PingHandler
	{
		private static readonly string[] ARRAY_OF_IP_ADDRESSES = { "139.130.4.5", "204.15.21.255", "212.77.101.5", "178.33.51.179", "8.8.8.8" };
		private static int PING_NUMBER = 0;

		public static void Ping()
		{
			Ping ping = new Ping();
			try
			{
				var pingReply = ping.Send(ARRAY_OF_IP_ADDRESSES[PING_NUMBER]);
				Logger.Log($"{DateTime.Now}: Ping to: {pingReply.Address} Status: {pingReply.Status}");
			}
			catch (PingException pingEx)
			{
				Logger.Log($"{DateTime.Now}: Ping to: {ARRAY_OF_IP_ADDRESSES[PING_NUMBER]} Ping exception: {pingEx.Message}");
			}
			catch (Exception ex)
			{
				Logger.Log($"{DateTime.Now}: Ping to: {ARRAY_OF_IP_ADDRESSES[PING_NUMBER]} Unexpected exception: {ex.Message}");
			}
			finally
			{
				PING_NUMBER++;
				if (PING_NUMBER > ARRAY_OF_IP_ADDRESSES.Length - 1)
				{
					PING_NUMBER = 0;
				}
			}
		}
	}
}