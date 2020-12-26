namespace MonitorInternetConnectionApplication.Interfaces
{
	public interface IPing
	{
		IPingReply SendPing(string hostNameOrAddress);
	}
}