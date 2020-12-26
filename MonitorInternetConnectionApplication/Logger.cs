using System;
using System.IO;
using System.Windows.Forms;

namespace MonitorInternetConnectionApplication
{
	public class Logger : ILogger
	{
		private readonly string SECOND_PART_OF_FILENAME = "Logs.txt";
		private readonly string folderForLogs = "MonitorInternetConnection";

		public void Log(string message)
		{
			try
			{
				string pathToLogs = $"{Directory.GetCurrentDirectory()}//{folderForLogs}";
				Directory.CreateDirectory(pathToLogs);
				string fullPath = $"{pathToLogs}//{DateTime.Today.ToShortDateString()}{SECOND_PART_OF_FILENAME}";
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