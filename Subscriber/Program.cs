using System;

namespace Subscriber
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Subscriber {0} started...", args[0]);
			var subscriber = new Subscriber();
			subscriber.Subscribe();
		}
	}
}
