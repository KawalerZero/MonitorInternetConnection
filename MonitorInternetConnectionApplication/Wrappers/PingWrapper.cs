using System.Net.NetworkInformation;
using MonitorInternetConnectionApplication.Interfaces;
using MonitorInternetConnectionApplication.Wrappers;

namespace MonitorInternetConnectionApplication
{
	public class PingWrapper : Ping, IPing
	{
		public IPingReply SendPing(string hostNameOrAddress)
		{
			return new PingReplyWrapper(Send(hostNameOrAddress));
		}
	}
}