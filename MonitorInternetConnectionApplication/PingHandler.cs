using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace MonitorInternetConnectionApplication
{
	public class PingHandler
	{
		private List<string> listOfAddressIP = new List<string>();
		private int numberOfPing = 0;
		public PingHandler()
		{
			listOfAddressIP.Add("139.130.4.5");
			listOfAddressIP.Add("204.15.21.255");
			listOfAddressIP.Add("212.77.101.5");
			listOfAddressIP.Add("178.33.51.179");
			listOfAddressIP.Add("8.8.8.8");
		}
		public void Ping()
		{
			Ping pinger = new Ping();
			try
			{
				PingReply reply = pinger.Send(listOfAddressIP[numberOfPing]);
				numberOfPing++;
				if (numberOfPing > listOfAddressIP.Count - 1)
				{
					numberOfPing = 0;
				}
				Logger(DateTime.Now + ": Ping to: " + reply.Address + " Status: " + reply.Status);
			}
			catch (PingException pingEx)
			{
				Logger(DateTime.Now + ": PingExcepion:" + pingEx.Message);
			}
			catch (Exception ex)
			{
				Logger(DateTime.Now + ": Exception:" + ex.Message);
			}
		}
		private void Logger(string lines)
		{
			try
			{
				System.IO.StreamWriter file = new System.IO.StreamWriter("d:\\LogsMonitorInternetConnection\\" + DateTime.Today.ToShortDateString() + "Logs" + ".txt", true);
				file.WriteLine(lines);
				file.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
		}
	}
}
