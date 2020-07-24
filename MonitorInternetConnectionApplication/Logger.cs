using System;
using System.IO;
using System.Windows.Forms;

namespace MonitorInternetConnectionApplication
{
	public static class Logger
	{
		private static readonly string PATH = @"d:\LogsMonitorInternetConnection\";
		private static readonly string SECOND_PART_OF_FILENAME = "Logs.txt";

		public static void Log(string message)
		{
			try
			{
				string fullPath = PATH + DateTime.Today.ToShortDateString() + SECOND_PART_OF_FILENAME;
				var file = new StreamWriter(fullPath, true);
				file.WriteLine(message);
				file.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
		}
	}
}
