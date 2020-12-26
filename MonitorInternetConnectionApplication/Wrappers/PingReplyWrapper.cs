using System.Net.NetworkInformation;

namespace MonitorInternetConnectionApplication.Wrappers
{
	public class PingReplyWrapper
	{
		public PingReplyWrapper(IPStatus status, string address)
		{
			Status = status;
			Address = address;
		}

		public PingReplyWrapper(PingReply pingReply) : this(pingReply.Status, pingReply.Address.ToString())
		{}

		public IPStatus Status { get; }
		public string Address { get; }
	}
}
