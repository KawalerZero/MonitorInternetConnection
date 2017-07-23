namespace MonitorInternetConnectionApplication
{
	class Program
	{
		private static System.Timers.Timer _timer;
		private static PingHandler pH = new PingHandler();
		static void Main(string[] args)
		{
			_timer = new System.Timers.Timer();
			_timer.Elapsed += aTimer_Elapsed;
			_timer.Interval = 60000;
			_timer.Enabled = true;
			_timer.Start();
			System.Console.Read();
		}
		private static void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			_timer.Stop();
			pH.Ping();
			_timer.Start();
		}
	}
}
