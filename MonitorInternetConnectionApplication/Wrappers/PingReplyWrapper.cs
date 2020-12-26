using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using MonitorInternetConnectionApplication.Interfaces;

namespace MonitorInternetConnectionApplication.Wrappers
{
	public class PingReplyWrapper : IPingReply
	{
		public PingReplyWrapper(PingReply pingReply)
		{
			Status = pingReply.Status;
			Address = pingReply.Address.ToString();
		}
		public IPStatus Status { get; }
		public string Address { get; }
	}
}
