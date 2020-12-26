using MonitorInternetConnectionApplication.Interfaces;
using System;
using System.Net.NetworkInformation;
namespace MonitorInternetConnectionApplication
{
	public class PingHandler
	{
		public PingHandler(ILogger logger, IPing pingWrapper, IDateTime dateTimeWrapper)
		{
			_logger = logger;
			_pingWrapper = pingWrapper;
			_dateTimeWrapper = dateTimeWrapper;
		}

		private IDateTime _dateTimeWrapper;
		private IPing _pingWrapper;
		private ILogger _logger;
		private readonly string[] ARRAY_OF_IP_ADDRESSES = { "139.130.4.5", "204.15.21.255", "212.77.101.5", "178.33.51.179", "8.8.8.8" };
		private int _pingNumber = 0;

		public void Ping()
		{
			try
			{
				var pingReplyWrapper = _pingWrapper.SendPing(ARRAY_OF_IP_ADDRESSES[_pingNumber]);
				_logger.Log($"{_dateTimeWrapper.Now()}: Ping to: {pingReplyWrapper.Address} Status: {pingReplyWrapper.Status}");
			}
			catch (PingException pingEx)
			{
				_logger.Log($"{_dateTimeWrapper.Now()}: Ping to: {ARRAY_OF_IP_ADDRESSES[_pingNumber]} Ping exception: {pingEx.Message}");
			}
			catch (Exception ex)
			{
				_logger.Log($"{_dateTimeWrapper.Now()}: Ping to: {ARRAY_OF_IP_ADDRESSES[_pingNumber]} Unexpected exception: {ex.Message}");
			}
			finally
			{
				_pingNumber++;
				if (_pingNumber > ARRAY_OF_IP_ADDRESSES.Length - 1)
				{
					_pingNumber = 0;
				}
			}
		}
	}
}