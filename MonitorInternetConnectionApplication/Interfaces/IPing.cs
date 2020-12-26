using MonitorInternetConnectionApplication.Wrappers;

namespace MonitorInternetConnectionApplication.Interfaces
{
	public interface IPing
	{
		PingReplyWrapper SendPing(string hostNameOrAddress);
	}
}