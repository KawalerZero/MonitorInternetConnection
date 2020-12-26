using System.Net.NetworkInformation;

namespace MonitorInternetConnectionApplication.Interfaces
{
	public interface IPingReply
	{
		IPStatus Status { get; }
		string Address { get; }
	}
}