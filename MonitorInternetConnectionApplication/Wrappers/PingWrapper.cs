using MonitorInternetConnectionApplication.Interfaces;
using System.Net.NetworkInformation;

namespace MonitorInternetConnectionApplication.Wrappers
{
	public class PingWrapper : IPing
	{
		public PingReplyWrapper SendPing(string hostNameOrAddress)
		{
			return new PingReplyWrapper(new Ping().Send(hostNameOrAddress));
		}
	}
}
